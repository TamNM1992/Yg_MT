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
        public TypeSkill TypeSkill { get; set; }
        public string Des { get; set; }
        public int Value { get; set; }
        public int TargetNum { get; set; }
        public int CountDown { get; set; }

        public int EffectiveTime { get; set; }

        //public Skill(string name, string des, int[] value, int targetNum, int countDown, int effectiveTime)
        //{
        //    Name = name;
        //    Des = des;
        //    Value = value;
        //    TargetNum = targetNum;
        //    CountDown = countDown;
        //    EffectiveTime = effectiveTime;
        //}
    }
}
