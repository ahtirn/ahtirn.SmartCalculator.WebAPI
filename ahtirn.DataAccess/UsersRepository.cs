using System;
using ahtirn.Core.Interfaces;

namespace ahtirn.DataAccess
{
    /// <summary>
    /// <param name="UsersRepository">Обработка логики для взаимодействия с БД</param>>
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        public Core.Models.User[] Get()
        {
            // Mapping
            var user = new User
            {
                Id = 1,
                DateTime = DateTime.Now,
                Age = 21,
                Weight = 64,
                Height = 174
            };

            return new[]
            {
                new Core.Models.User
                {
                    Age = user.Age,
                    Weight = user.Weight,
                    Height = user.Height
                }
            };
        }

        public void Create(Core.Models.User user)
        {
        }
    }
}