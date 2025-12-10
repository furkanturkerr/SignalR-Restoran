using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILeyautComponents;

public class _UILayoutNavbarComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}