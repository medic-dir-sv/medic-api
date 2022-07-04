using Medic.Domain.Entities.Common;
using Medic.Domain.Entities.Doctors;
using Medic.Domain.Entities.Patients;
using Medic.Services.Abstracts.Db;
using Medic.Services.Abstracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Medic.Services.Implementations.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly IAppDbContext _ctx;

    public AuthRepository(IAppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<BaseIdentity?> GetByEmailAsync(string email)
    {
        return await _ctx.BaseIdentities.Where(bi => bi.Email!.Equals(email)).FirstOrDefaultAsync();
    }

    public async Task<BaseIdentity> RegisterAsync(BaseIdentity identity, string profileImgLocation)
    {
        BaseIdentity user;

        if (!string.IsNullOrEmpty(profileImgLocation))
            identity.ProfileImage = profileImgLocation;
        
        var serializedParent = JsonConvert.SerializeObject(identity);

        if (identity.Role == Role.Doctor)
            user = _ctx.Doctors.Add(JsonConvert.DeserializeObject<Doctor>(serializedParent)!).Entity;
        else
            user = _ctx.Patients.Add(JsonConvert.DeserializeObject<Patient>(serializedParent)!).Entity;
        
        await _ctx.SaveChangesAsync();

        return user;
    }

    public async Task<bool> IsNewAsync(string email)
    {
        return !(await _ctx.BaseIdentities.AnyAsync(bi => bi.Email!.Equals(email)));
    }
}