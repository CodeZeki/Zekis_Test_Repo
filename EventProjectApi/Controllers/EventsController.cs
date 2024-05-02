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
            var events = _context.Events.ToList();
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
        [HttpPost]
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
        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] EventModel eventModelFromDb)
        {
            if (id != eventModelFromDb.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedEvent = _context.Update(eventModelFromDb);
                return Ok(updatedEvent);
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
