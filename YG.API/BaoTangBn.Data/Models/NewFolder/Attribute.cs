using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Data.Models
{
    public class Attribute
    {
        public Guid Id { get; set; }
        public string NameAttribute { get; set; }
        public int AtkBase { get; set; }
        public int DefBase { get; set; }
        public int SpeedBase { get; set; }
        public int StrengBase { get; set; }
        public int AdRateAtk { get; set; }
        public int ApRateAtk { get; set; }
        public int AdRateDef { get; set; }
        public int ApRateDef { get; set; }
        public int Tenacity { get; set; }
        public int Intelligent { get; set; }

    };
}
