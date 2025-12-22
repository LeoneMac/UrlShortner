using Microsoft.EntityFrameworkCore;

namespace UrlShortner
{
    public class UrlShortnerContext(DbContextOptions<UrlShortnerContext> options) : DbContext(options)
    {
        public DbSet<Models.User> Users { get; set; } = null!;
        public DbSet<Models.Url> Urls { get; set; } = null!;
    }
}
