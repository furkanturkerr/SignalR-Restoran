using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDto;

namespace SignalRWebUI.ViewComponents.UILeyautComponents;

public class _UILayoutFooterComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("http://localhost:5013/api/Contact");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);
        }
        
        return View(new List<ResultContactDto>());
    }
}