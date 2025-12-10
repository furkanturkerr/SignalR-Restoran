using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILeyautComponents;

public class _UILayoutScriptComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }      
}