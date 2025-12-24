using UrlShortner.DTOs;
using UrlShortner.Models;

namespace UrlShortner.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserRequest request);
    }
}
