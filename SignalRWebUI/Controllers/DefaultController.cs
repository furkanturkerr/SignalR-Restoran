using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.ContactDto;
using CreateMessageDto = SignalRWebUI.Dtos.MessageDto.CreateMessageDto;

namespace SignalRWebUI.Controllers;
[AllowAnonymous]
public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("http://localhost:5013/api/Contact/");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray item = JArray.Parse(responseBody);
        string value = item[0]["location"].ToString();
        ViewBag.location = value;
        return View();
    }

    [HttpGet]
    public async Task<PartialViewResult> SendMessage()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
    {
        var client = _httpClientFactory.CreateClient();
        var JsonData = JsonConvert.SerializeObject(createMessageDto);
        StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PostAsync("http://localhost:5013/api/Message", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }

        return View();
    }
}