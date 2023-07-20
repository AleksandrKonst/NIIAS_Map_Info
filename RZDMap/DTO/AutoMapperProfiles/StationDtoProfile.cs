using AutoMapper;
using RZDMap.Models;

namespace RZDMap.DTO.AutoMapperProfiles;

public class StationDtoProfile : Profile
{
    public StationDtoProfile()
    {
        CreateMap<Station, StationDto>().ReverseMap();
        CreateMap<StationLine, MapLineDTO>().ReverseMap();
    }
}