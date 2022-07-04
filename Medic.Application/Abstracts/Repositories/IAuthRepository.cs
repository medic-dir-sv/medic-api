using Medic.Domain.Entities.Common;

namespace Medic.Services.Abstracts.Repositories;

public interface IAuthRepository
{
    Task<BaseIdentity?> GetByEmailAsync(string email);

    Task<BaseIdentity> RegisterAsync(BaseIdentity identity, string profileImgLocation);

    Task<bool> IsNewAsync(string email);
}