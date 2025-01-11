using FLT.Loan.Application.Abstractions.Services;

namespace FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupC;

public class GroupCCalculator: ILoanInterestsCalculatorService
{
    public decimal CalculateInterest(decimal amount, decimal primeRate)
    {
        if (amount <= 15000)
        {
            return amount * (0.015m + primeRate);
        }
        else if (amount <= 30000)
        {
            return amount * (0.03m + primeRate);
        }
        else
        {
            return amount * 0.01m;
        }
    }
}
