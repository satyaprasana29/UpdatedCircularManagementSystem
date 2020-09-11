using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircularManagementSystem.Entity
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string EmployeeEmail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
