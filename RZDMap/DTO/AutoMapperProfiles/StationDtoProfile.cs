using AutoMapper;
using RZDMap.DTO;
using RZDMap.Models;

namespace RZDMapRailwaysApi.DTO.AutoMapperProfiles;

public class StationDtoProfile : Profile
{
    public StationDtoProfile()
    {
        CreateMap<Station, StationDto>().ReverseMap();
    }
}