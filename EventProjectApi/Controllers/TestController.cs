using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/example
        [HttpGet]
        public IActionResult Get()
        {
            // Beispiel-Daten
            var exampleData = new
            {
                Name = "Beispiel",
                Description = "Dies ist ein Beispiel JSON-Datensatz."
            };

            // JSON zurückgeben
            return Ok(exampleData);
        }
    }
}
