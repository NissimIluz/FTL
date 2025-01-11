using FLT.Loan.Application.Abstractions.Services;
using FTL.User.Domain.Entities;
using FLT.Kernel.Infrastructure.Extensions;
using FLT.Loan.Application.Options;
using Microsoft.Extensions.Options;

namespace FLT.Loan.Infrastructure.Services;

public class LoanInterestsService : ILoanInterestsService
{
    private readonly ILoanInterestsCalculatorFactory _loanInterestsCalculatorFactory;
    private readonly ApplicationLoanInterestsOption _applicationLoanInterestsOption;

    public LoanInterestsService(ILoanInterestsCalculatorFactory loanInterestsCalculatorFactory, IOptionsSnapshot<ApplicationLoanInterestsOption> optionsSnapshot)
    {
        _loanInterestsCalculatorFactory = loanInterestsCalculatorFactory;
        _applicationLoanInterestsOption = optionsSnapshot.Value;
    }

    public decimal CalculateInterest(UserEntity userEntity, decimal amount, int periodInMonth)
    {
        ILoanInterestsCalculatorService loanInterestsCalculatorService = 
            _loanInterestsCalculatorFactory
            .GetProcessor(userEntity.BirthDate.YearsSince());

        decimal loanInterest = loanInterestsCalculatorService.CalculateInterest(amount, _applicationLoanInterestsOption.PrimeRate);

        if(periodInMonth > _applicationLoanInterestsOption.MinPeriodInMonth)
        {
            loanInterest = loanInterest +
                (amount * (_applicationLoanInterestsOption.AbnormalInterestRate) * (periodInMonth - _applicationLoanInterestsOption.MinPeriodInMonth));
        }

        return amount + loanInterest;
    }
}
