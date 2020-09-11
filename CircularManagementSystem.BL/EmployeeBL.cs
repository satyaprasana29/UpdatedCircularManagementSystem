using CircularManagementSystem.Entity;
using CircularManagementSystem.DAL;
using System.Collections.Generic;
namespace CircularManagementSystem.BL
{
    public interface IEmployeeBL
    {
        IEnumerable<EmployeeDesignation> GetDesignations();
        IEnumerable<Manager> GetManagers();
        string GetPassword(string employeeName, string employeePhoneNumber);
        void AddEmployee(Employee employee);
        void AddAccount(Account account);
        Account Login(string username, string password);
        string ChooseRole(int managerId);
        List<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        void DeleteEmployee(Employee employee);
        void EditEmployee(Employee employee);
        int GetEmployeeId(string EmployeeEmail);
    }
    public enum EmployeeRole
    {
        Admin,
        Manager,
        User
    }
    public class EmployeeBL:IEmployeeBL
    {
        EmployeeRepository repository = new EmployeeRepository();
        public IEnumerable<EmployeeDesignation> GetDesignations()
        {
            return repository.GetEmployeeDesignations();
        }
        public IEnumerable<Manager> GetManagers()
        {
            return repository.GetManager();
        }
        public string GetPassword(string employeeName,string employeePhoneNumber)
        {
            return employeeName.Substring(0, 1) + employeePhoneNumber.Substring(0, 1) + employeeName.Substring(employeeName.Length - 1, 1)+ employeePhoneNumber.Substring(employeePhoneNumber.Length - 1, 1);
        }
        public void AddEmployee(Employee employee)
        {
            repository.AddEmployee(employee);
        }
        public void AddAccount(Account account)
        {
            repository.AddAccount(account);
        }
        public Account Login(string username, string password)
        {
            return repository.Login(username, password);
        }
        public string ChooseRole(int managerId)
        {
            string managerName = repository.GetRole(managerId);
            if(managerName== "CEO")
            {
                return EmployeeRole.Manager.ToString();
            }
            else if(managerName== "Admin Manager")
            {
                return EmployeeRole.Admin.ToString();
            }
            else if(managerName!=null)
            {
                return EmployeeRole.User.ToString();
            }
            return "";
        }
        public int GetEmployeeId(string EmployeeEmail)
        {
            return repository.GetEmployeeId(EmployeeEmail);
        }
        public List<Employee> GetEmployees()
        {
            return repository.GetEmployees();
        }
        public Employee GetEmployee(int employeeId)
        {
            return repository.GetEmployee(employeeId);
        }
        public void DeleteEmployee(Employee employee)
        {
            repository.DeleteEmployee(employee);
        }
        public void EditEmployee(Employee employee)
        {
            repository.EditEmployee(employee);
        }
    }
}
