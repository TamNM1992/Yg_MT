using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Data.Models
{
    public class TypeSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TypeSkill()
        {
            this.Skill = new HashSet<Skill>();
        }
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
