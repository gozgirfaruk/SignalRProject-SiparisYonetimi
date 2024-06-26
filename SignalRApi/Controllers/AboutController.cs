using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
          var values =  _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("GetAbout")]   
        public IActionResult GetAbout(int id)
        {
            var values = _mapper.Map<GetAboutDto>(_aboutService.TGetById(id));
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto dto)
        {
            About about = new About()
            {
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Title = dto.Title,
            };
          _aboutService.TInsert(about);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok("silme işlemi başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto dto)
        {
            About about = new About()
            {
                AboutID = dto.AboutID,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Title = dto.Title
            };
            _aboutService.TUpdate(about);
            return Ok("Güncelleme işlemi başarılı");
        }

    }
}
