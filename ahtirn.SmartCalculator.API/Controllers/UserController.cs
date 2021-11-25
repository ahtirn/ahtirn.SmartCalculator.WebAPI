using Microsoft.AspNetCore.Mvc;

// Временно без DI
using ahtirn.BusinessLogic.Services;
using ahtirn.Core.Interfaces;
using ahtirn.Core.Models;

namespace ahtirn.SmartCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController()
        {
            _usersService = new UsersService();

            // IUsersRepository usersRepository = new UsersRepository();
            //TODO: Временно без DI
            // _usersService = new UsersService(usersRepository);
        }

        [HttpPost("Logger")] // PlaceHolder 
        public IActionResult Logger([FromBody]User user)
        {
            return Ok("Че то вернул");
        }

        [HttpPost("PostUser")]
        public IActionResult Create(User user)
        {
            var success= _usersService.ValidationData(user);
            if (success)
            {
                return Ok("Удачно");
            }
            return BadRequest("Ошибка введенных данных");
        }

        [HttpGet("RandomUser")]
        public User[] Get()
        {
            return _usersService.Get();
        }

        #region TestReflection
        // [HttpGet("GetValidCheck")]
        // public void PostValidUser([FromQuery]User user)
        // {
        //     var userType = user.GetType();
        //     foreach (var propertyInfo in userType.GetProperties())
        //     {
        //         var rangeAttribute = propertyInfo.GetCustomAttribute(userType, RangeAttribute);
        //         var valueProperty = propertyInfo.GetValue(user);
        //         var typeProperty = propertyInfo.PropertyType.FullName;
        //         var t = Convert.ChangeType(valueProperty, Type.GetType(typeProperty));
        //
        //         if (rangeAttribute != null && valueProperty != null)
        //         {
        //             // bool isValueNotRange = t > rangeAttribute.MaxValue;
        //         
        //             // if (isValueNotRange)
        //             // {
        //                 // throw new ArgumentException("AYE");
        //             // }
        //         }
        //
        //         // if (rangeAttribute != null && valueProperty != null)
        //         // {
        //         //     var isValueNotRange = valueProperty is byte specifiedValue
        //         //                           && (specifiedValue >= rangeAttribute.MaxValue 
        //         //                               || specifiedValue <= rangeAttribute.MinValue);
        //         //
        //         //     if (isValueNotRange)
        //         //         throw new ArgumentOutOfRangeException("ERROR BLED", nameof(valueProperty));
        //         // }
        //     }
        // }
        #endregion
    }
}