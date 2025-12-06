using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Controllers;

public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("http://localhost:5013/api/Category");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View(new List<ResultCategoryDto>());
    }

    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        createCategoryDto.Status = true;
        var client = _httpClientFactory.CreateClient();
        var JsonData = JsonConvert.SerializeObject(createCategoryDto);
        StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PostAsync("http://localhost:5013/api/Category", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.DeleteAsync($"http://localhost:5013/api/Category/{id}");
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}