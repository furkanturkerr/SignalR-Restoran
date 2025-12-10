using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILeyautComponents;

public class _UILayoutFooterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}