using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Greet()
        {
            return Ok("Good morning");
        }
    }

}
