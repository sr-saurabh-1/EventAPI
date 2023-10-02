using Event_Concerns;
using Event_Contracts;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        IEventContracts eventContracts;
        public EventController(IEventContracts eventContracts)
        {
            this.eventContracts = eventContracts;
        }
        [HttpGet]
        [Route("get-event-by-id")]
        public IActionResult GetEventById(string id) 
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }
            var events = eventContracts.GetEventById(id);
            return Ok(events);

        }
        [HttpGet]
        [Route("get-all-event")]
        public IActionResult GetEvents()
        {
            var events = eventContracts.GetEvents();
            return Ok(events);

        }
        [HttpPost]
        public IActionResult AddEvent(EventConcerns eventConcerns)
        {
            var x = eventConcerns.Date.Date;
            eventContracts.AddEvent(eventConcerns);
            return Ok(eventConcerns);  
        }

        [HttpPut]
        public IActionResult UpdateEvent(EventConcerns eventConcerns)
        {
            var result=eventContracts.UpdateEvent(eventConcerns);
            if (result == null)
                return BadRequest("no event found for update");
            return Ok(result);
        }


        [HttpDelete]
        public IActionResult DeleteEvent(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }
            var isDeleted=eventContracts.DeleteEvent(id);

            if (isDeleted)
                return Ok("Event deleted successfully");
            else
                return BadRequest("Event not found.");

        }

    }
}
