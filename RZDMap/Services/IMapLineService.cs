using RZDMap.DTO;

namespace RZDMap.Services;

public interface IMapLineService
{
    Task<IEnumerable<MapLineDTO>> GetAllMapLinesAsync();
}