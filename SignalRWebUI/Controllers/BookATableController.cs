using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDto;

namespace SignalRWebUI.Controllers;
[AllowAnonymous]
public class BookATableController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BookATableController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var JsonData = JsonConvert.SerializeObject(createBookingDto);
        StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PostAsync("http://localhost:5013/api/Booking", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}