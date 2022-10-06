using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Models;

namespace YG.Data.Dtos
{
    public class SkillDto
    {
        public string Name { get; set; }
        public string Des { get; set; }
        public int Value { get; set; }
        public int TargetNum { get; set; }
        public int CountDown { get; set; }
        public int ManaSpend { get; set; }

        public int EffectiveTime { get; set; }


    }
    public class SkillCreateDto
    {
        public string Name { get; set; }
        public string Des { get; set; }
        public int Value { get; set; }
        public int TargetNum { get; set; }
        public int CountDown { get; set; }
        public int ManaSpend { get; set; }

        public int EffectiveTime { get; set; }
        public string MonterName { get; set; }
        public List<string> TypeSkillName { get; set; }
    }
}
