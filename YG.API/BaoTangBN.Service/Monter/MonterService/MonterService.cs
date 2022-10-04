using AutoMapper;
using YG.Common;
using YG.Common.Extensions;
using YG.Common.Models;
using YG.Data.Dtos;
using YG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using YG.Data.Dtos;
using YG.Data.Models;
using Attribute = YG.Data.Models.Attribute;
using Type = YG.Data.Models.Type;
using YG.Repo.MonterRepo;

namespace YG.Service.MonterService
{
    public class MonterService : IMonterService
    {
        private IMonterRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public MonterService(IMonterRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<MonterDto> GetList()
        {
            List<MonterDto> temp1 = new List<MonterDto>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();


            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<Monter, MonterDto>(temp3[i]));
            }
            return temp1;
        }

        public IEnumerable<MonterDto> SearchByName(string keyWord)
        {
            List<MonterDto> temp1 = new List<MonterDto>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Name.Contains(keyWord) == true )
                {
                    temp1.Add (_mapper.Map<Monter, MonterDto>(temp3[i]));
                }
            }
            return temp1;
        }
       
        public bool AddMonter(MonterDto monterDto)
        {
            //var monterEntity = _mapper.Map<MonterDto, Monter>(monterDto);

            var temp = _repo.AddMonter(monterDto);
            return temp;
        }
        public bool AddAttribute(AttributeDto attributeDto)
        {
            var attributeEntity = _mapper.Map<AttributeDto, Attribute>(attributeDto);

            var temp = _repo.AddAttribute(attributeEntity);
            return temp;
        }
        public bool AddType(TypeDto typeDto)
        {
            var typeEntity = _mapper.Map<TypeDto, Type>(typeDto);

            var temp = _repo.AddType(typeEntity);
            return temp;
        }

        public MonterBase CreateMonter(string monterName)
        {
            var monterData = _repo.GetMonter(monterName);
            MonterBase monterbase = new MonterBase(monterData);
            return monterbase;
        }
    }
}