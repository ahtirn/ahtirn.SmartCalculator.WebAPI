using ahtirn.Domain.Models;

namespace ahtirn.Domain.Interfaces
{
    public interface IUsersRepository
    {
        User[] Get();
        void Create(User user);
    }
}