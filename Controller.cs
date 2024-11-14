using Intrams.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IntramsContext _context;

    
    public EventsController(IntramsContext context)
    {
        _context = context;
    }

    [HttpGet("players")]
    public async Task<ActionResult<List<Player>>> GetPlayers()
    {
        var players = await _context.Players.ToListAsync();
        if (players == null || !players.Any())
        {
            return NotFound(); // Ensure you handle the case where no players exist
        }
        return Ok(players);
    }

    [HttpPost("players")]
    public async Task<ActionResult<Player>> CreatePlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlayers), new { id = player.Id }, player);
    }

    [HttpGet("events")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        var events = await _context.Events.ToListAsync();
        if (events == null || !events.Any())
        {
            return NotFound(); // Ensure you handle the case where no events exist
        }
        return Ok(events);
    }

    [HttpPost("events")]
    public async Task<ActionResult<Event>> CreateEvent(Event eventEntity)
    {
        _context.Events.Add(eventEntity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEvents), new { id = eventEntity.Id }, eventEntity);
    }

    [HttpGet("sports")]
    public async Task<ActionResult<IEnumerable<Sports>>> GetSports()
    {
        var sports = await _context.Sports.ToListAsync();
        if (sports == null || !sports.Any())
        {
            return NotFound(); // Ensure you handle the case where no events exist
        }
        return Ok(sports);
    }

    [HttpPost("sports")]
    public async Task<ActionResult<Sports>> CreateSport(Sports sport)
    {
        _context.Sports.Add(sport);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSports), new { id = sport.Id }, sport);
    }

    [HttpGet("locations")]
    public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
    {
        var locations = await _context.Locations.ToListAsync();
        if (locations == null || !locations.Any())
        {
            return NotFound(); // Ensure you handle the case where no events exist
        }
        return Ok(locations);
    }

    [HttpPost("locations")]
    public async Task<ActionResult<Location>> CreateLocation(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);
    }

}
