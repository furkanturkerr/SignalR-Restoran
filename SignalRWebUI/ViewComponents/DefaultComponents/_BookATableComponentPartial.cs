using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents;

public class _BookATableComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}