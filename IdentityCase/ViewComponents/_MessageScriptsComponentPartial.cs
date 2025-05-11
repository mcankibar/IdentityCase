using Microsoft.AspNetCore.Mvc;

namespace IdentityCase.ViewComponents
{
    public class _MessageScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
