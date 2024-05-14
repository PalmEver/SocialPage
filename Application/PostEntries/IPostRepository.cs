using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.PostEntries
{
    public interface IPostRepository<T>
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetByIdAsync(dynamic id);
        Task<T> CreateAsync(T entity);
        IQueryable GetAllPostsFromUsersYouFollow(int id);
    }
}