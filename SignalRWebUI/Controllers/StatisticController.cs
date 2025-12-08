using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class StatisticController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}