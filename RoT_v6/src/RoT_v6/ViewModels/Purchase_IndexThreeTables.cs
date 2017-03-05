using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoT_v6.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoT_v6.ViewModels
{
    public class Purchase_IndexThreeTables : Controller
    {
        public List<Purchase> Purchases_New { get; set; }
        public List<Purchase> Purchases_Purchased { get; set; }
        public List<Purchase> Purchases_Delivered { get; set; }
    }
}
