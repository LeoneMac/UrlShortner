using AutoMapper;

namespace UrlShortner.Application.Mapping.Url
{
    public class UrlProfile : Profile
    {
        public UrlProfile()
        {
            CreateMap<Models.Url, Dtos.Url.UrlDto>();
        }
    }
}
