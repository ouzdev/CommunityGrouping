using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityGrouping.Core.BaseModel;

namespace CommunityGrouping.Entities
{
    public class Occupation:BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
