using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoT_v6.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoT_v6.Models
{
    public enum priorityStatus
    {
        High,
        Medium,
        Low
    }

    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }        

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Created Date")]     
        public string CreatedDate { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public string DueDate { get; set; }

        [Display(Name = "Priority")]
        public priorityStatus Priority { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Employee")]
        [UIHint("List")]
        [NotMapped]
        public List<SelectListItem> Employed { get; set; }
        [NotMapped]
        public List<string>employee{ get; set; }

        public ToDo()
        {
            Employed = new List<SelectListItem>();
        }

        public void getEmployees(ApplicationDbContext _context)
        {
            var emp = from r in _context.Users select r;
            var listEmp = emp.ToList();
            foreach (var Data in listEmp)
            {
                Employed.Add(new SelectListItem()
                {
                    Value = Data.Id,
                    Text = Data.name
                });
            }
        }
        [NotMapped]
        public ICollection<EmployeeTodo> EmployeeTodo { get; set; }
















    }
}
