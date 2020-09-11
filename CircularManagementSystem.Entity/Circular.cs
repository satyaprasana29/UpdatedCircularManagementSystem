using System.ComponentModel.DataAnnotations;

namespace CircularManagementSystem.Entity
{
    public class Circular
    {
        [Key]
        public int CircularId { get; set; }
        [Required]
        public string CircularName { get; set; }
        //[Required]
        //public string Message { get; set; }
        [Required]
        public string FilePath { get; set; }
    }
}
