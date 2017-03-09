// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="Purchase_IndexThreeTables.cs" company="">
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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoT_v6.ViewModels
{
    /// <summary>
    /// Class Purchase_IndexThreeTables.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class Purchase_IndexThreeTables : Controller
    {
        /// <summary>
        /// Gets or sets the purchases new.
        /// </summary>
        /// <value>The purchases new.</value>
        public List<Purchase> Purchases_New { get; set; }
        /// <summary>
        /// Gets or sets the purchases purchased.
        /// </summary>
        /// <value>The purchases purchased.</value>
        public List<Purchase> Purchases_Purchased { get; set; }
        /// <summary>
        /// Gets or sets the purchases delivered.
        /// </summary>
        /// <value>The purchases delivered.</value>
        public List<Purchase> Purchases_Delivered { get; set; }
    }
}
