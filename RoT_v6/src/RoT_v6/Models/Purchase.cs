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

    public class Purchase
    {
        [Key]
        public int purchID { get; set; }
        public int JobID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool Block { get; set; }
        [Display(Name = "Cost Per Unit")]
        public string CostPer { get; set; }
        [Display(Name = "Total Cost")]
        public string TotalCost { get; set; }
        public string Vendor { get; set; }
        [Display(Name = "Request Date")]
        public string RequestDate { get; set; }
        [Display(Name = "Desired Delivery")]
        public string IdealDelDate { get; set; }
        [Display(Name = "Date Purchased")]
        public string PurchDate { get; set; }
        [Display(Name = "Estimated Arrival")]
        public string EstArrDate { get; set; }
        [Display(Name = "Arrival Date")]
        public string ArrivedDate { get; set; }

    }
}
