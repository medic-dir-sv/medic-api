using Medic.Services.ViewModels.Auth;
using Medic.Services.ViewModels.Common;
using Microsoft.Extensions.Configuration;

namespace Medic.Services.Abstracts.Services;

public interface IAuthService
{
    Task<BaseIdentityWithTokenVm> LoginAsync(IConfiguration configuration, LoginVm loginInfo);

    Task<BaseIdentityVm> RegisterAsync(RegisterVm identityVm);
}