using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentitySample.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void Seed()
        {
            if((await _roleManager.FindByNameAsync("Admin")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }

            if ((await _roleManager.FindByNameAsync("Sales")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Sales" });
            }

            if ((await _roleManager.FindByNameAsync("Reservations")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Reservations" });
            }
        }
    }
}
