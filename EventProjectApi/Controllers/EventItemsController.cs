using EventProjectApi.Controllers.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventItemsController : ControllerBase
	{
		        private readonly ApplicationDbContext _context;
		public EventItemsController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("allevents")]
		public IActionResult GetEventItems() 
		{
			var result = _context.EventItems.ToList();	
			return Ok(result);
		}

		[HttpGet("singleevents")]
		public IActionResult GetAllEventItems()
		{
			var result = _context.EventItems.Where(myEvent => myEvent.Id == 2);
			return Ok(result);
		}

	}
}
