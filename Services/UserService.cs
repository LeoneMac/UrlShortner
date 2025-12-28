using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UrlShortner.Application.Dtos.User;
using UrlShortner.Interfaces;
using UrlShortner.Models;
using UrlShortner.Validators;

namespace UrlShortner.Services
{
    public class UserService(UrlShortnerContext context, IMapper mapper) : IUserService
    {
        public async Task<(User? user, List<FluentValidation.Results.ValidationFailure>? errors)> CreateAsync(CreateUserRequest request)
        {
            var validate = new CreateUserRequestValidator();
            var validateResult = validate.Validate(request);

            if (!validateResult.IsValid)
                return (null, validateResult.Errors.ToList());

            var passwordHasher = new PasswordHasher<User>();
            var user = new User
            {
                Username = request.Name,
                Email = request.Email,
            };

            var hashedPassword = passwordHasher.HashPassword(user, request.Password);
            user.PasswordHash = hashedPassword;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return (user, null);
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
