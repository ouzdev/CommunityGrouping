using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Tests.Fixtures
{
    public static class UserFixture
    {
        public static ApplicationUser GetTestUser() => new ApplicationUser
        {
            Id = 1,
            FirstName = "Test First Name",
            LastName = "Test Last Name",
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
            Email = "test@test.com",
            LastActivity = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            PasswordHash = new byte[123],
            PasswordSalt = new byte[1234]
        };
    }
}
