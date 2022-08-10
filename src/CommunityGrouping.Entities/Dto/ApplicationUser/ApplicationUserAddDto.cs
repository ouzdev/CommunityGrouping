using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities.Dto.ApplicationUser
{
    internal class ApplicationUserAddDto : IDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
