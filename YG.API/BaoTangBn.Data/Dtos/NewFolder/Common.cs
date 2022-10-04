using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;

namespace ExtensionMethods
{
    public static class DataBattleExtensions
    {
        public static DataBattle SetData(this DataBattle a, MonterBase ma, MonterBase mb, bool positionA, bool positionB)
        {
            a.positionA = positionA;
            a.positionB = positionB;
            a.MonterA = ma;
            a.MonterB = mb;
            Random critrateA = new Random();
            Random critrateB = new Random();

            Random rescritA = new Random();
            Random rescritB = new Random();

            Random dodgeA = new Random();
            Random dodgeB = new Random();


            Random blockrateA = new Random();
            Random blockrateB = new Random();

            Random speedhitA = new Random();
            Random speedhitB = new Random();

            a.critrateA = critrateA.Next(0, 100);
            a.critrateB = critrateB.Next(0, 100);

            a.rescritA = rescritA.Next(0, 100);
            a.rescritB = rescritB.Next(0, 100);

            a.dodgeA = dodgeA.Next(0, 10000);
            a.dodgeB = dodgeB.Next(0, 10000);

            a.blockrateA = blockrateA.Next(0, 10000);
            a.blockrateB = blockrateB.Next(0, 10000);

            a.speedhitA = speedhitA.Next(0, 1000);
            a.speedhitB = speedhitB.Next(0, 1000);

            return a;
        }
    }
}

namespace YG.Data.Dtos
{
    public class DataBattle
    {
        public int Turn { get; set; }
        public string Status { get; set; }

        public MonterBase MonterA { get; set; }
        public MonterBase MonterB { get; set; }

        public bool positionA { get; set; }
        public bool positionB { get; set; }

        public int critrateA { get; set; }
        public int critrateB { get; set; }

        public int rescritA { get; set; }
        public int rescritB { get; set; }
        public int dodgeA { get; set; }
        public int dodgeB { get; set; }

        public int blockrateA { get; set; }
        public int blockrateB { get; set; }

        public int speedhitA { get; set; }
        public int speedhitB { get; set; }
        public  DataBattle( MonterBase ma, MonterBase mb, bool opositionA, bool opositionB)
        {
            Status = " Start-------------/n";
            positionA = opositionA;
            positionB = opositionB;
            MonterA = ma;
            MonterB = mb;
            Random rcritrateA = new Random();
            Random rcritrateB = new Random();

            Random rrescritA = new Random();
            Random rrescritB = new Random();

            Random rdodgeA = new Random();
            Random rdodgeB = new Random();


            Random rblockrateA = new Random();
            Random rblockrateB = new Random();

            Random rspeedhitA = new Random();
            Random rspeedhitB = new Random();

            critrateA = rcritrateA.Next(0, 100);
            critrateB = rcritrateB.Next(0, 100);

            rescritA = rrescritA.Next(0, 100);
            rescritB = rrescritB.Next(0, 100);

            dodgeA = rdodgeA.Next(0, 10000);
            dodgeB = rdodgeB.Next(0, 10000);

            blockrateA = rblockrateA.Next(0, 10000);
            blockrateB = rblockrateB.Next(0, 10000);

            speedhitA = rspeedhitA.Next(0, 1000);
            speedhitB = rspeedhitB.Next(0, 1000);


        }
        public void SetRate()
        {
            Random rcritrateA = new Random();
            Random rcritrateB = new Random();

            Random rrescritA = new Random();
            Random rrescritB = new Random();

            Random rdodgeA = new Random();
            Random rdodgeB = new Random();


            Random rblockrateA = new Random();
            Random rblockrateB = new Random();

            Random rspeedhitA = new Random();
            Random rspeedhitB = new Random();

            critrateA = rcritrateA.Next(0, 100);
            critrateB = rcritrateB.Next(0, 100);

            rescritA = rrescritA.Next(0, 100);
            rescritB = rrescritB.Next(0, 100);

            dodgeA = rdodgeA.Next(0, 10000);
            dodgeB = rdodgeB.Next(0, 10000);

            blockrateA = rblockrateA.Next(0, 10000);
            blockrateB = rblockrateB.Next(0, 10000);

            speedhitA = rspeedhitA.Next(0, 1000);
            speedhitB = rspeedhitB.Next(0, 1000);
        }
    }
}
