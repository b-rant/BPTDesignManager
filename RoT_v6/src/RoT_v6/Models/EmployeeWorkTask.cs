using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace RoT_v6.Models
{

    public class EmployeeWorkTask
    {

        [ForeignKey("employeeId")]
        public string employeeId { get; set; }
        public ApplicationUser employee { get; set; }

        [ForeignKey("TaskId")]
        public int TaskId { get; set; }
        public WorkTask WorkTaskItem { get; set; }



    }



}
