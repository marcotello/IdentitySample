using IdentitySample.Data;
using IdentitySample.Models;
using IdentitySample.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace IdentitySample.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IdentitySampleContext _identitySampleContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(IdentitySampleContext identitySampleContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _identitySampleContext = identitySampleContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var vm = new UserManagementIndexViewModel
            {
                Users = _identitySampleContext.Users.OrderBy(u => u.Email).Include(u => u.Roles).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = await GetUserById(id);

            var vm = new UserManagementAddRoleViewModel
            {
                Roles = GetAllRoles(),
                UserId = id,
                Email = user.Email
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel vm)
        {
            var user = await GetUserById(vm.UserId);

            if (ModelState.IsValid)
            {
                var result = await _userManager.AddToRoleAsync(user, vm.NewRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            vm.Roles = GetAllRoles();
            vm.Email = user.Email;
            return View(vm);
        }

        private async Task<ApplicationUser> GetUserById(string id) => await _userManager.FindByIdAsync(id);

        private SelectList GetAllRoles() => new SelectList(_roleManager.Roles.OrderBy(r => r.Name));
    }
}
