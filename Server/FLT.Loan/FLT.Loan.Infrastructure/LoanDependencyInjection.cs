using FLT.Loan.Application.Abstractions.Services;
using FLT.Loan.Application.Options;
using FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator;
using FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupA;
using FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupB;
using FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupC;
using FLT.Loan.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FLT.Loan.Infrastructure;

public static class LoanDependencyInjection
{
    public static void AddLoanInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ILoanInterestsService, LoanInterestsService>();
        services.AddScoped<ILoanInterestsCalculatorFactory, LoanInterestsCalculatorFactory>();
        services.AddScoped<GroupACalculator>();
        services.AddScoped<GroupBCalculator>();
        services.AddScoped<GroupCCalculator>();

        services.AddOptions<ApplicationLoanGroupsOptions>(configuration);
        services.AddOptions<ApplicationLoanInterestsOption>(configuration);

    }


    public static void AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration, string? key = null) where TOptions : class
    {
        IConfigurationSection configurationSection = configuration.GetSection(key ?? typeof(TOptions).Name);
        services.Configure<TOptions>(configurationSection);
    }
}
