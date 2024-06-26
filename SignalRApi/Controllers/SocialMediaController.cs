using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _mediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService mediaService, IMapper mapper)
        {
            _mediaService = mediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MediaList()
        {
            var values = _mediaService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("GetMedia")]
        public IActionResult GetMedia(int id)
        {
            var values = _mediaService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddMedia(CreateMediaDto createMediaDto)
        {
            _mediaService.TInsert(_mapper.Map<SocialMedia>(createMediaDto));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMedia(UpdateMediaDto updateMediaDto)
        {
            _mediaService.TUpdate(_mapper.Map<SocialMedia>(updateMediaDto));
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteMedia(int id)
        {
            var values = _mediaService.TGetById(id);
            return Ok(values);
        }
    }
}
