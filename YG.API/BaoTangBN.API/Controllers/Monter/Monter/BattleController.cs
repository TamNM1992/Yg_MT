using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YG.Data.Dtos;
using YG.Service.Battle;
using YG.Service.MonterService;

namespace YG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : Controller
    {
        private IBattleService _battleService;
        private IMonterService _monterService;

        private readonly IMapper _mapper;

        //public static List<Attribute> Attributes = new List<Attribute>();

        public BattleController(IBattleService battleService, IMonterService monterService ,IMapper mapper)
        {
            _monterService = monterService;
            _battleService = battleService;
            _mapper = mapper;

        }
        [HttpPost]
        public IActionResult GetResultAvsB(string monterA, string monterB, bool pA , bool pB)
        {
            var MonterA = _monterService.CreateMonter(monterA);
            var MonterB = _monterService.CreateMonter(monterB);
            var data = new DataBattle(MonterA, MonterB, pA, pB);

            _battleService.GetResultAvsB(data);
            return Ok(data);
        }
    }
}
