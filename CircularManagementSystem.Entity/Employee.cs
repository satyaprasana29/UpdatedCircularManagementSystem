using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircularManagementSystem.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string EmployeeName { get; set; }
        [Required]
        [Index(IsUnique =true)]
        public long EmployeePhoneNumber { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public Manager Manager { get;set; }
        [Required]
        public int DesignationId { get; set; }
        public EmployeeDesignation EmployeeDesignations { get; set; }
        [Required]
        public string EmployeeGender { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}
