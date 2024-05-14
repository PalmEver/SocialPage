using Persistence;

namespace Application.Message
{
    public class MessageRepository<T> : IMessageRepository<T> where T : Domain.Messages
    {
        private readonly UserContext _context;

        public MessageRepository(UserContext context)
        {
            _context = context;
        }

        public IQueryable GetMessagesBetweenTwoUsers(int userId, int messageId)
        {
            return _context.Messages
            .Where(a => a.User.Id == userId && a.MessageId == messageId || a.User.Id == messageId && a.MessageId == userId)
            .Select(x => new { message = x.Message, date = x.Date, name = x.Name })
            .OrderBy(a => a.date);
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // public async Task CreateAsync(

        // )
        // {
        //     await _context.Set<T>().AddAsync(entity);
        //     await _context.SaveChangesAsync();
        //     return entity;
        // }
        // public async Task<T> GetByUserIdAsync(dynamic id)
        // {
        //     var messageUser = 0;
        //     messageUser = id;

        //     var contact = _context.Users
        //     .Where(a => a.Id == messageUser);

        //     return await contact;

        // }
    }
}