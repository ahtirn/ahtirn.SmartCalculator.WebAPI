using System;
using System.Collections.Generic;
using System.Linq;
using ahtirn.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ahtirn.SmartCalculator.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("RandomUser")]
        public IEnumerable<User> GetUsers()
        {
            var rnd = new Random();
            var user =  Enumerable.Range(1, 3)
                .Select(_ => new User
                {
                    Age = (byte)rnd.Next(),
                    Weight = (short)rnd.Next(),
                    Height = (short)rnd.Next(),
                    Gender = (Gender)rnd.Next(0, 2),
                }).ToList();
            return user;
        }

        [HttpPost("[action]")] // PlaceHolder 
        public IActionResult PostUsers([FromBody]User user)
        {
            return Ok("Че то вернул");
        }

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
    }
}