using ahtirn.Domain.Interfaces;
using ahtirn.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// Временно без DI
// using ahtirn.BusinessLogic.Services;

namespace ahtirn.SmartCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("PostUser")] // Placeholder 
        public IActionResult Create([FromBody]User user)
        {
            var success= _usersService.ValidationData(user);
            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("RandomUser")] // Placeholder 
        public User[] Get()
        {
            return _usersService.Get();
        }
    }
}