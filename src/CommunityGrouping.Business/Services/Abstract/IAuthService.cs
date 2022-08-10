using CommunityGrouping.Core;
using CommunityGrouping.Entities.Dto;
using CommunityGrouping.Entities.Dto.ApplicationUser;

namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<ApplicationUserDto>> Register(UserForRegisterDto userForRegisterDto);
        Task<IResult> UserExists(string mail);
        Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);

    }
}
