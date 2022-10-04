using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;

namespace YG.Repo.Battle
{
    public interface IBattleRepository
    {
        public DataBattle AvsB(DataBattle data, long turn);
    }
}
