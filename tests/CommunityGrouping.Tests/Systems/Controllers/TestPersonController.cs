using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.API.Controllers;
using CommunityGrouping.Business.Filters;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using CommunityGrouping.Entities.QueryModel;
using CommunityGrouping.Tests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CommunityGrouping.Tests.Systems.Controllers
{
    public class TestPersonController
    {
        private readonly Mock<IPersonService> _testPersonService;
        private readonly PersonController _personController;
        public TestPersonController()
        {
          
            _testPersonService = new Mock<IPersonService>();
        }

        [Fact]
        public async Task Get_By_Id_Person()
        {
            //Arrange
            _testPersonService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new SuccessDataResult<PersonDto>(PersonFixture.GetPerson()));

            var sut = new PersonController(_testPersonService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get(1);

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<PersonDto>>();            
        }
        [Fact]
        public async Task Add_Person()
        {
            //Arrange
            _testPersonService.Setup(x => x.InsertAsync(It.IsAny<PersonDto>())).ReturnsAsync(new SuccessDataResult<PersonDto>(PersonFixture.GetPerson()));

            var sut = new PersonController(_testPersonService.Object);

            // Act
            var result = (OkObjectResult)await sut.Post(PersonFixture.GetPerson());

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<PersonDto>>();
        }
        [Fact]
        public async Task Update_Person()
        {
            //Arrange
            _testPersonService.Setup(x => x.UpdateAsync(It.IsAny<int>(),It.IsAny<PersonDto>())).ReturnsAsync(new SuccessDataResult<PersonDto>(PersonFixture.GetPerson()));

            var sut = new PersonController(_testPersonService.Object);

            // Act
            var result = (OkObjectResult)await sut.Put(1, PersonFixture.GetPerson());

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<PersonDto>>();
        }
        [Fact]
        public async Task Delete_Person()
        {
            //Arrange
            _testPersonService.Setup(x => x.RemoveAsync(It.IsAny<int>())).ReturnsAsync(new SuccessDataResult<PersonDto>(PersonFixture.GetPerson()));

            var sut = new PersonController(_testPersonService.Object);

            // Act
            var result = (OkObjectResult)await sut.Delete(1);

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<PersonDto>>();
        }
        [Fact]
        public async Task Add_Person_To_Community_Group()
        {
            //Arrange
            _testPersonService.Setup(x => x.AddPersonToCommunityGroup(It.IsAny<AddPersonToGroupQuery>())).ReturnsAsync(new SuccessDataResult<PersonDto>(PersonFixture.GetPerson()));

            var sut = new PersonController(_testPersonService.Object);

            // Act
            var result = (OkObjectResult)await sut.AddPersonToCommunityGroup(new AddPersonToGroupQuery { GroupId = 1, PersonId = 1 });

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<PersonDto>>();
        }
    }
}
