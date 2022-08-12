
using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities.Dto
{
    public class PersonDto :IDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Occupation { get; set; }
    }
}
