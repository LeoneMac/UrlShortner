using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UrlShortner.Application.Dtos.User;
using UrlShortner.Interfaces;
using UrlShortner.Models;

namespace UrlShortner.Services
{
    public class UserService(UrlShortnerContext context, IMapper mapper) : IUserService
    {
        public async Task<User> CreateAsync(CreateUserRequest request)
        {
            // TODO Pedro: Add validation and error handling AND THE PASSWORD HASHING I TOLD YOU
            var user = new User
            {
                Username = request.Name,
                Email = request.Email,
                PasswordHash = request.Password
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<UserResponseDto?> GetByIdAsync(Guid id)
        {
            return await context.Users
                .Where(u => u.Id == id)
                .ProjectTo<UserResponseDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserResponseDto>> GetUsers(int take, int startIndex)
        {
            return await context.Users
                .Skip(startIndex)
                .Take(take)
                .ProjectTo<UserResponseDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
