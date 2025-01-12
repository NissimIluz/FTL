using FTL.User.Application.Abstractions.Services;
using FTL.User.Domain.Entities;
using FTL.User.Domain.Interfaces;

namespace FTL.User.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public  Task<UserEntity> GetUserAsync(string userId)
    {
        return _userRepository.GetUserAsync(userId);
    }
}
