using ahtirn.Domain.Interfaces;

namespace ahtirn.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public object[] Get()
        {
            var users = _usersRepository.Get();
            return users;
        }

        public void Create(object user)
        {
            _usersRepository.Create(user);
        }
    }
}