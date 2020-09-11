using CircularManagementSystem.Entity;
using System.ComponentModel.DataAnnotations;
namespace CircularManagementSystem.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z]*$")]
        public string EmployeeName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[6-9][0-9]{9}$")]
        public long EmployeePhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string EmployeeEmail { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int DesignationId { get; set; }
        public EmployeeDesignation EmployeeDesignation { get; set; }
        [Required]
        public string EmployeeGender { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}