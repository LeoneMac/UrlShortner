using Microsoft.EntityFrameworkCore;
using UrlShortner;
using UrlShortner.Application.Mapping.User;
using UrlShortner.Interfaces;
using UrlShortner.Services;

var builder = WebApplication.CreateSlimBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMvc();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("UrlShortnerDatabase");
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<UrlShortnerContext>(opt => opt.UseNpgsql(connectionString));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();


app.Run();
