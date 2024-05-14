using API.Controllers;
using Application;
using Application.Core;
using Application.PostEntries;
using AutoMapper;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Follow;
using API.DTO;

namespace SocialAppTest
{
    [TestClass]
    public class FollowControllerTest
    {
        private IMapper _mapper;
        private Mock<IPostRepository<Posts>> _postRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IFollowRepository<Followers>> _followRepositoryMock;
        private UserContext _context;
       



        [TestInitialize]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            _postRepositoryMock = new Mock<IPostRepository<Posts>>();
            _followRepositoryMock= new Mock<IFollowRepository<Followers>>();
            _userRepositoryMock = new Mock<IUserRepository>();

            var builder = new DbContextOptionsBuilder<UserContext>();
            builder.UseInMemoryDatabase("d");
            var options = builder.Options;
            _context = new UserContext(options);

        }


        //Fråga Robert Varför blir dto "NULL"
        [TestMethod]

        public void ShouldPostNewFollow()
        {
            //Arrange
            var follower = new Followers();
            var follow = new Followers()
            {
                Id = Guid.NewGuid(),
                FollowId = 1,
                User = new User()
            };
            
            var followCreated =  _followRepositoryMock.Setup(p => p.CreateAsync(follower)).ReturnsAsync(follow);
           var dto = new FollowDto();
            //Act
            var followController = new FollowController(_followRepositoryMock.Object, _mapper, _userRepositoryMock.Object, _context);
            var followDto =  followController.FollowUser(dto);
            var result = followDto.Id;
            //Assert
            Assert.AreEqual(1, result);

        }

    }
}