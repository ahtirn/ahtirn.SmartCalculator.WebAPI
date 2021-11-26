using System.Collections.Generic;
using ahtirn.Domain.Models;

namespace ahtirn.Domain.Interfaces
{
    public interface IUsersService
    {
        public User[] Get();
        public bool ValidationData(User user);
    }
}