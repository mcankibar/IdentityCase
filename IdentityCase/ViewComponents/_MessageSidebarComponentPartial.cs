using IdentityCase.Context;
using IdentityCase.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCase.ViewComponents
{
    public class _MessageSidebarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public _MessageSidebarComponentPartial(UserManager<AppUser>userManager,ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEmail = user.Email;
            var inboxCount = _context.Messages.Count(m => m.ReceiverEmail == userEmail && m.IsRead == false);
            ViewBag.inboxCount = inboxCount;
            return View();
        }
    }
    
}
