using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RZDMap.Data;
using RZDMap.DTO;

namespace RZDMap.Services;

public class StationService : IStationService
{
    private readonly IMapper _mapper;
    private readonly GeoNiiasContext _context;

    public StationService(IMapper mapper, GeoNiiasContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<StationDto> GetStationAsync(int id)
    {
        return _mapper.Map<StationDto>(await _context.Stations.Where(st => st.Esr == id)
            .FirstOrDefaultAsync());
    }

    public async Task<StationDto> GetByOsmIdStationAsync(int id)
    {
        return _mapper.Map<StationDto>(await _context.Stations.Where(st => st.OsmId == id)
            .FirstOrDefaultAsync());
    }

    public async Task<IEnumerable<StationDto>> GetAllStationsAsync()
    {
        return _mapper.Map<IEnumerable<StationDto>>(await _context.Stations.ToListAsync());
    }

    public async Task<IEnumerable<StationDto>> GetPartStationsAsync(int pageSize, int page = 0)
    {
        return _mapper.Map<IEnumerable<StationDto>>(await _context.Stations
            .Skip(pageSize * page)
            .Take(pageSize)
            .ToListAsync());
    }

    public async Task<StationDto> GetByNameStationAsync(string name)
    {
        return _mapper.Map<StationDto>(await _context.Stations
            .Where(st => st.Name.Contains(name))
            .FirstOrDefaultAsync());
    }

    public async Task<IEnumerable<StationDto>> GetByNameAllStationsAsync(string name)
    {
        return _mapper.Map<IEnumerable<StationDto>>(await _context.Stations
            .Where(st => st.Name.Contains(name))
            .ToListAsync());
    }

    public async Task<IEnumerable<StationDto>> GetByNamePartStationsAsync(string name, int pageSize, int page = 0)
    {
        return _mapper.Map<IEnumerable<StationDto>>(await _context.Stations
            .Where(st => st.Name.Contains(name))
            .Skip(pageSize * page)
            .Take(pageSize)
            .ToListAsync());
    }
}