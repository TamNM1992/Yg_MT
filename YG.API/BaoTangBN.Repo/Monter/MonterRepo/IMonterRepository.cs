using YG.Data.Dtos;
using YG.Data.Models;
using Attribute = YG.Data.Models.Attribute;
using Type = YG.Data.Models.Type;

namespace YG.Repo.MonterRepo
{
    public interface IMonterRepository
    {
        public IEnumerable<Monter> GetAll();
        public bool AddMonter(MonterDto monter);
        public MonterData GetMonter(string name);
        public bool AddAttribute(Attribute attribute);
        public bool AddType(Type type);

    }
}
