using AutoMapper;
using YG.Data.Dtos;
using YG.Data.Models;
using Attribute = YG.Data.Models.Attribute;
using Type = YG.Data.Models.Type;

namespace YG.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Tin Nổi bật
           
            CreateMap<Monter, MonterDto>().ReverseMap();
            CreateMap<MonterDto, Monter>().ReverseMap(); 
            //CreateMap<MonterData, Monter>().ReverseMap();
            //CreateMap<Monter, MonterData>().ReverseMap();

            CreateMap<AttributeDto, Attribute>().ReverseMap();
            CreateMap<Attribute, AttributeDto>().ReverseMap();
            CreateMap<Type, TypeDto>().ReverseMap();
            CreateMap<TypeDto, Type>().ReverseMap();

            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<SkillDto, Skill>().ReverseMap();
            CreateMap<Skill, SkillCreateDto>().ReverseMap();
            CreateMap<SkillCreateDto, Skill>().ReverseMap();

            CreateMap<TypeSkill, TypeSkillDto>().ReverseMap();
            CreateMap<TypeSkillDto, TypeSkill>().ReverseMap();
        }
    }
}
