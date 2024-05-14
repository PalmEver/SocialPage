using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Posts Posts {get; set;}
        }
        public class Handler : IRequestHandler<Command>
        {
        private readonly UserContext _context;
        private readonly IMapper _mapper;
            public Handler(UserContext context, IMapper mapper)
            {
            _mapper = mapper;
            _context = context;
                
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var editPost = await _context.Posts.FindAsync(request.Posts.Id);

                _mapper.Map(request.Posts, editPost);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}