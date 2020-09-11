using CircularManagementSystem.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CircularManagementSystem.Models
{
    public class DepartmentModel
    {
        [Required]
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}