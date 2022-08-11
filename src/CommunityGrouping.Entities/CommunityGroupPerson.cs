using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityGrouping.Entities
{
    public class CommunityGroupPerson
    {
        public int CommunityGroupId { get; set; }
        public CommunityGroup CommunityGroup { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
