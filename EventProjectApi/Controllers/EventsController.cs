using System;
using System.Collections.Generic;
using EventProjectApi.Controllers.Data;
using EventProjectApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet("allevents")]
        public IActionResult GetAllEvents()
        {
            var events = _context.Events.OrderByDescending(d => d.Created).ToList();
            return Ok(events);
        }

        //// GET: api/Events/5
        //[HttpGet("GetEvent/{id}")]
        //[HttpGet("GetOneElement/{id}", Name = "CustomGetEvent")]
        [HttpGet("getevent/{id}")]
        public IActionResult GetEventById(int id)
        {
            var eventObject = _context.Events.Where(e => e.Id == id).FirstOrDefault();
            if (eventObject == null)
            {
                return NotFound();
            }
            return Ok(eventObject);
        }

        //// POST: api/Events
        ///[CreateRoute] // Use the custom attribute
        [HttpPost("create")]
        public IActionResult CreateEvent([FromBody] EventModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(eventModel);
            _context.SaveChanges();

            return Ok(eventModel);
        }

        // PUT: api/Events/5
        [HttpPut("edit/{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] EventModel eventModelFromDb)
        {
            var modelFromDb = _context.Events.Where(e => e.Id == id).FirstOrDefault();

            if (modelFromDb == null)
            {
                return BadRequest();
            }

            try
            {
                //var updatedEvent = _context.Update(eventModelFromDb);

                modelFromDb.Name = eventModelFromDb.Name;
                modelFromDb.LocationAddress = eventModelFromDb.LocationAddress;
                modelFromDb.EventImage = eventModelFromDb.EventImage;
                modelFromDb.Info = eventModelFromDb.Info;
                modelFromDb.Start = eventModelFromDb.Start;
                modelFromDb.LocationName = eventModelFromDb.LocationName;
                modelFromDb.LocationAddress = eventModelFromDb.LocationAddress;
                modelFromDb.LocationComment = eventModelFromDb.LocationComment;
                modelFromDb.LocationWebsite = eventModelFromDb.LocationWebsite;
                modelFromDb.LocationDestination = eventModelFromDb.LocationDestination;

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/Events/5
        //[HttpDelete("{id}")]
        [HttpDelete("deleteevent/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                var removeEvent = _context.Events.Where(e => e.Id == id).FirstOrDefault();
                _context.Remove(removeEvent);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
