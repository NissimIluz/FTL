using FLT.Loan.Application.Abstractions.Services;

namespace FLT.Loan.Infrastructure.Factories.LoanInterestsCalculator.GroupB
{
    public class GroupBCalculator: ILoanInterestsCalculatorService
    {
        public decimal CalculateInterest(decimal amount, decimal primeRate)
        {
            if (amount <= 5000)
            {
                return amount * 0.02m;
            }
            else if (amount <= 30000)
            {
                return amount * (0.015m + primeRate);
            }
            else
            {
                return amount * (0.01m + primeRate);
            }
        }
    }
}


