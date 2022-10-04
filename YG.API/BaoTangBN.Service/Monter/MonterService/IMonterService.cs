
using YG.Data.Dtos;
using YG.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YG.Data.Dtos;

namespace YG.Service.MonterService
{
    public interface IMonterService
    {
        public IEnumerable<MonterDto> GetList();
        public bool AddMonter(MonterDto monterDto);

        public IEnumerable<MonterDto> SearchByName(string keyWord);
        public MonterBase CreateMonter(string name);
        public bool AddAttribute(AttributeDto attributeDto);
        public bool AddType(TypeDto typeDto);
    }
}
