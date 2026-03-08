using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSFD_UserAuthInMemoryApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MSFD_UserAuthInMemoryApp.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Users()
    {
        var users = _userManager.Users.ToList();

        return View(users);
    }

    [HttpGet]
    public IActionResult UsersJson()
    {
        var users = _userManager.Users
            .Select(u => new { u.Email, u.UserName })
            .ToList();

        return Json(users);
    }
}
