using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Core;
using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IBaseService<TReadDto,TWriteDto,TEntity>
    {
        Task<IDataResult<TReadDto>> GetByIdAsync(int id);
        Task<IDataResult<IEnumerable<TReadDto>>> GetAllAsync();
        Task<IDataResult<TReadDto>> InsertAsync(TWriteDto insertResource);
        Task<IDataResult<TReadDto>> UpdateAsync(int id, TWriteDto updateResource);
        Task<IDataResult<TReadDto>> RemoveAsync(int id);
    }
}
