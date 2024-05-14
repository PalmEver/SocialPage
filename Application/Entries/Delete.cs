using MediatR;
using Persistence;

namespace Application
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly UserContext _context;
            public Handler(UserContext context)
            {
            _context = context;

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Id);

                _context.Remove(post);
                
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}