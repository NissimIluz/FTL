namespace FLT.Loan.Application.Abstractions.Services;

public interface ILoanInterestsCalculatorService
{
    decimal CalculateInterest(decimal amount, decimal primeRate);
}
