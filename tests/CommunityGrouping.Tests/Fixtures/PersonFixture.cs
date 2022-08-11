using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Tests.Fixtures
{
    public static class PersonFixture
    {
        public static PersonDto GetPerson()
        {
            return new PersonDto()
            {
                Id = 1,
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                BirthDay = DateTime.UtcNow,
                PhoneNumber = "05511363566",
                Email = "test@test.com"
            };
        }
        public static IEnumerable<PersonDto> GetTestPersons() => new List<PersonDto>()
        {
            new PersonDto()
            {
                Id = 1,
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                BirthDay = DateTime.UtcNow,
                PhoneNumber = "05511363566",
                Email = "test@test.com",
            },
            new PersonDto()
            {
                Id = 2,
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                BirthDay = DateTime.UtcNow,
                PhoneNumber = "05511363566",
                Email = "test@test.com"
            },
            new PersonDto()
            {
                Id = 3,
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                BirthDay = DateTime.UtcNow,
                PhoneNumber = "05511363566",
                Email = "test@test.com"
            },
            new PersonDto()
            {
                Id = 4,
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                BirthDay = DateTime.UtcNow,
                PhoneNumber = "05511363566",
                Email = "test@test.com",
            }
        };

        public static PersonDto GetUserById(int id)
        {
            var person = GetTestPersons().FirstOrDefault(x => x.Id == id);
            return person;
        }
    }
}

