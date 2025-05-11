using Microsoft.AspNetCore.Mvc;

namespace IdentityCase.ViewComponents
{
    public class _MessageHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
