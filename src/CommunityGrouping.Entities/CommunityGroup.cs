using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities
{
    public class CommunityGroup:BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual  ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
