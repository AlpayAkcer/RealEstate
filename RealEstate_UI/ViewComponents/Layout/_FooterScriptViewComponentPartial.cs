using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.Layout
{
    public class _FooterScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
