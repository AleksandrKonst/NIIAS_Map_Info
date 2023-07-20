using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RZDMap.Data;
using RZDMap.DTO;

namespace RZDMap.Services;

public class MapLineService : IMapLineService
{
    private readonly IMapper _mapper;
    private readonly GeoNiiasContext _context;

    public MapLineService(IMapper mapper, GeoNiiasContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<IEnumerable<MapLineDTO>> GetAllMapLinesAsync()
    {
        return _mapper.Map<IEnumerable<MapLineDTO>>(await _context.StationLines.ToListAsync());
    }
}