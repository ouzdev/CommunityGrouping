using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using CommunityGrouping.Tests.Fixtures;
using Moq;

namespace CommunityGrouping.Tests.Systems.Services
{
    public class TestPersonService
    {
        private readonly Mock<IPersonService> _personService;

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
        public async Task Update_Person()
        {
            _personService.Setup(s => s.UpdateAsync(1, It.IsAny<PersonDto>())).ReturnsAsync(new SuccessDataResult<PersonDto>());

            var result = await _personService.Object.UpdateAsync(1, new PersonDto()
            {
                Id = 1,
                FirstName = "Oğuzcan",
                LastName = "Genç",
                Email = "testmail@test.com",
                BirthDay = DateTime.UtcNow,
                PhoneNumber = "05511363566",
            });

            Assert.True(result.Success);
        }
        [Fact]
        public async Task Get_All_Person()
        {
            //Arrange
            _personService.Setup(s => s.GetAllAsync()).ReturnsAsync(new SuccessDataResult<IEnumerable<PersonDto>>());
            //Act
            var result = await _personService.Object.GetAllAsync();
            //Assert   
            Assert.True(result.Success);

        }
        [Theory]
        [InlineData(6)]
        public async Task Get_By_Id_Person(int id)
        {
            //Arrange
            _personService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => new SuccessDataResult<PersonDto>(PersonFixture.GetUserById(id)));
            //Act
            var result = await _personService.Object.GetByIdAsync(id);
            //Assert   
            Assert.True(result.Success);

        }
        [Fact]
        public async Task Insert_Person()
        {
            //Arrange
            _personService.Setup(s => s.InsertAsync(It.IsAny<PersonDto>())).ReturnsAsync(new SuccessDataResult<PersonDto>());
            //Act
            var result = await _personService.Object.InsertAsync(PersonFixture.GetPerson());
            //Assert   
            Assert.True(result.Success);

        }
        [Fact]
        public async Task Remove_Person()
        {
            //Arrange
            _personService.Setup(s => s.RemoveAsync(It.IsAny<int>())).ReturnsAsync(new SuccessDataResult<PersonDto>());
            //Act
            var result = await _personService.Object.RemoveAsync(1);
            //Assert   
            Assert.True(result.Success);

        }

    }
}
