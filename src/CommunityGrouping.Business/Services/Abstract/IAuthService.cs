﻿using CommunityGrouping.Core;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<ApplicationUserReadDto>> Register(UserForRegisterDto userForRegisterDto);
        Task<IResult> UserExists(string mail);
        Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);

    }
}