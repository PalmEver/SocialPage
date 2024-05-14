using Domain;
using MediatR;
using Persistence;

namespace Application.Entries
{
    public class Details
    {
        public class Query : IRequest<Posts>
        {
            public Guid Id {get; set;}
        }

        public class Handler : IRequestHandler<Query, Posts>
        {
        private readonly UserContext _context;
            public Handler(UserContext context)
            {
            _context = context;

            }
            public async Task<Posts> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Posts.FindAsync(request.Id);
            }
        }
    }
}