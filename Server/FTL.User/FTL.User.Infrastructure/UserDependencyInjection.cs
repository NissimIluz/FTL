using FTL.User.Application.Abstractions.Services;
using FTL.User.Domain.Interfaces;
using FTL.User.Infrastructure.Services;
using FTL.User.Infrastructure.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FTL.User.Infrastructure;

public static class UserDependencyInjection
{
    public static void AddUserInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, MockUpUserRepository>();
    }
}
