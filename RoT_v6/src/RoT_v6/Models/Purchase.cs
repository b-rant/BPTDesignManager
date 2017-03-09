// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="Purchase.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoT_v6.Models
{

    /// <summary>
    /// Class Purchase.
    /// </summary>
    public class Purchase
    {
        /// <summary>
        /// Gets or sets the purch identifier.
        /// </summary>
        /// <value>The purch identifier.</value>
        [Key]
        public int purchID { get; set; }


        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public int JobID { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Purchase"/> is block.
        /// </summary>
        /// <value><c>true</c> if block; otherwise, <c>false</c>.</value>
        public bool Block { get; set; }


        /// <summary>
        /// Gets or sets the cost per.
        /// </summary>
        /// <value>The cost per.</value>
        [Display(Name = "Cost Per Unit")]
        public string CostPer { get; set; }

        /// <summary>
        /// Gets or sets the total cost.
        /// </summary>
        /// <value>The total cost.</value>
        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the vendor.
        /// </summary>
        /// <value>The vendor.</value>
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Display(Name = "Employee")]
        public string employeeId { get; set; }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>The request date.</value>
        [Display(Name = "Request Date")]
        public string RequestDate { get; set; }

        /// <summary>
        /// Gets or sets the ideal delete date.
        /// </summary>
        /// <value>The ideal delete date.</value>
        [Required]
        [Display(Name = "Desired Delivery")]
        public string IdealDelDate { get; set; }


        /// <summary>
        /// Gets or sets the purch date.
        /// </summary>
        /// <value>The purch date.</value>
        [Display(Name = "Date Purchased")]
        public string PurchDate { get; set; }

        /// <summary>
        /// Gets or sets the est arr date.
        /// </summary>
        /// <value>The est arr date.</value>
        [Display(Name = "Estimated Arrival")]
        public string EstArrDate { get; set; }

        /// <summary>
        /// Gets or sets the arrived date.
        /// </summary>
        /// <value>The arrived date.</value>
        [Display(Name = "Arrival Date")]
        public string ArrivedDate { get; set; }

    }
}
