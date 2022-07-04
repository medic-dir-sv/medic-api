using Medic.Services.ViewModels.Common;

namespace Medic.Services.ViewModels.Auth;

public class BaseIdentityWithTokenVm : BaseIdentityVm
{
    public TokenVm? Auth { get; set; }
}