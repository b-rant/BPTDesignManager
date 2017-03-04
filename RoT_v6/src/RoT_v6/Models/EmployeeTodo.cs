using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RoT_v6.Models
{   

    public class EmployeeTodo
    {       

        [ForeignKey("employeeId")]
        public string employeeId { get; set; }
        public ApplicationUser employee { get; set; }
     
        [ForeignKey("ToDoId")]
        public int ToDoId { get; set; }         
        public ToDo todoItem { get; set; }





    }



}
