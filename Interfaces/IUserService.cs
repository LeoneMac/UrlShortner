using UrlShortner.Application.Dtos.User;
using UrlShortner.Models;

namespace UrlShortner.Interfaces
{
    public interface IUserService
    {
        Task<(User? user, List<FluentValidation.Results.ValidationFailure>? errors)> CreateAsync(CreateUserRequest request);
        Task<UserResponseDto?> GetByIdAsync(Guid id);
        Task<List<UserResponseDto>> GetUsers(int take, int startIndex);
    }
}
