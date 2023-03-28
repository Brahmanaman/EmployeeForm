using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsForm.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter your Name")]
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal salary { get; set; }
    }
}
