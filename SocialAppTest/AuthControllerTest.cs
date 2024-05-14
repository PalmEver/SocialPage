
using Application;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using API;

namespace SocialAppTest
{
    [TestClass]
    public class AuthControllerTest
    {

        private Mock<IUserRepository> _userRepositoryMock;
        private JwtService _jwtService;
        private Mock<RegisterDto> _registerDtoMock;




        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _jwtService = new JwtService();
            _registerDtoMock = new Mock<RegisterDto>();
        }

        [TestMethod]

        public void AuthShouldRegisterUser()
        {

            //Arrange
            string joel = "joel";
            var user = new User
            {
                Name = "mats",
                Email = "mats@mats.com",
                Password = BCrypt.Net.BCrypt.HashPassword(joel)
            };
            var dto = new RegisterDto
            {
                Email = "mats@mats.com",
                Name = "mats",
                Password = BCrypt.Net.BCrypt.HashPassword(joel)
            };
            _userRepositoryMock.Setup(x => x.Create(user));

            var reg = _registerDtoMock.Object;
               
            var authController = new AuthController(_userRepositoryMock.Object, _jwtService);
            
            //Act
            
            var register = authController.Register(dto);

            //Assert
            Assert.AreEqual(true, register );


        }

       
    }
}
