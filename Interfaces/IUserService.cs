using Microsoft.AspNetCore.Mvc;
using UrlShortner.Application.Dtos.User;
using UrlShortner.Models;

namespace UrlShortner.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserRequest request);
        Task<UserResponseDto?> GetByIdAsync(Guid id);
        Task<List<UserResponseDto>> GetUsers(int take, int startIndex);
    }
}
