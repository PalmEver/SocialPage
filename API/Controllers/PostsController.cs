using API.DTO;
using Application;
using Application.PostEntries;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class PostsController : BaseApiController
    {
        //Test ny controller

        private readonly IPostRepository<Posts> _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserContext _context;

        public PostsController(
            UserContext context,
            IPostRepository<Posts> postRepository,
            IMapper mapper,
            IUserRepository userRepository)
        {
            _context = context;
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<PostsDTO> GetPosts()
        {
            var posts = await _postRepository.ListAllAsync();
            var postDtos = _mapper.Map<ICollection<PostDTO>>(posts.OrderByDescending(x => x.Date));
            return new PostsDTO
            {
                Posts = postDtos
            };
        }

        [HttpPost]
        public async Task<PostDTO> CreatePost(PostDTO postDto)
        {
            var post = _mapper.Map<Posts>(postDto);
            var user = _userRepository.GetById(postDto.UserId);
            if (user != null)
                post.User = user;

            var postCreated = await _postRepository.CreateAsync(post);
            var postCreatedDto = _mapper.Map<PostDTO>(postCreated);

            return postCreatedDto;
        }


        [HttpGet("follow/{id}")]
        public IQueryable GetPostsFromFollowedUsersById(int id)
        {
            var followPosts = _postRepository.GetAllPostsFromUsersYouFollow(id);

            return followPosts;
        }

        [HttpGet("user/{id}")]
        public IQueryable<object> GetPostsFromUsersById(int id)
        {
            var userPosts = _context.Posts
            .Where(a => a.User.Id == id)
            .Select(x => new { Posts = x.Description, User = x.User.Name, Date = x.Date })
            .OrderByDescending(x => x.Date);

            return userPosts;
        }
    }
}