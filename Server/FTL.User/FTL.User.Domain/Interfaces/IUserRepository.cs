using FTL.User.Domain.Entities;

namespace FTL.User.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserAsync(string userId);
    }
}
