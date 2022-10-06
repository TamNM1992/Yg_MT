using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;
using YG.Data.Models;

namespace YG.Repo.SkillRepo
{
    public class SkillRepo : ISkillRepo
    {
        private readonly YGDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public SkillRepo(YGDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public List<Skill> GetSkill(string monterName)
        {
            try
            {
                //var authorities = _authorityContext.Users.Where(x => x.Id == user).SelectMany(x => x.Authorities);

                var monter = _context.Monter.Where(x=> x.Name == monterName).SelectMany(r=> r.Skill);

                return monter.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddSkill(SkillDto skillDto)
        {
            try
            {
                var skill = _mapper.Map<SkillDto, Skill>(skillDto);
                _context.Skill.Add(skill);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddTypeSkill(TypeSkillDto typeskillDto)
        {
            try
            {
                var skill = _mapper.Map<TypeSkillDto, TypeSkill>(typeskillDto);
                _context.TypeSkill.Add(skill);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddTypeSkilltoSkill(SkillTypeSkillDto skilltypeskillDto)
        {
            try
            {
                var skill = _context.Skill.SingleOrDefault(x => x.Name == skilltypeskillDto.SkillName);
                var typeskill = _context.TypeSkill.SingleOrDefault(x => x.Name == skilltypeskillDto.TypeSkillName);

                skill.TypeSkill.Add(typeskill);
                typeskill.Skill.Add(skill);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddSkilltoMonter(MonterSkillDto monterskillDto)
        {
            try
            {
                var skill = _context.Skill.SingleOrDefault(x => x.Name == monterskillDto.SkillName);
                var monter = _context.Monter.SingleOrDefault(x => x.Name == monterskillDto.MonterName);

                skill.Monter.Add(monter);
                monter.Skill.Add(skill);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateSkill(SkillCreateDto SkillCreateDto)
        {
            try
            {
                var skill = _mapper.Map<SkillCreateDto, Skill>(SkillCreateDto);
                _context.Skill.Add(skill);
                _context.SaveChanges();
                var monter = _context.Monter.SingleOrDefault(x => x.Name == SkillCreateDto.MonterName);
                TypeSkill typeskill;
                for (int i =0; i< SkillCreateDto.TypeSkillName.Count; i++)
                {
                    typeskill = _context.TypeSkill.SingleOrDefault(x => x.Name == SkillCreateDto.TypeSkillName[i]);
                    skill.TypeSkill.Add(typeskill);
                    typeskill.Skill.Add(skill);

                }

                monter.Skill.Add(skill);
                skill.Monter.Add(monter);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
