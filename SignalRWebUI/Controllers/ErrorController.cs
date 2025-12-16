using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class ErrorController : Controller
{
    // GET
    public IActionResult NotFount404Page()
    {
        return View();
    }
}