using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Entities.Dto.Person;
using Moq;

namespace CommunityGrouping.Tests.Systems.Services
{
    public class TestPersonService
    {
        Mock<IPersonService> _personService;
        public TestPersonService()
        {
            _personService = new Mock<IPersonService>();
        }
        [Fact]
        public async Task Add_Person()
        {
            _personService.Setup(x => x.InsertAsync(It.IsAny<PersonDto>())).ReturnsAsync(new SuccessDataResult<PersonDto>());

            var result = await _personService.Object.InsertAsync(new PersonDto()
            {
                FirstName = "Oğuzcan",
                LastName = "Genç",
                Email = "TestEmail@gmail.com"
            });

            Assert.True(result.Success);
        }
        [Fact]
        public  void Update_Person()
        {
            _personService.Setup(x => x.Update(It.IsAny<PersonReadDto>())).Returns(new SuccessResult());

            var result = _personService.Object.Update(new PersonReadDto()
            {
                Id = 1,
                FirstName = "Oğuzcan",
                LastName = "Genç",
                Email = "testmail@test.com",
                Birthday = DateTime.UtcNow,
                OccupationId = 1,
                PhoneNumber = "05511363566"
            });

            Assert.True(result.Success);
        }
    }
}
