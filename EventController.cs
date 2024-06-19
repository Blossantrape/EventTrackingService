using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventTrackingService;

[ApiController]
[Route("api/event")]
public class EventController : ControllerBase
{
    private static List<Event> _events = new List<Event>();
    
    // Приём событий.
    [HttpPost("add")]
    public IActionResult AddEvent([FromBody] Event newEvent)
    {
        if (newEvent == null)
        {
            return BadRequest("Event is null.");
        }
        newEvent.Timestamp = DateTime.UtcNow;
        _events.Add(newEvent);
        return Ok(new { Message = "Event added successfully." });
    }

    // Получение данным за временной период.
    [HttpGet("summary")]
    public IActionResult GetSummary([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
    {
        
        var summary = _events
            .Where(e => e.Timestamp >= startTime && e.Timestamp < endTime)
            .GroupBy(e => new DateTime(e.Timestamp.Year, e.Timestamp.Month, e.Timestamp.Day, e.Timestamp.Hour, e.Timestamp.Minute, 0))
            .Select(g => new
            {
                Time = g.Key,
                TotalValue = g.Sum(e => e.Value)
            })
            .OrderBy(x => x.Time)
            .ToList();
        return Ok(summary);
    }
    
    public class Event
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}