using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class AdminLayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}