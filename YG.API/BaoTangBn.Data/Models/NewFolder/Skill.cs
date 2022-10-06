using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Data.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Skill()
        {
            this.TypeSkill = new HashSet<TypeSkill>();
            this.Monter = new HashSet<Monter>();

        }
        public virtual ICollection<TypeSkill> TypeSkill { get; set; }
        public virtual ICollection<Monter> Monter { get; set; }

        public string Des { get; set; }
        public int Value { get; set; }
        public int TargetNum { get; set; }
        public int CountDown { get; set; }
        public int ManaSpend { get; set; }
        public int EffectiveTime { get; set; }




    }
}
