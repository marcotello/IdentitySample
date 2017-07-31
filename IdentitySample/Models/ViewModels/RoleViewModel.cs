using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySample.Models.ViewModels
{
    public class RoleViewModel
    {
        public string UserId { get; set; }
        public string  NewRole { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
