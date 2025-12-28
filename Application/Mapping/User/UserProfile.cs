using AutoMapper;
using UrlShortner.Application.Dtos.User;

namespace UrlShortner.Application.Mapping.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, UserResponseDto>();
            CreateMap<CreateUserRequest, Models.User>();
        }
    }
}
