using IdentitySample.Models;
using IdentitySample.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentitySample.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagementController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();

            users = _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Email = u.Email,
                //Roles = u.Roles
            }).OrderBy(u => u.Email).ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            var user = await _userManager.FindByIdAsync(roleViewModel.UserId);
            await _userManager.AddToRoleAsync(user, roleViewModel.NewRole);

            return RedirectToAction("Index");
        }
    }
}
