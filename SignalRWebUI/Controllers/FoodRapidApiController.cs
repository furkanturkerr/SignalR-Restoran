using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.FoodRapidApiDtos;

namespace SignalRWebUI.Controllers;

public class FoodRapidApiController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes"),
            Headers =
            {
                { "x-rapidapi-key", "228321f524msh2f2cbcfabd83e56p1d01fbjsn7b1af1c27a41" },
                { "x-rapidapi-host", "tasty.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultTastyApi>>(body);
            //return View(values.ToList());
            var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
            var values = root.results;
            return View(values);
        }
    }
}