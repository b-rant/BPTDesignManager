using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RightOnTime.Controllers
{
    public class TestController : Controller
    {
        // 
        // GET: /HelloWord/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public ActionResult Main()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
