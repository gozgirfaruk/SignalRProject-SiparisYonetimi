using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	
	public class SignalRDefaultController : Controller
	{
		//sayfa yenilendikçe tetikleme oldukça verilerin yenilendiği sınıf
		public IActionResult Index()
		{
			return View();
		}

		// sayfa yenilenmeden sürekli veritabanındaki değişiklikleri kontrol eden sınıf
		public IActionResult NoTrigger()
		{
			return View();
		}
	}
}
