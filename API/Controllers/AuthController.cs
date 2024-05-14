using API.Controllers;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API
{
	public class AuthController : BaseApiController
	{
	
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public bool Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),

            };

            try
            {
                _repository.Create(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("login")]
	 public IActionResult Login(LoginDto dto)
	 {
       var user = _repository.GetByEmail(dto.Email);
	   
	   if (user == null) return BadRequest(new{message ="invalid Credentials"});

       if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
	   {
         return BadRequest(new{message ="invalid Credentials"});
	   }

	   var jwt = _jwtService.GenerateJwtToken(user.Id);

	   Response.Cookies.Append("jwt", jwt, new CookieOptions
	   {
		HttpOnly = true
	   });

	   return Ok(new{
            message = "Success"
	   });
	 } 
     
	  [HttpGet("user")]
        public new IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.VerifyJwtToken(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
		   [HttpPost("logout")]
        public IActionResult Logout()
        {
           Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }
	}

}