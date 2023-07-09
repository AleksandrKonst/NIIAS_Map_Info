using RZDMapRailwaysApi.DTO;

namespace RZDMapRailwaysApi.Services;

public interface IStationService
{
    Task<StationDto> GetStationAsync(int id);
    Task<StationDto> GetByOsmIdStationAsync(int id);
    Task<IEnumerable<StationDto>> GetAllStationsAsync();
    Task<IEnumerable<StationDto>> GetPartStationsAsync(int pageSize, int page = 1);
    Task<StationDto> GetByNameStationAsync(string name);
    Task<IEnumerable<StationDto>> GetByNameAllStationsAsync(string name);
    Task<IEnumerable<StationDto>> GetByNamePartStationsAsync(string name, int pageSize, int page = 1);
}