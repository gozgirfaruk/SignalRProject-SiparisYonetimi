using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("GetTest")]
        public IActionResult GetTest(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTest(CreateTestimonialDto dto)
        {
            _testimonialService.TInsert(_mapper.Map<Testimonial>(dto));
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTest(UpdateTestimonialDto dto)
        {
            _testimonialService.TUpdate(_mapper.Map<Testimonial>(dto)); 
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTest(int id)
        {
            var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return Ok();
        }

    }
}
