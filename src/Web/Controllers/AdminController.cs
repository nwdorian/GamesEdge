using Infrastructure.Authorization;
using Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Admin;
using Web.Models.Admin.Items;

namespace Web.Controllers;

public class AdminController(UserManager<User> userManager) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IList<User> staff = await userManager.GetUsersInRoleAsync(Roles.Staff);

        return View(new AdminIndex { Staff = staff.Select(s => new StaffItem(s)).ToList() });
    }
}
