// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="UpdateUserRoleModel.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoT_v6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RoT_v6.ViewModels
{
    /// <summary>
    /// Class UpdateUserRoleModel.
    /// </summary>
    public class UpdateUserRoleModel
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public IEnumerable<ApplicationUser> users { get; set; }
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public IEnumerable<IdentityRole> roles { get; set; }
    }

    /// <summary>
    /// Class PostRoleUpdateUserRoleModel.
    /// </summary>
    public class PostRoleUpdateUserRoleModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }
    }
}
