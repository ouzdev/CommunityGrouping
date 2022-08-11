using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities
{
    public class ApplicationUser : User, IEntity
    {
        
        public virtual ICollection<CommunityGroup> CommunityGroups { get; set; }
    }
}
