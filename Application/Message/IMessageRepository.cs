using Domain;

namespace Application.Message
{
    public interface IMessageRepository<T>
    {
        IQueryable GetMessagesBetweenTwoUsers(int userId, int messageId);
        Task<T> CreateAsync(T entity);

    }
}