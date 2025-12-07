using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDto;

namespace SignalRWebUI.Controllers;

public class BookingController : Controller
{
  private readonly IHttpClientFactory _httpClientFactory;

    public BookingController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("http://localhost:5013/api/Booking");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
            return View(values);
        }

        return View(new List<ResultBookingDto>());
    }

    [HttpGet]
    public IActionResult CreateBooking()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
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

    public async Task<IActionResult> DeleteBooking(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.DeleteAsync($"http://localhost:5013/api/Booking/{id}");
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBooking(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync($"http://localhost:5013/api/Booking/{id}");
        if (responsemessage.IsSuccessStatusCode)
        {
            var JsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBookingDto>(JsonData);
            return View(values);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBookingDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PutAsync($"http://localhost:5013/api/Booking/", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}