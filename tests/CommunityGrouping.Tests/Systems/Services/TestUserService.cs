using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Tests.Fixtures;
using FluentAssertions;
using Moq;

namespace CommunityGrouping.Tests.Systems.Services
{
    public class TestUserService
    {
      

        [Fact]
        public async void Add_Application_User()
        {
            var mock = new Mock<IUserService>();
            //Arrange
            mock.Setup(p => p.AddAsync(UserFixture.GetTestUser())).ReturnsAsync(new SuccessResult(Messages.ADD_APPLICATON_USER));
            //Act
            var result = await mock.Object.AddAsync(UserFixture.GetTestUser());
            //Assert

            result.Success.Should().BeTrue();
        }
    }
}
