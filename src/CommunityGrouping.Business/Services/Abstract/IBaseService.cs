using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IBaseService<TDto,TEntity>
    {
        Task<IDataResult<TDto>> GetByIdAsync(int id);
        Task<IDataResult<IEnumerable<TDto>>> GetAllAsync();
        Task<IDataResult<TDto>> InsertAsync(TDto insertResource);
        Task<IDataResult<TDto>> UpdateAsync(int id, TDto updateResource);
        Task<IDataResult<TDto>> RemoveAsync(int id);
    }
}
