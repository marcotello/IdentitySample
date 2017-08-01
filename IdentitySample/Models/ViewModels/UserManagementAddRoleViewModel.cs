using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IdentitySample.Models.ViewModels
{
    public class UserManagementAddRoleViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string NewRole { get; set; }
        public SelectList Roles { get; set; }
    }
}
