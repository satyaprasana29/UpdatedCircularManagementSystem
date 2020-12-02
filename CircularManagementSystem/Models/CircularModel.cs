using CircularManagementSystem.Entity;
using System.Collections.Generic;
using System.Web;

namespace CircularManagementSystem.Models
{
    public class CircularModel
    {
        public string CircularName { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase CircularFile { get; set; }
        public List<int> SelectedChoices { get; set; }
        public List<Department> Departments { get; set; }
    }
}