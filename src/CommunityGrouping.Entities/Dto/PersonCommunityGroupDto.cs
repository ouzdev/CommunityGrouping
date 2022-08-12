using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityGrouping.Entities.Dto
{
    public class PersonCommunityGroupDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Occupation { get; set; }
        public CommunityGroupDto CommunityGroupDto { get; set; }
    }
}
