using CommunityGrouping.Core;
using CommunityGrouping.Entities;

namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<IResult> AddAsync(ApplicationUser user);
        IResult Update(ApplicationUser user);
        Task<IResult> Delete(ApplicationUser user);
        Task<IDataResult<ApplicationUser>> GetById(int id);
        Task<IDataResult<ApplicationUser>> GetByMail(string mail);
        Task<IDataResult<ApplicationUser>> GetByMailAndUsername(string mail, string username);
    }
}
