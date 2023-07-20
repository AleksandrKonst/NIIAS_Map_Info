using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RZDMap.DTO;
using RZDMap.Services;

namespace RZDMap.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
public class MapLinesApiController : ControllerBase
{
    private readonly IMapLineService _service;

    public MapLinesApiController(IMapLineService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [Authorize(Policy = "ManagerDevelopers")]
    [Route("get/maplines")]
    public async Task<ActionResult<IEnumerable<StationDto>>> GetAllStations()
    {
        return  Ok(await _service.GetAllMapLinesAsync());
    }
}