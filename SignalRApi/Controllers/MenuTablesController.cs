using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menutableService;

        public MenuTablesController(IMenuTableService menutableService)
        {
            _menutableService = menutableService;
        }
        [HttpGet]
        public IActionResult MenuTableCount()
        {
            var values = _menutableService.TMenuTableCount();
            return Ok(values);
        }
    }
}
