using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities.Dto.ApplicationUser
{
    public class ApplicationUserDto : IDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
