using CircularManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CircularManagementSystem.Models
{
    public class CircularModel
    {
     
        [Required]
        [RegularExpression("[a-zA-Z]*$", ErrorMessage = "Name should be Alphabet")]
        public string CircularName { get; set; }
        public string FilePath { get; set; }
        [Required]
        public HttpPostedFileBase CircularFile { get; set; }
        public List<int> SelectedChoices { get; set; }
        public List<Department> Departments { get; set; }
    }
}