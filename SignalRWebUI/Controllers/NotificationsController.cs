using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.DtoNotifications;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class NotificationsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public NotificationsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44361/api/Notification");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<NotificationsResultDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> DeleteNotification(int id)
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44361/api/Notification?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

		public async Task<IActionResult> ChangeNotificationToRead(int id)
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44361/api/Notification/ChangeNotificationToRead/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ChangeNotificationToUnRead(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44361/api/Notification/ChangeNotificationToUnRead/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
