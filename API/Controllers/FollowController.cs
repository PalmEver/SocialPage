using API.DTO;
using Application;
using Application.Follow;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class FollowController : BaseApiController
    {
        private readonly IFollowRepository<Followers> _followRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserContext _context;


        public FollowController(
            IFollowRepository<Followers> followRepository,
            IMapper mapper,
            IUserRepository userRepository,
            UserContext context)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _context = context;
        }

        [HttpGet("{userId}")]
        public IQueryable<object> GetFollowersByUserId(int userId)
        {
            var users = _context.Follows.Where(a => a.User.Id == userId).Select(x => new { followId = x.FollowId });
            return users;
        }

        [HttpPost]
        public async Task<FollowDto> FollowUser(FollowDto followDto)
        {
            var follow = _mapper.Map<Followers>(followDto);
            var user = _userRepository.GetById(followDto.UserId);

            var followId = followDto.FollowId;
            var userId = followDto.UserId;
            var followingIdArray = _context.Follows
            .Where(a => a.User.Id == userId)
            .Select(x => new { followId = x.FollowId })
            .ToArray();

            for (int i = 0; i < followingIdArray.Length; i++)
            {
                if (followId == followingIdArray[i].followId)
                {
                    throw new Exception("Already Followed");
                }
            }

            if (user != null)
                follow.User = user;

            var followCreated = await _followRepository.CreateAsync(follow);
            var followCreatedDto = _mapper.Map<FollowDto>(followCreated);

            return followCreatedDto;
        }

    }
}