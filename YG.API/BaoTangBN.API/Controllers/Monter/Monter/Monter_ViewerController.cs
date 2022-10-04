﻿using AutoMapper;
using YG.Common.Extensions;
using YG.Common.Models;
using YG.Data.Dtos;
using YG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using YG.Service.MonterService;
//using Attribute = YG.Data.Dtos.Attribute;

namespace YG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Monter_ViewerController : ControllerBase
    {
        private IMonterService _monterService;
        private readonly IMapper _mapper;

        //public static List<Attribute> Attributes = new List<Attribute>();

        public Monter_ViewerController(IMonterService monterService, IMapper mapper)
        {
            _monterService = monterService;
            _mapper = mapper;

        }

        [HttpPost("GetList")]
        public IActionResult GetListAndPaging(FilterBase filter)
        {
            ResponseBase response = new ResponseBase();
            try
            {

                var temp = _monterService.GetList().ToList();
                var listMonter = new List<MonterDto>();
                response.Count = temp.Count;
                if (temp != null)
                {
                    if (filter.SortField == null)
                    {
                        temp.SortByField("asc", "NgayTao");
                    }
                    else
                    {
                        listMonter = temp.SortByField(filter.SortBy, filter.SortField);
                    }

                    response.Data = listMonter.ConvertToPaging(filter.PageSize, filter.PageIndex).Items;

                }
                else
                {
                    response.Code = ErrorCodeMessage.ListNull.Key;
                    response.Message = ErrorCodeMessage.ListNull.Value;
                }

            }
            catch
            {
                response.Code = ErrorCodeMessage.InternalExeption.Key;
                response.Message = ErrorCodeMessage.InternalExeption.Value;
            }
            return Ok(response);
        }

        [HttpPost("CreateMonter")]
        public IActionResult CreateMonter(string monterName)
        {
            var temp = _monterService.CreateMonter(monterName);
            return Ok(temp);
        }
        [HttpPost("AddMonter")]
        public IActionResult AddMonter(MonterDto monterDto)
        {
            var temp = _monterService.AddMonter(monterDto);
            return Ok(temp);
        }

        [HttpPost("AddAttribute")]
        public IActionResult AddAttribute(AttributeDto attributeDto)
        {
            var temp = _monterService.AddAttribute(attributeDto);
            return Ok(temp);
        }

        [HttpPost("AddType")]
        public IActionResult AddType(TypeDto typeDto)
        {
            var temp = _monterService.AddType(typeDto);
            return Ok(temp);
        }

    }
}
