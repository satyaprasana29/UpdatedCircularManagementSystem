using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CircularManagementSystem.Entity
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Circular> Circulars { get; set; }
    }
}
