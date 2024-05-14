using Application;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {

        private readonly UserContext _context;
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository, UserContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public IQueryable GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return users;
        }
    }
}