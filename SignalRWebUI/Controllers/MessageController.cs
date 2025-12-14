using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class MessageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}