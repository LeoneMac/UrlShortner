namespace UrlShortner.Application.Dtos.User
{
    public record CreateUserRequest(string Email, string Password, string Name);
}