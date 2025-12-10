using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents;

public class _OfferComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}