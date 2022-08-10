using CommunityGrouping.Business.Constant;
using CommunityGrouping.Business.Services.Abstract;
using CommunityGrouping.Core;
using CommunityGrouping.Data.Repositories.Abstract;
using CommunityGrouping.Data.Repositories.UnitOfWork;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> AddAsync(ApplicationUser user)
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return new SuccessResult(Messages.ADD_APPLICATON_USER);

        }
        public async Task<IResult> Delete(ApplicationUser user)
        {
            _userRepository.Delete(user);
            await _unitOfWork.CompleteAsync();

            return new SuccessResult(Messages.DELETE_APPLICATION_USER);
        }
        public async Task<IDataResult<ApplicationUser>> GetById(int id)
        {
            var response = await _userRepository.GetByIdAsync(id);
            if (response == null)
            {
                return new ErrorDataResult<ApplicationUser>();
            }
            return new SuccessDataResult<ApplicationUser>(response, Messages.GET_APPLICATION_USER);
        }
        public async Task<IDataResult<ApplicationUser>> GetByMail(string mail)
        {
            var response = await _userRepository.GetAsync(user => user.Email == mail);
            if (response == null)
            {
                return new ErrorDataResult<ApplicationUser>();
            }
            return new SuccessDataResult<ApplicationUser>(response);
        }
        public async Task<IDataResult<ApplicationUser>> GetByMailAndUsername(string mail, string username)
        {
            var response = await _userRepository.GetAsync(user => user.Email == mail);
            if (response == null)
            {
                return new ErrorDataResult<ApplicationUser>();
            }
            return new SuccessDataResult<ApplicationUser>();
        }
        public IResult Update(ApplicationUser user)
        {
            _userRepository.Update(user);
            return new SuccessDataResult<ApplicationUser>(user);
        }
    }
}
