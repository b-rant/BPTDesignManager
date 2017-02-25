using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RoT_v6.Models
{   

    public class EmployeeTodo
    {
        public string employeeId { get; set; }
        public int todoID { get; set; }
        public ApplicationUser employee { get; set; }        
        public ToDo todoItem { get; set; }

    }
}
