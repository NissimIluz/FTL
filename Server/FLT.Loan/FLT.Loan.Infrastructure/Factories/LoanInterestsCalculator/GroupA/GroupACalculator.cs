using FLT.Loan.Application.Abstractions.Services;

namespace FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupA
{
    public class GroupACalculator: ILoanInterestsCalculatorService
    {
        public decimal CalculateInterest(decimal amount, decimal primeRate)
        {
            return amount * (0.02m + primeRate);
        }
    }
}
