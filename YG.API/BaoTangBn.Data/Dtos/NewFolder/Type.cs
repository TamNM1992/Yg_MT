using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Data.Dtos
{
    public class TypeDto
    {/*  atk----def----speed--streng--ad--ap*/
        public string NameType { get; set; }
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
    //public class Dragon : Type
    //{
    //    public Dragon()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Spellcaster : Type
    //{
    //    public Spellcaster()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Machine : Type
    //{
    //    public Machine()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Plant : Type
    //{
    //    public Plant()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Rock : Type
    //{
    //    public Rock()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Beast : Type
    //{
    //    public Beast()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Bestwarrior : Type
    //{
    //    public Bestwarrior()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Wingedbeast : Type
    //{
    //    public Wingedbeast()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Warrior : Type
    //{
    //    public Warrior()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Psychic : Type
    //{
    //    public Psychic()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Divinebeast : Type
    //{
    //    public Divinebeast()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Fish : Type
    //{
    //    public Fish()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Fiend : Type
    //{
    //    public Fiend()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Fairy : Type
    //{
    //    public Fairy()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Insect : Type
    //{
    //    public Insect()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Aqua : Type
    //{
    //    public Aqua()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Dinosaur : Type
    //{
    //    public Dinosaur()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Pyro : Type
    //{
    //    public Pyro()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Reptile : Type
    //{
    //    public Reptile()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Seaserpent : Type
    //{
    //    public Seaserpent()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Thunder : Type
    //{
    //    public Thunder()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
    //public class Zombie : Type
    //{
    //    public Zombie()
    //    {
    //        AtkBase = 1;
    //        DefBase = 1;
    //        SpeedBase = 1;
    //        StrengBase = 1;
    //        AdRateAtk = 1;
    //        ApRateAtk = 1;
    //        AdRateDef = 1;
    //        ApRateDef = 1;
    //    }
    //}
}
