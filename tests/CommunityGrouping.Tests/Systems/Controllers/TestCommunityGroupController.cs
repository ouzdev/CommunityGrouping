using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.API.Controllers;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Entities.Dto;
using CommunityGrouping.Tests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CommunityGrouping.Tests.Systems.Controllers
{
    public class TestCommunityGroupController
    {
        private readonly Mock<ICommunityGroupService> _testCommunityGroupService;
        public TestCommunityGroupController()
        {
            _testCommunityGroupService = new Mock<ICommunityGroupService>();
        }

        [Fact]
        public async Task Get_By_Id_Community_Group()
        {
            //Arrange
            _testCommunityGroupService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new SuccessDataResult<CommunityGroupDto>(CommunityGroupFixture.GetCommunityGroup()));

            var sut = new CommunityGroupController(_testCommunityGroupService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get(1);

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<CommunityGroupDto>>();
        }
        [Fact]
        public async Task Get_All_Community_Group()
        {
            //Arrange
            _testCommunityGroupService.Setup(x => x.GetAllAsync()).ReturnsAsync(new SuccessDataResult<IEnumerable<CommunityGroupDto>>(CommunityGroupFixture.GetCommunityGroups()));

            var sut = new CommunityGroupController(_testCommunityGroupService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<IEnumerable<CommunityGroupDto>>>();
        }
        
        [Fact]
        public async Task Get_Community_Group_With_Person()
        {
            //Arrange
            _testCommunityGroupService.Setup(x => x.GetCommunityGroupPeopleAsync(It.IsAny<int>())).ReturnsAsync(new SuccessDataResult<CommunityGroupPeopleDto>(CommunityGroupFixture.GetCommunityGroupsWitPerson()));

            var sut = new CommunityGroupController(_testCommunityGroupService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetGroupWithPerson(1);

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<CommunityGroupPeopleDto>>();
        }

        [Fact]
        public async Task Add_Community_Group()
        {
            //Arrange
            _testCommunityGroupService.Setup(x => x.InsertAsync(It.IsAny<CommunityGroupDto>())).ReturnsAsync(new SuccessDataResult<CommunityGroupDto>(CommunityGroupFixture.GetCommunityGroup()));

            var sut = new CommunityGroupController(_testCommunityGroupService.Object);

            // Act
            var result = (OkObjectResult)await sut.Post(CommunityGroupFixture.GetCommunityGroup());

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<CommunityGroupDto>>();
        }
        [Fact]
        public async Task Update_Community_Group()
        {
            //Arrange
            _testCommunityGroupService.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<CommunityGroupDto>())).ReturnsAsync(new SuccessDataResult<CommunityGroupDto>(CommunityGroupFixture.GetCommunityGroup()));

            var sut = new CommunityGroupController(_testCommunityGroupService.Object);

            // Act
            var result = (OkObjectResult)await sut.Put(1, CommunityGroupFixture.GetCommunityGroup());

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<CommunityGroupDto>>();
        }
        [Fact]
        public async Task Delete_Community_Group()
        {
            //Arrange
            _testCommunityGroupService.Setup(x => x.RemoveAsync(It.IsAny<int>())).ReturnsAsync(new SuccessDataResult<CommunityGroupDto>(CommunityGroupFixture.GetCommunityGroup()));

            var sut = new CommunityGroupController(_testCommunityGroupService.Object);

            // Act
            var result = (OkObjectResult)await sut.Delete(1);

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SuccessDataResult<CommunityGroupDto>>();
        }
    }
}
