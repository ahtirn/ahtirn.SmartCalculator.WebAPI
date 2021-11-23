namespace ahtirn.Domain.Interfaces
{
    public interface IUsersRepository
    {
        public object[] Get();
        public void Create(object user);
    }
}