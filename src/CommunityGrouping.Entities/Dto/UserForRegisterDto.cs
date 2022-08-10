using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities.Dto
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
