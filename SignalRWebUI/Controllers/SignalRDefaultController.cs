using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class SignalRDefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Index2()
    {
        return View();
    }
}