using ahtirn.Core.Models;

namespace ahtirn.Core.Interfaces
{
    public interface IUsersRepository
    {
        User[] Get();
        void Create(User user);
    }
}