using CommunityGrouping.Core.BaseModel;
namespace CommunityGrouping.Entities.Dto;

public class CommunityGroupPeopleDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<PersonDto>? People { get; set; }
}