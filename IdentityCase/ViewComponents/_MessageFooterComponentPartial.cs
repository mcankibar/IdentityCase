using Microsoft.AspNetCore.Mvc;

namespace IdentityCase.ViewComponents
{
    public class _MessageFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}
