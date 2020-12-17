using CircularManagementSystem.Entity;
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
}
