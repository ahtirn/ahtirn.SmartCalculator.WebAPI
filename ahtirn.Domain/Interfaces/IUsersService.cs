using ahtirn.Domain.Models;

namespace ahtirn.Domain.Interfaces
{
    public interface IUsersService
    {
        public object[] Get();
        public void Create(object user);
    }
}