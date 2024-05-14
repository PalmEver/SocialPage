using API.Controllers;
using Application;
using Application.Core;
using Application.PostEntries;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SocialAppTest
{
    [TestClass]
    public class UserControllerTest
    {

        private UserContext _context;
        private  Mock<UserController> _userControllerMock;
        private Mock<IUserRepository> _userRepositoryMock;
        
     

        [TestInitialize]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            var mapper = mappingConfig.CreateMapper();
            
            var builder = new DbContextOptionsBuilder<UserContext>();
            builder.UseInMemoryDatabase("d");
            var options = builder.Options;
            _context = new UserContext(options);
            _userControllerMock = new Mock<UserController>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [TestMethod]

        public void ShouldGetAllUsers()
        {

            
            var comparingList = new List<User>() { new User { Id = 1, Name = "mats", Email = "mats@mats.com" }, new User { Id = 2, Name = "karl", Email = "karl@karl.com" } }.AsQueryable();


            //Arrange
            _userRepositoryMock.Setup(x => x.GetAllUsers())
                .Returns(comparingList);

            //Act
            var userController = new UserController(_userRepositoryMock.Object, _context);
            var user = userController.GetAllUsers();
            //Assert
            Assert.AreEqual(true, user.GetEnumerator().MoveNext());




        }

    }
}
