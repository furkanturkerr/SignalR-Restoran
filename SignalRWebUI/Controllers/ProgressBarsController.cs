using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class ProgressBarsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}