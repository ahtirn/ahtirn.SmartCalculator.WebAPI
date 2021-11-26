using ahtirn.Domain.Interfaces;
using ahtirn.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ahtirn.SmartCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerUsersController : ControllerBase
    {
        private readonly ILogService _logService;

        public LoggerUsersController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost("LoggerNew")]
        public IActionResult LoggerNew([FromBody]User user)
        {
            // _logService.LogAsync();
            return Ok("Чето получилось");
        }
    }
}