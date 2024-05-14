using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.PostEntries
{
    public class PostRepository<T> : IPostRepository<T> where T : Domain.Posts
    {
        private readonly UserContext _context;
        public PostRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(dynamic id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>()
            .Include(x => x.User)
            .ToListAsync();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public IQueryable GetAllPostsFromUsersYouFollow(int id)
        {
            var intFollowIdList = new List<int>();

            var followingIdArray = _context.Follows
            .Where(a => a.User.Id == id)
            .Select(x => new { followId = x.FollowId })
            .ToArray();

            for (int i = 0; i < followingIdArray.Length; i++)
            {
                intFollowIdList.Add(followingIdArray[i].followId);
            }

            var followPosts = _context.Posts
            .Where(x => intFollowIdList != null && intFollowIdList
            .Contains(x.User.Id))
            .Select(x => new { Posts = x.Description, User = x.User.Name, Date = x.Date })
            .OrderByDescending(x => x.Date);

            return followPosts;
        }
    }
}