using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDto;
using SignalRWebUI.Dtos.TestimonialDto;

namespace SignalRWebUI.ViewComponents.DefaultComponents;

public class _TestimonialComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("http://localhost:5013/api/Testimonial");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
        
        return View(new List<ResultTestimonialDto>());
    }
}