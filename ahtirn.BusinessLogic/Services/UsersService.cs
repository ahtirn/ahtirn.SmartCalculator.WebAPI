using System;
using System.Linq;
using ahtirn.Core.Interfaces;
using ahtirn.Core.Models;

namespace ahtirn.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        // private readonly IUsersRepository _usersRepository;
        // public UsersService(IUsersRepository usersRepository)
        // {
        //     _usersRepository = usersRepository;
        // }

        public User[] Get()
        {
            var rnd = new Random();
            return Enumerable.Range(1, 3)
                .Select(_ => new User
                {
                    Age = (byte)rnd.Next(),
                    Weight = (float)rnd.NextDouble(),
                    Height = (short)rnd.Next(),
                    Gender = (Gender)rnd.Next(0, 2)
                }).ToArray();
        }

        public bool ValidationData(User user)
        {
            if (user.Age is < 1 or > 100)
                return false;            
            if (user.Height is < 10 or > 350)
                return false;            
            if (user.Weight is < 10 or > 400)
                return false;
            return true;
        }
    }
}