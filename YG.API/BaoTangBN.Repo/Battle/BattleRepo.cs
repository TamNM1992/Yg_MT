using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;
using ExtensionMethods;


namespace YG.Repo.Battle
{

    public class BattleRepository: IBattleRepository
    {
        public long Damage(long atk, long def)
        {
            if (atk >=def)
            {
                return (atk - def + atk * 5 / 100);
            }
            else
            {
                return atk * 5 / 100;
            }
        }
        public DataBattle DataRemainAvsB(DataBattle AB, int skillA, int skillB)
        {
            long damage;
            int xdamA = 100;
            int xdamB = 100;
            int rdamA = 100;
            int rdamB = 100;
            if(AB.positionB)
            {
                AB.Status = AB.Status + $"{AB.MonterB.Name} Power up  \n";
                xdamB = xdamB *3/2;
            }
            else
            {
                AB.Status = AB.Status + $"{AB.MonterB.Name} Entrenched \n";
                rdamB = rdamB /2;
            }

            if (AB.positionA)
            {
                AB.Status = AB.Status + $"{AB.MonterA.Name} Power up  \n";
                xdamA = xdamA *3/2;
            }
            else
            {
                AB.Status = AB.Status + $"{AB.MonterA.Name} Entrenched \n";
                rdamA = rdamA /2;
            }
            //A V B
            long hpB = AB.MonterB.HealPoint;
            long hpA = AB.MonterA.HealPoint;
            int speedhitA = AB.MonterA.SpeedHit;
            int speedhitB = AB.MonterB.SpeedHit;
            while (speedhitA > 0)
            {
                if(speedhitA<1000)
                {
                    if(AB.speedhitA > speedhitA)
                    {
                        break;
                    }
                    else
                    {
                        AB.Status = AB.Status + $"{AB.MonterA.Name} Get one more phisic attack \n";
                    }
                }
                speedhitA = speedhitA - 1000;

                // A crit
                if (AB.critrateA <= AB.MonterA.CritRate)
                {
                    AB.Status = AB.Status + $"{AB.MonterA.Name} Crit \n";

                    if (AB.rescritB > AB.MonterB.ResCrit)
                    {
                        damage = (((Damage(AB.MonterA.AdDam, AB.MonterB.AdArm) + Damage(AB.MonterA.ApDam, AB.MonterB.ApArm)) *
                                (AB.MonterA.CritDam - AB.MonterB.ResCrit * 10) / 1000) * (10000 - AB.MonterB.BlockRate) / 10000) * xdamA / 100 * rdamB / 100;

                        AB.Status = AB.Status + $"{AB.MonterA.Name} take {damage} damage \n";
                        AB.MonterB.HealPoint = AB.MonterB.HealPoint - damage;

                    }
                    // B res crit
                    else
                    {
                        AB.Status = AB.Status + $"{AB.MonterB.Name} Resistant Crit \n";
                        damage = ((Damage(AB.MonterA.AdDam, AB.MonterB.AdArm) + Damage(AB.MonterA.ApDam, AB.MonterB.ApArm))
                            * (10000 - AB.MonterB.BlockRate) / 10000) * xdamA / 100 * rdamB / 100;

                        AB.Status = AB.Status + $"{AB.MonterA.Name} take {damage} damage \n";
                        AB.MonterB.HealPoint = AB.MonterB.HealPoint - damage;
                    }
                }
                else
                {
                    damage = ((Damage(AB.MonterA.AdDam, AB.MonterB.AdArm) + Damage(AB.MonterA.ApDam, AB.MonterB.ApArm))
                        * (10000 - AB.MonterB.BlockRate) / 10000) * xdamA / 100 * rdamB / 100;
                    AB.Status = AB.Status + $"{AB.MonterA.Name} take {damage} damage \n";

                    AB.MonterB.HealPoint = AB.MonterB.HealPoint - damage;
                }
                // check die?
                if (AB.MonterB.HealPoint <= 0)
                {
                    AB.Status = AB.Status + $"{AB.MonterB.Name} Die \n";
                    AB.MonterB.HealPoint = 0;
                }
                else
                {
                    // B dodge
                    if (AB.dodgeB <= AB.MonterB.Dodge)
                    {
                        AB.Status = AB.Status + $"{AB.MonterB.Name} Dodge \n";
                        AB.MonterB.HealPoint = hpB;
                        continue;

                    }
                    //B block
                    if (AB.blockrateB <= AB.MonterB.BlockRate)
                    {
                        AB.Status = AB.Status + $"{AB.MonterB.Name} Block, reduce 50% damage \n";
                        AB.MonterB.HealPoint = AB.MonterB.HealPoint + damage/2;
                    }
                }
            }

            //B V A
            // B crit
            while (speedhitB > 0)
            {
                if (speedhitB < 1000)
                {
                    if (AB.speedhitB > speedhitB)
                    {
                        break;
                    }
                    else
                    {
                        AB.Status = AB.Status + $"{AB.MonterB.Name} Get one more phisic attack \n";
                    }
                }
                speedhitB = speedhitB - 1000;

                if (AB.critrateB <= AB.MonterB.CritRate)
                {
                    AB.Status = AB.Status + $"{AB.MonterB.Name} Crit \n";

                    if (AB.rescritA > AB.MonterA.ResCrit)
                    {
                        damage = (((Damage(AB.MonterB.AdDam, AB.MonterA.AdArm) + Damage(AB.MonterB.ApDam, AB.MonterA.ApArm))
                            * (AB.MonterB.CritDam - AB.MonterA.ResCrit * 10) / 1000)
                            * (10000 - AB.MonterA.BlockRate) / 10000) * xdamB / 100 * rdamA / 100;

                        AB.Status = AB.Status + $"{AB.MonterB.Name} take {damage} damage \n";

                        AB.MonterA.HealPoint = AB.MonterA.HealPoint - damage;

                    }
                    // A res crit
                    else
                    {
                        AB.Status = AB.Status + $"{AB.MonterA.Name} Resistant Crit \n";
                        damage = ((Damage(AB.MonterB.AdDam, AB.MonterA.AdArm) + Damage(AB.MonterB.ApDam, AB.MonterA.ApArm))
                            * (10000 - AB.MonterA.BlockRate) / 10000) * xdamB / 100 * rdamA / 100;
                        AB.Status = AB.Status + $"{AB.MonterB.Name} take {damage} damage \n";
                        AB.MonterA.HealPoint = AB.MonterA.HealPoint - damage;
                    }
                }
                else
                {
                    damage = (Damage(AB.MonterB.AdDam, AB.MonterA.AdArm) + Damage(AB.MonterB.ApDam, AB.MonterA.ApArm))
                        * (10000 - AB.MonterA.BlockRate) / 10000 * xdamB / 100 * rdamA / 100;
                    AB.Status = AB.Status + $"{AB.MonterB.Name} take {damage} damage \n";
                    AB.MonterA.HealPoint = AB.MonterA.HealPoint - damage;
                }
                //check die?
                if (AB.MonterA.HealPoint <= 0)
                {
                    AB.Status = AB.Status + $"{AB.MonterA.Name} Die \n";
                    AB.MonterA.HealPoint = 0;
                }
                else
                {
                    // A dodge
                    if (AB.dodgeA <= AB.MonterA.Dodge)
                    {
                        AB.Status = AB.Status + $"{AB.MonterA.Name} Dodge \n";
                        AB.MonterA.HealPoint = hpA;
                        continue;
                    }
                    //A block
                    if (AB.blockrateA <= AB.MonterA.BlockRate)
                    {
                        AB.Status = AB.Status + $"{AB.MonterA.Name} Block, reduce 50% damage  \n";
                        AB.MonterA.HealPoint = AB.MonterA.HealPoint + damage/2;
                    }
                }
            }
            AB.MonterA.HealPoint = AB.MonterA.HealPoint + AB.MonterA.HealPointRegen;
            AB.MonterB.HealPoint = AB.MonterB.HealPoint + AB.MonterB.HealPointRegen;

            return AB;
                                                   
        }
        public DataBattle AvsB(DataBattle data, long turn)
        {
            data.Status = data.Status + $" Turn {turn}  \n";
            data.Status = data.Status + $" {data.MonterA.Name}  vs  {data.MonterB.Name}   \n";
            //data = DataRemainAvsB(data);
            data.SetRate();
            return data;
        }

    }
}
