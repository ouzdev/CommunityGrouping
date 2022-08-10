using AutoMapper;
using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Core.Utilities.Security.Hashing;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly IUserService _applicationUserService;
        private readonly IUnitOfWork _unitOfWork;


        public AuthService(IUserService applicationUserService, ITokenHelper tokenHelper, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _applicationUserService = applicationUserService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> ChangePassword(string oldPassword, string newPassword, string confirmNewPassword, int userId)
        {
            var user = (await _applicationUserService.GetById(userId)).Data;
            if (!HashingHelper.VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorResult(Messages.OLD_PASSWORD_INCORRECT);

            }
            HashingHelper.CreatePasswordHash(newPassword, out byte[]? passwordHash, out byte[]? passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ModifiedDate = DateTime.UtcNow;
            var result = _applicationUserService.Update(user);
            await _unitOfWork.CompleteAsync();
            var response = _mapper.Map<ApplicationUserReadDto>(user);
            if (result.Success)
            {
                return new SuccessDataResult<ApplicationUserReadDto>(response, Messages.CHANGE_PASSWORD_SUCCESS);

            }
            return new ErrorResult(Messages.CHANGE_PASSWORD_ERROR);

        }
        public IDataResult<AccessToken> CreateAccessToken(ApplicationUser user)
        {
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TOKEN_GENERATE);
        }

        public async Task<IResult> UserExists(string mail)
        {
            var result = await _applicationUserService.GetByMail(mail);
            if (result.Success)
            {
                return new ErrorResult(Messages.USER_ALREADY_EXISTS);
            }
            return new SuccessResult(Messages.USER_NOTFOUND);
        }

        public async Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _applicationUserService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<AccessToken>(Messages.USER_NOTFOUND);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<AccessToken>(Messages.PASSWORD_INCORRECT);
            }
            var resultToken = CreateAccessToken(userToCheck.Data);
            if (resultToken.Success)
            {
                return new SuccessDataResult<AccessToken>(resultToken.Data, Messages.LOGIN_SUCCESS);
            }
            return new ErrorDataResult<AccessToken>(Messages.SYSTEM_ERROR);

        }
        public async Task<IDataResult<ApplicationUserReadDto>> Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = await UserExists(userForRegisterDto.Email);
            if (userExist.Success)
            {
                var user = _mapper.Map<ApplicationUser>(userForRegisterDto);
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[]? passwordHash, out byte[]? passwordSalt);
                user.LastActivity = DateTime.UtcNow;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.CreatedAt = DateTime.UtcNow;
                user.ModifiedDate = DateTime.UtcNow;
                await _applicationUserService.AddAsync(user);
                return new SuccessDataResult<ApplicationUserReadDto>(_mapper.Map<ApplicationUserReadDto>(user), Messages.REGISTER_USER);
            }

            return new ErrorDataResult<ApplicationUserReadDto>(Messages.USER_ALREADY_EXISTS);

        }
    }
}
