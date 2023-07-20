using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RZDMap.DTO;
using RZDMap.Models;

namespace RZDMap.Services;

public class MapLineService : IMapLineService
{
    private readonly IMapper _mapper;
    private readonly PostgresContext _context;

    public MapLineService(IMapper mapper, PostgresContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<IEnumerable<MapLineDTO>> GetAllMapLinesAsync()
    {
        return _mapper.Map<IEnumerable<MapLineDTO>>(await _context.StationLines.ToListAsync());
    }
}