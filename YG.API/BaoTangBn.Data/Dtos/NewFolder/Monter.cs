
using YG.Data.Models;
using Attribute = YG.Data.Models.Attribute;
using Type = YG.Data.Models.Type;

namespace YG.Data.Dtos
{

    public class MonterDto
    {
        public string Name { get; set; }


        public string Attribute { get; set; }

        public string Type { get; set; }

        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }


    }
    public class MonterData
    {
        public string Name { get; set; }


        public Attribute Attribute { get; set; }

        public Type Type { get; set; }

        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }


    }
    public class MonterBase
    {

        public string Name { get; set; }

        public int Attack { get; set; }
        public int AdDam { get; set; }
        public int ApDam { get; set; }

        public int Defender { get; set; }
        public int AdArm { get; set; }
        public int ApArm { get; set; }

        public long HealPoint   { get; set; }
        public int HealPointRegen { get; set; }
        public int Mana { get; set; }
        public int ManaRegen { get; set; }

        public int CritRate { get; set; }
        public int ResCrit { get; set; }
        public int CritDam { get; set; }
        public int Dodge { get; set; }
        public int HitRate { get; set; }
        public int BlockRate { get; set; }
        public int TrueDam { get; set; }
        public int HitCount { get; set; }
        public int SpeedHit { get; set; }
      


        public MonterBase(MonterData monterDto)
        {
            Name = monterDto.Name;
            Attack = monterDto.Atk * (monterDto.Attribute.AtkBase + monterDto.Type.AtkBase)* monterDto.Level/100;
            AdDam = (monterDto.Attribute.AdRateAtk + monterDto.Type.AdRateAtk) * Attack / 1000;
            ApDam = (monterDto.Attribute.ApRateAtk + monterDto.Type.ApRateAtk) * Attack / 1000;

            Defender = monterDto.Def * (monterDto.Attribute.DefBase + monterDto.Type.DefBase) * monterDto.Level / 100;
            AdArm = (monterDto.Attribute.AdRateDef + monterDto.Type.AdRateDef)* Defender / 1000;
            ApArm = (monterDto.Attribute.ApRateDef + monterDto.Type.ApRateDef)* Defender / 1000;

            HealPoint = (monterDto.Atk + monterDto.Def) * (monterDto.Attribute.StrengBase +
                monterDto.Type.StrengBase+ monterDto.Attribute.Tenacity+monterDto.Type.Tenacity) * monterDto.Level;

            HealPointRegen = (monterDto.Attribute.Tenacity+ monterDto.Type.Tenacity)*monterDto.Level;

            Mana = (monterDto.Attribute.Intelligent + monterDto.Type.Intelligent+ 
                monterDto.Type.ApRateAtk+monterDto.Attribute.ApRateAtk) * monterDto.Level;

            ManaRegen = monterDto.Attribute.Intelligent + monterDto.Type.Intelligent ;

            CritRate = ((monterDto.Attribute.Intelligent + monterDto.Type.Intelligent) * monterDto.Level+ (monterDto.Level*3000))/1000;

            ResCrit = ((monterDto.Attribute.Tenacity + monterDto.Type.Tenacity) * monterDto.Level+(monterDto.Level * 1500))/1000;

            CritDam = 1000+ ((monterDto.Attribute.AtkBase + monterDto.Attribute.Intelligent+
                monterDto.Type.Intelligent) * monterDto.Level / 10) + monterDto.Level*50;

            Dodge   = 1000+ (monterDto.Type.DefBase+ monterDto.Attribute.DefBase+
                monterDto.Attribute.SpeedBase + monterDto.Type.SpeedBase)*monterDto.Level/10 + (monterDto.Level * 100);
            HitRate =10000+ ((monterDto.Attribute.AtkBase + monterDto.Type.AtkBase+ 
                monterDto.Attribute.Intelligent + monterDto.Type.Intelligent) * monterDto.Level / 10)+(monterDto.Level * 200);

            BlockRate = (monterDto.Type.StrengBase + monterDto.Type.Tenacity +
                monterDto.Attribute.StrengBase + monterDto.Attribute.Tenacity) * monterDto.Level / 10;

            TrueDam = 0;
            HitCount = 1;
            SpeedHit = 1000 + ((monterDto.Attribute.SpeedBase + monterDto.Type.SpeedBase + monterDto.Attribute.AtkBase + monterDto.Type.AtkBase
                       + monterDto.Attribute.AdRateAtk + monterDto.Type.AdRateAtk) * monterDto.Level / 100)+ monterDto.Level*50;
           
        }
    }
}
