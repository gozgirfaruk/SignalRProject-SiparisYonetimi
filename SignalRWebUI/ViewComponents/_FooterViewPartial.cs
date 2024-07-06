using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.FooterDtos;

namespace SignalRWebUI.ViewComponents
{
    public class _FooterViewPartial : ViewComponent
    {
  private readonly IHttpClientFactory _httpClientFactory;

        public _FooterViewPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44361/api/Contact");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
