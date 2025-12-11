using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents;

public class _TestimonialComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}