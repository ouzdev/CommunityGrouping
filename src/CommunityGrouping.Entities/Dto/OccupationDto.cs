using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities.Dto
{
    public class OccupationDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
