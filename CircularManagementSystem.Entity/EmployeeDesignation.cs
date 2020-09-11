using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CircularManagementSystem.Entity
{
    public class EmployeeDesignation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
