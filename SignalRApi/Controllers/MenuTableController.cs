using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menutableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menutableService, IMapper mapper)
        {
            _menutableService = menutableService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MenuTableCount()
        {
            var values = _menutableService.TMenuTableCount();
            return Ok(values);
        }

        [HttpGet("MenuTableList")]
        public IActionResult MenuTableList()
        {
            var valeus = _menutableService.TGetListAll();
            return Ok(valeus);
        }

        [HttpDelete]
        public IActionResult DeleteMenuTable(int id)
        {
            var values = _menutableService.TGetById(id);
            _menutableService.TDelete(values);
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertMenuTable(CreateMenuTableDto dto)
        {
            _menutableService.TInsert(_mapper.Map<MenuTable>(dto));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto dto)
        {
            _menutableService.TUpdate(_mapper.Map<MenuTable>(dto));
            return Ok();
        }
        [HttpGet("GetMenuTableById")]
        public IActionResult GetMenuTableById(int id)
        {
            var values = _menutableService.TGetById(id);
            return Ok(values);
        }


    }
}
