using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AboutController : Controller
	{
		public IActionResult AboutList()
		{
			return View();
		}
	}
}
