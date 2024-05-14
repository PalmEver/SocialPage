using Persistence;

namespace Application.Follow
{
    public class FollowRepository<T> : IFollowRepository<T> where T : Domain.Followers
    {
        private readonly UserContext _context;
        public FollowRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}