using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;
using YG.Data.Models;
using YG.Repo.Battle;

namespace YG.Service.Battle
{
    public class BattleService : IBattleService
    {
        private IBattleRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public BattleService(IBattleRepository repo, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public DataBattle GetResultAvsB (DataBattle data)
        {
            int turn = 1;
            //_repo.AvsB(data, turn);
            //turn++;
            //_repo.AvsB(data, turn);
            //turn++;
            //_repo.AvsB(data, turn);
            //turn++;
            //_repo.AvsB(data, turn);
            //turn++;
            while (data.MonterA.HealPoint > 0 && data.MonterB.HealPoint > 0)
            {
                _repo.AvsB(data, turn);
                turn++;
            }

            return data;
        }
    }
}
