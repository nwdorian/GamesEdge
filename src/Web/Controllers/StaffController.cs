using Infrastructure.Authorization;
using Infrastructure.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Constants;
using Web.Models.Staff;

namespace Web.Controllers;

public class StaffController(UserManager<User> userManager) : Controller
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return PartialView(Partials.CreateStaff);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StaffCreate model)
    {
        if (!ModelState.IsValid)
        {
            return PartialView(Partials.CreateStaff, model);
        }

        User user = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email,
            Email = model.Email,
            EmailConfirmed = true,
        };

        IdentityResult result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return PartialView(Partials.CreateStaff, model);
        }

        await userManager.AddToRoleAsync(user, Roles.Staff);

        return Created();
    }
}
