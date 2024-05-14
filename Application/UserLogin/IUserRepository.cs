using Domain;

namespace Application
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
        IQueryable GetAllUsers();
    }
}