namespace CommunityGrouping.Core.BaseModel
{
    public class User : BaseEntity, IEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime LastActivity { get; set; }


    }
}