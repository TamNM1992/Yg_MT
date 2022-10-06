using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;
using YG.Data.Models;

namespace YG.Repo.SkillService
{
    public interface ISkillService
    {
        public bool AddSkill(SkillDto skillDto);
        public bool AddTypeSkill(TypeSkillDto TypeskillDto);
        public bool AddTypeSkilltoSkill(SkillTypeSkillDto skillTypeskillDto);
        public bool AddSkilltoMonter(MonterSkillDto MonterskillDto);
        public bool CreateSkill(SkillCreateDto SkillCreateDto);
        public IEnumerable<Skill> GetSkill(string monterName);


    }
}
