using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class MenuController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}