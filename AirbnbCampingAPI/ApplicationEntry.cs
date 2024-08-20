
using AirbnbCamping.Services.Database.CampingServices.Database;
using AirbnbCamping.Services.Database.UserServices.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace AirbnbCamping;

public class ApplicationEntry
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register services
        builder.Services.AddCors();
        builder.Services.AddAuthentication("SimpleAuthScheme")
        .AddScheme<AuthenticationSchemeOptions, SimpleAuthHandler>("SimpleAuthScheme", null);

        builder.Services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        });

        builder.Services.AddDbContext<CampingDbContext>();
        builder.Services.AddDbContext<UserDbContext>();

        builder.Services.AddServices.Controllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();
        app.UseCors(corsPolicyBuilder =>
            corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapServices.Controllers();

        app.Run();
    }
}
