using API.DTO;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Posts, Posts>();
            CreateMap<Posts, PostDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Followers, FollowersDto>().ReverseMap();
            CreateMap<Followers, FollowDto>().ReverseMap();
            CreateMap<Messages, Messages>();
            CreateMap<Messages, MessageDto>().ReverseMap();
        }
    }
}