using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        HttpClient client2 = new HttpClient();
        HttpResponseMessage response = await client2.GetAsync("http://localhost:5013/api/Contact");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray item = JArray.Parse(responseBody);
        string value = item[0]["location"].ToString();
        ViewBag.location = value;

        createBookingDto.Description = "b";

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBookingDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:5013/api/Booking", stringContent);

          

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }
        else
        {
            var errorContent = await responseMessage.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, errorContent);
            return View();
        }

    }
}