using FTL.User.Domain.Entities;
using FTL.User.Domain.Interfaces;

namespace FTL.User.Infrastructure.Services.Repositories;

public class MockUpUserRepository : IUserRepository
{
    private readonly ICollection<UserEntity> _mockUpUsers = new List<UserEntity>
    {
        // Users under 20 years old
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), BirthDate = DateTime.Now.AddYears(-15) },
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"), BirthDate = DateTime.Now.AddYears(-18) },
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000003"), BirthDate = DateTime.Now.AddYears(-19) },

        // Users between 20 and 35 years old
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000004"), BirthDate = DateTime.Now.AddYears(-25) },
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000005"), BirthDate = DateTime.Now.AddYears(-30) },
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000006"), BirthDate = DateTime.Now.AddYears(-35) },

        // Users over 35 years old
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000007"), BirthDate = DateTime.Now.AddYears(-40) },
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000008"), BirthDate = DateTime.Now.AddYears(-50) },
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000009"), BirthDate = DateTime.Now.AddYears(-60) },

        // User aged 1000 years
        new UserEntity { UserId = Guid.Parse("00000000-0000-0000-0000-000000000010"), BirthDate = DateTime.Now.AddYears(-1000) }
    };

    public async Task<UserEntity> GetUserAsync(string userId)
    {
        return _mockUpUsers.FirstOrDefault(user => user.UserId.ToString() == userId)
               ?? throw new KeyNotFoundException("User not found.");
    }
}
