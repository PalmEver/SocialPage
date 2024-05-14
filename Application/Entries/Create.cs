using Domain;
using MediatR;
using Persistence;

namespace Application
{
    public class Create
    {
        public class Command :IRequest
        {
            public Posts Posts {get; set;}
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
                _context.Posts.Add(request.Posts);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}