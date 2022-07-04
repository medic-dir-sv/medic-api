using AutoMapper;
using Medic.Domain.Entities.Common;
using Medic.Services.ViewModels.Common;

namespace Medic.Services.Mappings;

public class GeolocationMappings : Profile
{
    public GeolocationMappings()
    {
        CreateMap<Geolocation, GeolocationVm>();
        CreateMap<GeolocationVm, Geolocation>();
    }
}