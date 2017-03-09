// ***********************************************************************
// Assembly         : RoT_v6
// Author           : Mikel
// Created          : 03-09-2017
//
// Last Modified By : Mikel
// Last Modified On : 03-09-2017
// ***********************************************************************
// <copyright file="Job.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RoT_v6.Models
{
    /// <summary>
    /// Enum JobStatus
    /// </summary>
    public enum JobStatus
    {
        /// <summary>
        /// The active
        /// </summary>
        Active,
        /// <summary>
        /// The not ready
        /// </summary>
        NotReady,
        /// <summary>
        /// The completed
        /// </summary>
        Completed,
    }

    /// <summary>
    /// Class Job.
    /// </summary>
    public class Job
    {

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public int JobID { get; set; }
        /// <summary>
        /// Gets or sets the job number.
        /// </summary>
        /// <value>The job number.</value>
        [Display(Name = "Job Number")]

        [Required]
        public string jobNum { get; set; }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        [Required]
        public string Client { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the desired date.
        /// </summary>
        /// <value>The desired date.</value>
        [Required]
        [Display(Name = "Desired Delivery")]
        public string DesiredDate { get; set; }


        /// <summary>
        /// Gets or sets the complete date.
        /// </summary>
        /// <value>The complete date.</value>
        [Display(Name = "Completion Date")]
        public string CompleteDate { get; set; }

        /// <summary>
        /// Gets or sets the est cost.
        /// </summary>
        /// <value>The est cost.</value>
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Required]
        [Display(Name = "Estimated Cost")]
        public decimal EstCost { get; set; }

        /// <summary>
        /// Gets or sets the inv cost.
        /// </summary>
        /// <value>The inv cost.</value>
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Display(Name = "Invested Cost")]
        public decimal InvCost { get; set; }


        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public JobStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the est hours.
        /// </summary>
        /// <value>The est hours.</value>
        [Required]
        [Display(Name = "Estimated Hours")]
        public int EstHours { get; set; }


        /// <summary>
        /// Gets or sets the inv hours.
        /// </summary>
        /// <value>The inv hours.</value>
        [Display(Name = "Invested Hours (Stored in Minutes)")]
        public int InvHours { get; set; }

    }
}
