using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;
using YG.Data.Models;
using YG.Repo.SkillRepo;

namespace YG.Repo.SkillService
{
    public class SkillService : ISkillService
    {
        private ISkillRepo _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public SkillService(ISkillRepo repo, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<Skill> GetSkill(string monterName)
        {

            var temp = _repo.GetSkill(monterName);
            return temp;
        }

        public bool AddSkill(SkillDto skillDto)
        {

            var temp = _repo.AddSkill(skillDto);
            return temp;
        }
        public bool AddTypeSkill(TypeSkillDto TypeskillDto)
        {

            var temp = _repo.AddTypeSkill(TypeskillDto);
            return temp;
        }
        public bool AddTypeSkilltoSkill(SkillTypeSkillDto skillTypeskillDto)
        {

            var temp = _repo.AddTypeSkilltoSkill(skillTypeskillDto);
            return temp;
        }
        public bool AddSkilltoMonter(MonterSkillDto MonterskillDto)
        {

            var temp = _repo.AddSkilltoMonter(MonterskillDto);
            return temp;
        }
        public bool CreateSkill(SkillCreateDto SkillCreateDto)
        {

            var temp = _repo.CreateSkill(SkillCreateDto);
            return temp;
        }
    }
}
