using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityGrouping.Entities.QueryModel
{
    public class AddPersonToGroupQuery
    {
        public int PersonId { get; set; }
        public int GroupId { get; set; }
    }
}
