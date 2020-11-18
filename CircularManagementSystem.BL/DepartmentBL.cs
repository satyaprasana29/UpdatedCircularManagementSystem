using CircularManagementSystem.Entity;
using CircularManagementSystem.DAL;
using System.Collections.Generic;

namespace CircularManagementSystem.BL
{
    public interface IDepartmentBL
    {
        void AddDepartment(Department department);
        IEnumerable<Department> GetDepartment();
        Department GetOneDepartment(int departmentId);
        void DeleteDepartment(Department department);
        bool CheckDepartment(string departmentName);
    }
    public class DepartmentBL:IDepartmentBL
    {
        DepartmentRepository repository = new DepartmentRepository();
        public void AddDepartment(Department department)
        {
            repository.AddDepartment(department);
        }
        public IEnumerable<Department> GetDepartment()
        {
            return repository.GetDepartment();
        }
        public Department GetOneDepartment(int departmentId)
        {
            return repository.GetEachDepartment(departmentId);
        }
        public void DeleteDepartment(Department department)
        {
            repository.DeleteDepartment(department);
        }
        public bool CheckDepartment(string departmentName) => repository.CheckDepartment(departmentName);
    }
}
