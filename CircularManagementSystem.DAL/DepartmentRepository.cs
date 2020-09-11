using CircularManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CircularManagementSystem.DAL
{
    public class DepartmentRepository
    {
        public void AddDepartment(Department department)
        {
            using(ContextClass contextClass = new ContextClass())
            {
                contextClass.departments.Add(department);
                contextClass.SaveChanges();
            }
        }
        public IEnumerable<Department> GetDepartment()
        {
            using(ContextClass contextClass = new ContextClass())
            return contextClass.departments.ToList();
        }
        public void DeleteDepartment(Department department)
        {
            using (ContextClass contextClass = new ContextClass())
            {
                Department departmentDetail = contextClass.departments.Where(id => id.DepartmentId == department.DepartmentId).SingleOrDefault();
                contextClass.departments.Attach(departmentDetail);
                contextClass.departments.Remove(departmentDetail);
                contextClass.SaveChanges();
            }
        }
        public Department GetEachDepartment(int departmentId)
        {
            using (ContextClass contextClass = new ContextClass())
            {
                Department department = contextClass.departments.Where(id => id.DepartmentId == departmentId).SingleOrDefault();
                return department;
            }
        }
    }
    
}
