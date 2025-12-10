using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class UILayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}