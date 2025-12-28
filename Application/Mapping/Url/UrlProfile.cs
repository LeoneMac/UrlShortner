using AutoMapper;
using UrlShortner.Application.Dtos.Url;

namespace UrlShortner.Application.Mapping.Url
{
    public class UrlProfile : Profile
    {
        public UrlProfile()
        {
            CreateMap<Models.Url, UrlDto>();
            CreateMap<Models.Url, UrlDto>().ForMember(d => d.UserId, o => o.MapFrom(s => s.User.Id));
        }
    }
}
