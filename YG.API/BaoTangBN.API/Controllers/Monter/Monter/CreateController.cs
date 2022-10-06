using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YG.Data.Dtos;
using YG.Repo.SkillService;
using YG.Service.MonterService;

namespace YG.API.Controllers.Monter.Monter
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        private IMonterService _monterService;
        private ISkillService _skillService;

        private readonly IMapper _mapper;

        //public static List<Attribute> Attributes = new List<Attribute>();

        public CreateController(IMonterService monterService, IMapper mapper, ISkillService skillService)
        {
            _monterService = monterService;
            _mapper = mapper;
            _skillService = skillService;
        }
        [HttpPost("AddMonter")]
        public IActionResult AddMonter(MonterDto monterDto)
        {
            var temp = _monterService.AddMonter(monterDto);
            return Ok(temp);
        }

        [HttpPost("AddSkill")]
        public IActionResult AddSkill(SkillDto skillDto)
        {
            var temp = _skillService.AddSkill(skillDto);
            return Ok(temp);
        }

        [HttpPost("AddTypeSkill")]
        public IActionResult AddTypeSkill(TypeSkillDto TypeskillDto)
        {
            var temp = _skillService.AddTypeSkill(TypeskillDto);
            return Ok(temp);
        }

        [HttpPost("AddTypeSkillToSkill")]
        public IActionResult AddTypeSkilltoSkill(SkillTypeSkillDto skillTypeskillDto)
        {
            var temp = _skillService.AddTypeSkilltoSkill(skillTypeskillDto);
            return Ok(temp);
        }

        [HttpPost("AddSkillToMonter")]
        public IActionResult AddSkillToMonter(MonterSkillDto monterSkillDto)
        {
            var temp = _skillService.AddSkilltoMonter(monterSkillDto);
            return Ok(temp);
        }

        [HttpPost("CreateSkill")]
        public IActionResult CreateSkill(SkillCreateDto SkillCreateDto)
        {
            var temp = _skillService.CreateSkill(SkillCreateDto);
            return Ok(temp);
        }
    }
}
