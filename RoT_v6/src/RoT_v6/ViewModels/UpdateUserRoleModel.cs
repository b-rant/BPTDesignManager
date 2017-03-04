using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoT_v6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RoT_v6.ViewModels
{
    public class UpdateUserRoleModel
    {
        public IEnumerable<ApplicationUser> users { get; set; }
        public IEnumerable<IdentityRole> roles { get; set; }
    }

    public class PostRoleUpdateUserRoleModel
    {
        public string Id { get; set; }
        public string Role { get; set; }
    }
}
