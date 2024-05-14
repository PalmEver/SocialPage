using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entries
{
    public class List
    {
        public class Query : IRequest<List<Posts>> {}

        public class Handler : IRequestHandler<Query, List<Posts>>
        {
            private readonly UserContext _context;
            public Handler(UserContext context)
            {
                _context = context;
            }

            public async Task<List<Posts>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Posts.ToListAsync();
            }
        }
    }
}