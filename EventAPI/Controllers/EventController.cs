using EventConcern;
using EventContracts;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        IEventContract EventContract;

        public EventController(IEventContract eventContracts)
        {
            this.EventContract = eventContracts;
        }

        [HttpGet]
        [Route("get-event-by-id")]
        public IActionResult GetEventById(string id) 
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ObjectId format");
            }
            var events = EventContract.GetEvent(id);
            return Ok(events);
        }

        [HttpGet]
        [Route("get-all-event")]
        public IActionResult GetAll()
        {
            var events = EventContract.GetAll();
            return Ok(events);
        }

        [HttpPost]
        public IActionResult AddEvent(Event newEvent)
        {
            return Ok(EventContract.AddEvent(newEvent));  
        }

        [HttpPut]
        public IActionResult UpdateEvent(Event eventConcerns)
        {
            var result=EventContract.UpdateEvent(eventConcerns);
            if (result == null)
                return BadRequest("no event found for update");
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteEvent(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
                return BadRequest("Invalid ObjectId format");

            var isDeleted=EventContract.DeleteEvent(id);
            if (isDeleted)
                return Ok("Event deleted successfully");
            else
                return BadRequest("Event not found.");
        }
    }
}
