using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents
{
    public class _BookViewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
