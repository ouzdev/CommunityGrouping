using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;
using Moq;

namespace CommunityGrouping.Tests.Systems.Controllers
{
    public class TestAuthController
    {
        Mock<IAuthService> _testAuthService;
        public TestAuthController()
        {
            _testAuthService = new Mock<IAuthService>();
        }
        [Fact]
        public async Task Login()
        {
            _testAuthService.Setup(x => x.Login(It.IsAny<UserLoginDto>())).ReturnsAsync(new SuccessDataResult<AccessToken>(getAccessToken()));

            var result = await _testAuthService.Object.Login(new UserLoginDto()
            {
                Email = "oguzcangencc@hotmail.com",
                Password = "Etj810c222"
            });

            Assert.True(result.Success);
        }
        [Fact]
        public async Task Register()
        {
            _testAuthService.Setup(x => x.Register(It.IsAny<UserForRegisterDto>())).ReturnsAsync(new SuccessDataResult<ApplicationUserDto>(getApplicationUser()));

            var result = await _testAuthService.Object.Register(new UserForRegisterDto()
            {
                Email = "oguzcangencc@hotmail.com",
                Password = "Etj810c222",
                ConfirmPassword = "Etj810c222",
                FirstName = "Oguz",
                LastName = "Genç"
            });

            Assert.True(result.Success);
        }
        private AccessToken getAccessToken()
        {
            return new AccessToken()
            {
                Expiration = DateTime.Now.AddDays(1),
                Token = "token"
            };
        }
        private ApplicationUserDto getApplicationUser()
        {
            return new ApplicationUserDto()
            {
                Id = 1,
                Email = "oguzcangencc@hotmail.com",
                CreatedAt = DateTime.Now,
                FirstName = "Oğuzcan",
                LastName = "Genç",
                ModifiedDate = DateTime.Now,
            };
        }

    }
}
