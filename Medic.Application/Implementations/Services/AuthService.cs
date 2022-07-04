using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Amazon.S3;
using AutoMapper;
using Medic.Domain.Entities.Common;
using Medic.Services.Abstracts.Repositories;
using Medic.Services.Abstracts.Services;
using Medic.Services.Exceptions;
using Medic.Services.Extensions;
using Medic.Services.ViewModels;
using Medic.Services.ViewModels.Auth;
using Medic.Services.ViewModels.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Medic.Services.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAwsServiceS3 _awsService;

    public AuthService(IAuthRepository repository, IMapper mapper, IAwsServiceS3 awsService)
    {
        _repository = repository;
        _mapper = mapper;
        _awsService = awsService;
    }

    public async Task<BaseIdentityWithTokenVm> LoginAsync(IConfiguration configuration, LoginVm loginInfo)
    {
        var user = await _repository.GetByEmailAsync(loginInfo.Email);

        if (user is null)
            throw new HttpException(404, "User not found");

        if (!loginInfo.Password.VerifyPassword(user.Password!))
            throw new UnauthorizedAccessException("Wrong credentials");

        var token = new TokenVm
        {
            Token = GenerateJwt(configuration, user)
        };

        var mapped = _mapper.Map<BaseIdentity, BaseIdentityWithTokenVm>(user);
        mapped.Auth = token;

        return mapped;
    }

    public async Task<BaseIdentityVm> RegisterAsync(RegisterVm identityVm)
    {
        var isNew = await _repository.IsNewAsync(identityVm.Email);

        if (!isNew)
            throw new HttpException(400, "User already exists");

        identityVm.Password = identityVm.Password.HashPassword();

        var imageUri = string.Empty; 
        if (identityVm.Img is not null)
        {
            imageUri = await _awsService.UploadFile(identityVm.Img);
        }
        
        var user = await _repository.RegisterAsync(
            _mapper.Map<RegisterVm, BaseIdentity>(identityVm),
            imageUri
        );
        
        return _mapper.Map<BaseIdentity, BaseIdentityVm>(user);
    }

    private string GenerateJwt(IConfiguration configuration, BaseIdentity identity)
    {
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Claims = new Dictionary<string, object>()
            {
                { ClaimTypes.Role, identity.Role.ToString() }                
            },
            Subject = new ClaimsIdentity(new []
            {
                new Claim("Email", identity.Email!),
                new Claim(ClaimTypes.Role, identity.Role.ToString()),
            }),
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha512Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }
}