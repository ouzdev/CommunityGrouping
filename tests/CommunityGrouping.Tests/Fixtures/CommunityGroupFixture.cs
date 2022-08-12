using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Tests.Fixtures
{
    public static class CommunityGroupFixture
    {
        public static CommunityGroupDto GetCommunityGroup()
        {
            return new CommunityGroupDto()
            {
                Id = 1,
                Name = "Test Community Group",
                Description = "Test Community Group Description"
            };
        }

        public static CommunityGroupPeopleDto GetCommunityGroupsWitPerson() =>
            new CommunityGroupPeopleDto()
            {

                Id = 1,
                Name = "Test Community Group",
                Description = "Test Community Group Description",

                People = new List<PersonDto>()
                {
                    new PersonDto()
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        BirthDay = new DateTime(1980, 1, 1)
                    },
                    new PersonDto()
                    {
                        Id = 2,
                        FirstName = "Jane",
                        LastName = "Doe",
                        BirthDay = new DateTime(1980, 1, 1)
                    }
                }



            };

        public static IEnumerable<CommunityGroupDto> GetCommunityGroups() => new List<CommunityGroupDto>()
        {
            new CommunityGroupDto()
            {
                Id = 1,
                Name = "Test Community Group",
                Description = "Test Community Group Description"
            },
            new CommunityGroupDto()
            {
                Id = 2,
                Name = "Test Community Group 2",
                Description = "Test Community Group Description 2"
            },
            new CommunityGroupDto()
            {
                Id = 3,
                Name = "Test Community Group 3",
                Description = "Test Community Group Description 3"
            },
            new CommunityGroupDto()
            {
                Id = 4,
                Name = "Test Community Group 4",
                Description = "Test Community Group Description 4"
            },
            new CommunityGroupDto()
            {
                Id = 5,
                Name = "Test Community Group 5",
                Description = "Test Community Group Description 5"
            },
            new CommunityGroupDto()
            {
                Id = 6,
                Name = "Test Community Group 6",
                Description = "Test Community Group Description 6"
            },
            new CommunityGroupDto()
            {
                Id = 7,
                Name = "Test Community Group 7",
                Description = "Test Community Group Description 7"
            },
            new CommunityGroupDto()
            {
                Id = 8,
                Name = "Test Community Group 8",
                Description = "Test Community Group Description 8"
            },
            new CommunityGroupDto()
            {
                Id = 9,
                Name = "Test Community Group 9",
                Description = "Test Community Group Description 9"
            }

        };
    }
}
