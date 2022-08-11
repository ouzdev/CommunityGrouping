using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities
{
    public class Person :BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int OccupationId { get; set; }
    }
}
