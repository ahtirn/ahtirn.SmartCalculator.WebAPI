using Microsoft.AspNetCore.Mvc;

namespace ahtirn.SmartCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerUsersController : ControllerBase
    {
        [HttpGet("LoggerNew")]
        public IActionResult LoggerNew()
        {
            return Ok(Request);
        }
    }
}