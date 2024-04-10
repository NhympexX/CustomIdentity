using CustomIdentity.Models;
using CustomIdentity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CustomIdentity.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> manager,UserManager<AppUser> umanager )
        {
            signInManager = manager;
            userManager = umanager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if(ModelState.IsValid)
            {
                var result = await  signInManager.PasswordSignInAsync(model.username!, model.password!,model.rememberMe,false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Attempt");
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Name = model.Name,
                    Email = model.Email,
                    Adress = model.Adress,
                    UserName = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                {
                   await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                return View(model);

            }
            return View(model);
        }



        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login","account");
        }

    }
}
