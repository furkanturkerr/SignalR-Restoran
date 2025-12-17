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
        var responsemessage = await client.GetAsync("http://localhost:5013/api/Product/ProductListWithCategory");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            var sortedValues = values.OrderByDescending(x => x.ProductId).ToList();

            return View(sortedValues);
        }

        return View(new List<ResultProductDto>());
    }
}