using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Controllers;

public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("http://localhost:5013/api/Product/ProductListWithCategory");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        return View(new List<ResultProductDto>());
    }
    
     [HttpGet]
    public IActionResult CreateProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        createProductDto.Status = true;
        var client = _httpClientFactory.CreateClient();
        var JsonData = JsonConvert.SerializeObject(createProductDto);
        StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PostAsync("http://localhost:5013/api/Product/", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.DeleteAsync($"http://localhost:5013/api/Product/{id}");
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync($"http://localhost:5013/api/Product/{id}");
        if (responsemessage.IsSuccessStatusCode)
        {
            var JsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(JsonData);
            return View(values);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateProductDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responsemessage = await client.PutAsync($"http://localhost:5013/api/Product/", stringContent);
        if (responsemessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }
}