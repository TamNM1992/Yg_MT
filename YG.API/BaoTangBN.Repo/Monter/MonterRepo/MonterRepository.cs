using AutoMapper;

using YG.Data.Models;
using Microsoft.Extensions.Options;

using YG.Data.Models;
using YG.Data.Dtos;
using Attribute = YG.Data.Models.Attribute;
using Type = YG.Data.Models.Type;

namespace YG.Repo.MonterRepo
{
    public class MonterRepository : IMonterRepository
    {
        private readonly YGDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public MonterRepository(YGDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Monter> GetAll()
        {

            var temp = _context.Monter;
   
            return temp;
        }
        public MonterData GetMonter(string name)
        {

            var monter = _context.Monter.SingleOrDefault(x => x.Name == name);
            var monterData = new MonterData();
            monterData.Name = monter.Name;
            monterData.Attribute   = _context.Attribute.SingleOrDefault(x=> x.NameAttribute == monter.Attribute);
            monterData.Type = _context.Type.SingleOrDefault(x => x.NameType == monter.Type);
            monterData.Level = monter.Level;
            monterData.Atk = monter.Atk;
            monterData.Def = monter.Def;
            return monterData;
        }

        public bool AddMonter(MonterDto monterDto)
        {
            try
            {
                var monter = _mapper.Map<MonterDto, Monter>(monterDto);

                var temp = _context.Monter.SingleOrDefault(x=> x.Name == monterDto.Name);
                if (temp == null)
                {
                    _context.Monter.Add(monter);

                }
                else
                {
                    temp.Atk = monterDto.Atk;
                    temp.Def = monterDto.Def;
                    temp.Level = monterDto.Level;
                    temp.Attribute = monterDto.Attribute;
                    temp.Type = monterDto.Type;
                }    
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddAttribute(Attribute attribute)
        {
            try
            {
                _context.Attribute.Add(attribute);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddType(Type type)
        {
            try
            {
                _context.Type.Add(type);
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
