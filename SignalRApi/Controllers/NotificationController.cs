using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notiService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notiService, IMapper mapper)
		{
			_notiService = notiService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetNotificationList()
		{
			var values = _notiService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto dto)
		{
		 var values =_mapper.Map<Notification>(dto);
		_notiService.TInsert(values);
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteNotification(int id)
		{
			var values = _notiService.TGetById(id);
			_notiService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto dto)
		{
			var values =_mapper.Map<Notification>(dto);
			_notiService.TUpdate(values);
			return Ok();

		}

		[HttpGet("GetNotificationByID")]
		public IActionResult GetNotificationByID(int id)
		{
			var values = _notiService.TGetById(id);
			return Ok(values);
		}

		[HttpGet("UnReadNotification")]
		public IActionResult UnReadNotification()
		{
			var values = _notiService.TNotificationByUnRead();
			return Ok(values);
		}
		[HttpGet("UnReadNotificationContent")]
		public IActionResult UnReadNotificationContent()
		{
			var values = _notiService.TGetNotificationContentUnRead();
			return Ok(values);
		}

		[HttpGet("ChangeNotificationToRead/{id}")]
		public IActionResult ChangeNotificationToRead(int id)
		{
			_notiService.TChangeToRead(id);
			return Ok();
		}

        [HttpGet("ChangeNotificationToUnRead/{id}")]
        public IActionResult ChangeNotificationToUnRead(int id)
        {
            _notiService.TChangeToUnRead(id);
            return Ok();
        }
    }
}
