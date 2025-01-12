using FTL.User.Domain.Entities;

namespace FTL.User.Application.Abstractions.Services;

public interface IUserService
{
    Task<UserEntity> GetUserAsync(string userId);
}
