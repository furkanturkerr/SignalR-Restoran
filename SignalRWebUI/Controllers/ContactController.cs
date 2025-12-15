using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDto;

namespace SignalRWebUI.Controllers;

public class ContactController : Controller
{
  private readonly IHttpClientFactory _httpClientFactory;

    public ContactController  (IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IActionResult> Index()
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

    [HttpGet]
    public IActionResult CreateContact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        createContactDto.OpendaysDescription = "Haftanın 7 Günü";
        createContactDto.Opendays = "Çalışma Saatlerimiz";
        var client = _httpClientFactory.CreateClient();
        var JsonData = JsonConvert.SerializeObject(createContactDto);
        StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PostAsync("http://localhost:5013/api/Contact", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> DeleteContact(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.DeleteAsync($"http://localhost:5013/api/Contact/{id}");
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateContact(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync($"http://localhost:5013/api/Contact/{id}");
        if (responsemessage.IsSuccessStatusCode)
        {
            var JsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateContactDto>(JsonData);
            return View(values);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
    {
        updateContactDto.OpendaysDescription = "Haftanın 7 Günü";
        updateContactDto.Opendays = "Çalışma Saatlerimiz";
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateContactDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PutAsync($"http://localhost:5013/api/Contact/", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}