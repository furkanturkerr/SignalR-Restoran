using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents;

public class _OurMenuComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _OurMenuComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("http://localhost:5013/api/Product");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        return View(new List<ResultProductDto>());
    }
}