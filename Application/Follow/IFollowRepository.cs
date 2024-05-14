namespace Application.Follow
{
    public interface IFollowRepository<T>
    {
        Task<T> CreateAsync(T entity);

    }
}