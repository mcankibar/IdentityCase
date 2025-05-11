using IdentityCase.Entities;
using IdentityCase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCase.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {

            AppUser appUser = new AppUser()
            {

                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                SurName = model.Surname
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                // User created successfully
                return RedirectToAction("UserLogin", "Login");
            }
            else
            {
                // Handle errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

        }
    }
}
