using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.MenuComponents;

public class _MenuNavbarComponetPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}