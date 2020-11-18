using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CircularManagementSystem.Entity
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        [Required]
        public string ManagerName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
