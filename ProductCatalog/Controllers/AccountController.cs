using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Data.Auth;
using ProductCatalog.Service.ViewModels;

namespace ProductCatalog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    PasswordHash=model.Password
                };
                var result=await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var appUser = await _userManager.FindByNameAsync(model.UserName);
                if (appUser != null)
                {
                    bool found=await _userManager.CheckPasswordAsync(appUser, model.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(appUser,model.RememberMe);
                        return RedirectToAction("Index", "Product");
                    }
                }
                ModelState.AddModelError("", "user name or password is invalid");
            }
            return View(model);
        }
    }
}
