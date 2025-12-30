using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using FluentValidation.Results;
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
            CreateUserRequestValidator validate = new();
            ValidationResult validateResult = validate.Validate(request);
            List<ValidationFailure> validateResultErrors = [.. validateResult.Errors];

            if (!validateResult.IsValid)
                return (user: null, errors: validateResultErrors);

            if (context.Users.Any(user => user.Email == request.Email))
            {
                validateResultErrors.Add(new ValidationFailure() { ErrorMessage = "Provided mail adress already in use." });
                return (user: null, errors: validateResultErrors);
            }

            User user = new()
            {
                Username = request.Name,
                Email = request.Email,
            };

            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(user, request.Password);
            user.PasswordHash = hashedPassword;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return (user, errors: null);
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
