using CircularManagementSystem.Entity;
using CircularManagementSystem.DAL;
using System.Collections.Generic;

namespace CircularManagementSystem.BL
{
    
    public class DepartmentBL:IDepartmentBL
    {
        /// <summary>
        /// Class: DepartmentBL
        /// Department Business layer inherits the IDepartmentBL
        /// It have methods to AddDepartment,Get Department,check Department is present in database and Delete Department
        /// </summary>
        DepartmentRepository repository = new DepartmentRepository();
        public void AddDepartment(Department department)                //Add Department to database
        {
            repository.AddDepartment(department);
        }
        public IEnumerable<Department> GetDepartment()                  //Get Departments from Department
        {
            return repository.GetDepartment();
        }
        public Department GetOneDepartment(int departmentId)            //Return one department from database
        {
            return repository.GetEachDepartment(departmentId);
        }
        public void DeleteDepartment(Department department)             //Delete Department from database
        {
            repository.DeleteDepartment(department);
        }
        public bool CheckDepartment(string departmentName) => repository.CheckDepartment(departmentName);      //Check department present in database
    }
}
