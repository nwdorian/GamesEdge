using Infrastructure.Authorization;
using Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Users;

namespace Web.Controllers;

public class AccountController(UserManager<User> userManager) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegister input)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        User user = new() { UserName = input.Email, Email = input.Email };
        IdentityResult result = await userManager.CreateAsync(user, input.Password);
        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(input);
        }

        await userManager.AddToRoleAsync(user, Roles.Staff);

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
