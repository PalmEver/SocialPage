using API.DTO;
using Application;
using Application.Message;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class MessageController : BaseApiController
    {
        //Test ny controller


        private readonly IMessageRepository<Messages> _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserContext _context;
      

        public MessageController(
          
            IMessageRepository<Messages> messageRepository,
            IMapper mapper,
            UserContext context,
            IUserRepository userRepository)
            
        {
            
            _messageRepository = messageRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _context = context;

            
        }


        [HttpGet("{userId}/{messageId}")]
        public IQueryable GetMessagesByMessageIdAndUserId(int userId, int messageId)
        {
            var messages = _messageRepository.GetMessagesBetweenTwoUsers(userId, messageId);
            return messages;
        }

        [HttpPost]
        public async Task<MessageDto> MessageUser(MessageDto messageDto)
        {
            var message = _mapper.Map<Messages>(messageDto);
            var user = _userRepository.GetById(messageDto.UserId);

            if (user != null)
                message.User = user;

            var messageCreated = await _messageRepository.CreateAsync(message);
            var messageCreatedDto = _mapper.Map<MessageDto>(messageCreated);

            return messageCreatedDto;
        }
    }
}