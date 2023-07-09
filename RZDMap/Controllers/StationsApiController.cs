using Microsoft.AspNetCore.Mvc;
using RZDMapRailwaysApi.DTO;
using RZDMapRailwaysApi.Services;

namespace RZDMapRailwaysApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
public class StationsApiController : ControllerBase
{
    private readonly IStationService _service;
        
    public StationsApiController(IStationService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [Route("get/station/{id}")]
    public async Task<ActionResult<StationDto>> GetByIdStation(int id)
    {
        var station = await _service.GetStationAsync(id);
        if (station == null)
        {
            return NoContent();
        }
        return Ok(station);
    }

    [HttpGet]
    [Route("get/station/osm_id/{id}")]
    public async Task<ActionResult<StationDto>> GetByOsmIdStation(int id)
    {
        var station = await _service.GetByOsmIdStationAsync(id);
        if (station == null)
        {
            return NoContent();
        }

        return Ok(station);
    }

    [HttpGet]
    [Route("get/stations")]
    public async Task<ActionResult<IEnumerable<StationDto>>> GetAllStations()
    {
        return  Ok(await _service.GetAllStationsAsync());
    }

    [HttpGet]
    [Route("get/stations/{pageSize}")]
    [Route("get/stations/{pageSize}/{page}")]
    public async Task<ActionResult<IEnumerable<StationDto>>> GetPartStations(int pageSize, int page = 0)
    {
        return  Ok(await _service.GetPartStationsAsync(pageSize, page));
    }
    
    [HttpGet]
    [Route("get/station/name/{name}")]
    public async Task<ActionResult<StationDto>> GetByNameStation(string name)
    {
        var station = await _service.GetByNameStationAsync(name);
        if (station == null)
        {
            return NoContent();
        }
        return Ok(station);
    }
    
    [HttpGet]
    [Route("get/stations/name/{name}")]
    public async Task<ActionResult<IEnumerable<StationDto>>> GetByNameAllStations(string name)
    {
        return  Ok(await _service.GetByNameAllStationsAsync(name));
    }
    
    [HttpGet]
    [Route("get/stations/name/{name}/{pageSize}")]
    [Route("get/stations/name/{name}/{pageSize}/{page}")]
    public async Task<ActionResult<IEnumerable<StationDto>>> GetByNamePartStations(string name, int pageSize, int page = 0)
    {
        return  Ok(await _service.GetByNamePartStationsAsync(name, pageSize, page));
    }
}