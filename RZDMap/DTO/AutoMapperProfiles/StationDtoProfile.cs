using AutoMapper;
using RZDMapRailwaysApi.Models;

namespace RZDMapRailwaysApi.DTO.AutoMapperProfiles;

public class StationDtoProfile : Profile
{
    public StationDtoProfile()
    {
        CreateMap<Station, StationDto>().ReverseMap();
    }
}