using CommunityGrouping.Entities;
using CommunityGrouping.Entities.Dto.Person;


namespace CommunityGrouping.Business.Services.Abstract
{
    public interface IPersonService:IBaseService<PersonReadDto,PersonWriteDto,Person>
    {
        
    }
}
