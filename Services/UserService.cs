using UrlShortner.DTOs;
using UrlShortner.Models;

namespace UrlShortner.Services
{
    public class UserService : IUserService
    {
        private readonly UrlShortnerContext _context;

        public UserService(UrlShortnerContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(CreateUserRequest request)
        {
            // sem validação por enquanto
            var user = new User
            {
                Username = request.Name,
                Email = request.Email,
                PasswordHash = request.Password
            };

            await _context.Users.AddAsync(user);
            _context.SaveChanges();

            return user;
        }
    }
}
