using CircularManagementSystem.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CircularManagementSystem.Models
{
    public class DepartmentModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Name should be Alphabet")]
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
       
    }
}