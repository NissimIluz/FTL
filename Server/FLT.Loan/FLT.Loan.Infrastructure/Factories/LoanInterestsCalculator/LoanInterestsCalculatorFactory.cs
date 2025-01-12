using FLT.Loan.Application.Abstractions.Services;
using FLT.Loan.Application.Options;
using FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupA;
using FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupB;
using FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupC;
using Microsoft.Extensions.Options;

namespace FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator;

public class LoanInterestsCalculatorFactory: ILoanInterestsCalculatorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ApplicationLoanGroupsOptions _applicationLoanGroupsOptions;
    private short GroupA { get { return _applicationLoanGroupsOptions.AAge; } }
    private short GroupB { get { return _applicationLoanGroupsOptions.BAge; } }


    public LoanInterestsCalculatorFactory(IServiceProvider serviceProvider, IOptionsSnapshot<ApplicationLoanGroupsOptions> optionsSnapshot)
    {
        _serviceProvider = serviceProvider;
        _applicationLoanGroupsOptions = optionsSnapshot.Value;
    }

    public ILoanInterestsCalculatorService GetProcessor(int clientAge)
    {
        if(clientAge < GroupA)
        {
            return (ILoanInterestsCalculatorService)_serviceProvider.GetService(typeof(GroupACalculator));
        }
        else if(clientAge < GroupB )

        {
            return (ILoanInterestsCalculatorService)_serviceProvider.GetService(typeof(GroupBCalculator));
        }
        else
        {
            return (ILoanInterestsCalculatorService)_serviceProvider.GetService(typeof(GroupCCalculator));
        }
    }
}
