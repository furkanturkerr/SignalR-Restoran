using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}