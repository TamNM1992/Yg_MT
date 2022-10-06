using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;
using YG.Data.Models;

namespace YG.Repo.SkillRepo
{
    public interface ISkillRepo
    {
        public bool AddSkill(SkillDto skillDto);
        public bool AddTypeSkill(TypeSkillDto typeskillDto);
        public bool AddTypeSkilltoSkill(SkillTypeSkillDto skilltypeskillDto);
        public bool AddSkilltoMonter(MonterSkillDto monterskillDto);
        public bool CreateSkill(SkillCreateDto SkillCreateDto);
        public List<Skill> GetSkill(string monterName);


    }
}
