namespace UrlShortner.DTOs
{
    public record CreateUserRequest(string Email, string Password, string Name);
}