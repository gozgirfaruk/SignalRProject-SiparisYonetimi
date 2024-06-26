using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(CreateBookingDto dto)
        {
            var values = _mapper.Map<Booking>(dto);
            _bookingService.TInsert(values);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto dto)
        {
            _bookingService.TUpdate(_mapper.Map<Booking>(dto));
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
           var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok();
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }

    }
}
