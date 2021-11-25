using ahtirn.Core.Models;

namespace ahtirn.Core.Interfaces
{
    public interface IUsersService
    {
        public User[] Get();
        public bool ValidationData(User user);
    }
}