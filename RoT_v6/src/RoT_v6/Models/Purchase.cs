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
        public string JobID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool Block { get; set; }
        public string CostPer { get; set; }
        public string TotalCost { get; set; }
        public string Vendor { get; set; }
        public string RequestDate { get; set; }
        public string IdealDelDate { get; set; }
        public string PurchDate { get; set; }
        public string EstArrDate { get; set; }
        public string ArrivedDate { get; set; }

    }
}
