using Medic.Services.ViewModels.Common;

namespace Medic.Services.ViewModels.Clinics;

public record CenterVm(int Id, GeolocationVm? Location, string? Name);