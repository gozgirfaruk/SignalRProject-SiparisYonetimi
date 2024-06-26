using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values =_discountService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddDiscount(CreateDiscountDto dto)
        {
            _discountService.TInsert(_mapper.Map<Discount>(dto));
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            _discountService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto dto)
        {
            _discountService.TUpdate(_mapper.Map<Discount>(dto));
            return Ok();
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            return Ok(values);
        }
    }
}
