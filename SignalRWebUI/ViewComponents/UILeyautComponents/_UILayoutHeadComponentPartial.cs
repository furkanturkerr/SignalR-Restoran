using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILeyautComponents;

public class _UILayoutHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}