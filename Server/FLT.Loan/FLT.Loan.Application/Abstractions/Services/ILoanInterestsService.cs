using FTL.User.Domain.Entities;

namespace FLT.Loan.Application.Abstractions.Services
{
    public interface ILoanInterestsService
    {
        decimal CalculateInterest(UserEntity userEntity, decimal amount, int periodInMonth);
    }
}
