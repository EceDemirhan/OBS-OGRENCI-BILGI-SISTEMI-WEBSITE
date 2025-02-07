using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication21.Models;
using WebApplication21.Models.ViewModels;

namespace WebApplication21.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            // ApplicationUser applicationUser = new ApplicationUser();
            //applicationUser.Name = "OEce";
            //applicationUser.UserName = "ozgeecedemirhan44@gmail.com";
            //applicationUser.Email = "ozgeecedemirhan44@gmail.com";
            // applicationUser.Surname = "Demirhan";
            // var result = await _userManager.CreateAsync(applicationUser, "ece123");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginmodel)
        {
            if (ModelState.IsValid)
           {
                var result = await _signInManager.PasswordSignInAsync(loginmodel.Email, loginmodel.Password, false, lockoutOnFailure: false);
             if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }


}
