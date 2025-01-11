namespace FLT.Loan.Application.Abstractions.Services;

public interface ILoanInterestsCalculatorFactory
{
    ILoanInterestsCalculatorService GetProcessor(int clientAge);
}
