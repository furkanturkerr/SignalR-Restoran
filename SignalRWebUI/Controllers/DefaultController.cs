using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}