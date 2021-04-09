using CircularManagementSystem.Entity;
using CircularManagementSystem.DAL;
using System.Collections.Generic;
namespace CircularManagementSystem.BL
{
    public enum EmployeeRole
    {
        Admin,
        Manager,
        User
    }
    public class EmployeeBL : IEmployeeBL
    {
        /// <summary>
        /// Class:EmployeeBL
        /// Employee Business layer inherits IEmployeeBL
        /// Class have methods to Get Values from Database table Managers,Deignations,Get Employee from database
        /// It also have methods to Add Employee,Edit and Delete Employee and check Employee already Exist and Add Account
        /// And have methods for choose role,set new password and change password 
        /// </summary>
        EmployeeRepository repository;
        public EmployeeBL()
        {
            repository = new EmployeeRepository();
        }
        public IEnumerable<EmployeeDesignation> GetDesignations()           //Get Designations from table
        {
            return repository.GetEmployeeDesignations();
        }
        public IEnumerable<Manager> GetManagers()               //Get Managers list from table
        {
            return repository.GetManager();
        }
        public string GetPassword(string employeeName, string employeePhoneNumber)      //Set new password
        {
            return employeeName.Substring(0, 1) + employeePhoneNumber.Substring(0, 1) + employeeName.Substring(employeeName.Length - 1, 1) + employeePhoneNumber.Substring(employeePhoneNumber.Length - 1, 1);
        }   
        public void AddEmployee(Employee employee)              //Add Employee into Database
        {
            repository.AddEmployee(employee);
        }
        public void AddAccount(Account account)                 //Add Account to database
        {
            repository.AddAccount(account);
        }
        public Account Login(string username, string password)          //Chack Login username and Password
        {
            return repository.Login(username, password);
        }
        public string ChooseRole(int managerId)                     //Choose role from database
        {
            string managerName = repository.GetRole(managerId);
            if (managerName == "CEO")
            {
                return EmployeeRole.Manager.ToString();
            }
            else if (managerName == "Admin Manager")
            {
                return EmployeeRole.Admin.ToString();
            }
            else if (managerName != null)
            {
                return EmployeeRole.User.ToString();
            }
            return "";
        }
        public int GetEmployeeId(string EmployeeEmail)          //Get EMployee Id for adding account
        {
            return repository.GetEmployeeId(EmployeeEmail);
        }
        public List<Employee> GetEmployees()            //Get Employees for Viewing Employees
        {
            return repository.GetEmployees();
        }
        public Employee GetEmployee(int employeeId)     //Get individual employee from database
        {
            return repository.GetEmployee(employeeId);
        }
        public void DeleteEmployee(Employee employee)   //Delete Employee from database
        {
            repository.DeleteEmployee(employee);
        }
        public void EditEmployee(Employee employee)     //Edit Employee in the table
        {
            repository.EditEmployee(employee);
        }
        public bool CheckEmployee(string employeeEmail, long phoneNumber)       //Check employee present in database
        {
            return repository.CheckEmployee(employeeEmail, phoneNumber);
        }
        public Account GetUserDetails(string email)                     //Get Employee details from database
        {
            return repository.GetUserDetails(email);
        }
        public bool UpdatePassword(string email,string password)        //Update password 
        {
            return repository.UpdatePassword(email,password);
        }
        public Employee GetEmployeeDetails(string email)
        {
            return repository.GetEmployeeDetails(email);
        }
    }
}
