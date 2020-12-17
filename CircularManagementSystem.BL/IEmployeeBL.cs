using CircularManagementSystem.Entity;
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
        bool CheckEmployee(string employeeEmail, long phoneNumber);
        Account GetUserDetails(string email);
        bool UpdatePassword(string email,string password);
        Employee GetEmployeeDetails(string email);
    }
}
