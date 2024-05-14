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
using Application.Message;

namespace SocialAppTest
{
    [TestClass]
    public class MessageControllerTest
    {
         private Mock<IUserRepository> _userRepositoryMock;
        
        private Mock<IMessageRepository<Messages>> _messageRepositoryMock;

        private UserContext _context;

        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
           var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _messageRepositoryMock = new Mock<IMessageRepository<Messages>>();
            _userRepositoryMock = new Mock<IUserRepository>();
            var builder = new DbContextOptionsBuilder<UserContext>();
            builder.UseInMemoryDatabase("d");
            var options = builder.Options;
            _context = new UserContext(options);

            //FR�GA ROBERTO IFALL DETTA �R OK hur ska vi test IQueryable
        }
        [TestMethod]
        public void ShouldGetMessagesBetweenTwoUsers()
        {
            var comparingList = new List<Messages>() { new Messages { Id = new Guid(), Name = "mats", Date=new DateTime(), User=new User(), Message ="dwa", MessageId=1 }, 
                new Messages { Id = new Guid(), Name = "mats", Date = new DateTime(), User = new User(), Message = "dwa", MessageId = 2 } }.AsQueryable();
            
            _messageRepositoryMock.Setup(m => m.GetMessagesBetweenTwoUsers(1, 2)).Returns(comparingList);
            
            var messageController = new MessageController(_messageRepositoryMock.Object,_mapper,_context,_userRepositoryMock.Object);
            var result = messageController.GetMessagesByMessageIdAndUserId(1,2);
            

            Assert.AreEqual(true, result.GetEnumerator().MoveNext());
         
        }

        //Fr�ga Robert 
        [TestMethod]

        public void ShouldCreateMessage()
        {
            //Arrange
            var message = new Messages()
            {
                Message = "hej Robert....Kompis",
               
            };
         
            var postCreatedDto = _mapper.Map<MessageDto>(message);

            //Act
            var messageController = new MessageController(_messageRepositoryMock.Object, _mapper,_context, _userRepositoryMock.Object);
            var messageAwait =  messageController.MessageUser(postCreatedDto);
            var result = messageAwait.Id;
            //Assert


            Assert.AreEqual(1, result);
        }

    }


}

