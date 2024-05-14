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
using API.DTO;
using System.Linq;

namespace SocialAppTest
{
    [TestClass]
    public class PostControllerTest
    {
        private IMapper _mapper;
        private Mock<IPostRepository<Posts>>_postRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;

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
            _userRepositoryMock = new Mock<IUserRepository>();
             
             var builder = new DbContextOptionsBuilder<UserContext>();
             builder.UseInMemoryDatabase("d");
            var options = builder.Options;
            _context = new UserContext(options);
            
            
        }

    [TestMethod]

    public async Task ShouldGetAllPostFromControllerAsync()
        {
            _postRepositoryMock.Setup(x => x.ListAllAsync())
                .ReturnsAsync(new List<Posts>
                {
                  new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Look I made a post",
                        },
                   new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Look mommy I made a post",
                        },
                   new Posts
                        {
                            Date = DateTime.Now,
                            Description = "I eAT ProTiEN",
                        },
                   new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Music 'n' Shit",
                        },
                   new Posts
                        {
                            Date = DateTime.Now,
                            Description = "Look I Teach and Stuff",
                        }
                });
            var postController = new PostsController(_context, _postRepositoryMock.Object, _mapper, _userRepositoryMock.Object );

            //Act
            var posts = await postController.GetPosts();

            //Assert
            Assert.AreEqual(5,posts.Posts.Count);
        }
        //Fr�ga Robert
    [TestMethod]

        public void ShouldCreateNewPost()
        {
            ////Arrange
            var post = new Posts()
            {
                Description = "dad"

            };


            var postCreatedDto = _mapper.Map<PostDTO>(post);

            //Act

            var postController = new PostsController(_context, _postRepositoryMock.Object, _mapper, _userRepositoryMock.Object);
            var postcont =  postController.CreatePost(postCreatedDto);
            var result = postcont.Id;
            //Assert


            Assert.AreEqual(1, result);
        }
    };
}