using CircularManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace CircularManagementSystem.DAL
{
    public class EmployeeRepository
    {
        
        public IEnumerable<EmployeeDesignation> GetEmployeeDesignations()
        {
            using (ContextClass contextClass = new ContextClass())
            {
                return contextClass.EmployeeDesignations.ToList();
            }
                
        }
        public IEnumerable<Manager> GetManager()
        {
            using (ContextClass contextClass = new ContextClass())
            {
                return contextClass.Managers.ToList();
            }   
        }
        public void AddEmployee(Employee employee)
        {
            using (ContextClass contextClass = new ContextClass())
            {
                
                contextClass.Employees.Add(employee);
                contextClass.SaveChanges();
            }
        }
        public void AddAccount(Account account)
        {
            using (ContextClass contextClass = new ContextClass())
            {
                contextClass.Accounts.Add(account);
                contextClass.SaveChanges();
            }
        }
        public Account Login(string username, string password)
        {
            using (ContextClass contextClass = new ContextClass())
            {
                Account account = contextClass.Accounts.Where(x => x.EmployeeEmail == username).Where(y => y.Password == password).SingleOrDefault();
                return account;
            }
        }
        public string GetRole(int managerId)
        {
            using(ContextClass contextClass=new ContextClass())
            {
                Manager manager = contextClass.Managers.Where(x => x.ManagerId == managerId).SingleOrDefault();
                if(manager!=null)
                {
                    return manager.ManagerName;
                }
            }
            return "";
        }
        public void DeleteEmployee(Employee employee)
        {
            using(ContextClass contextClass = new ContextClass())
            {
                SqlParameter EmployeeId = new SqlParameter("@EmployeeId", employee.EmployeeId);
                contextClass.Database.ExecuteSqlCommand("Employee_Delete @EmployeeId", EmployeeId);
            }
        }
        public bool CheckEmployee(string employeeEmail,long phoneNumber)
        {
            using(ContextClass contextClass=new ContextClass())
            {
                Employee employee= contextClass.Employees.Where(x => x.EmployeeEmail == employeeEmail).Where(y => y.EmployeePhoneNumber == phoneNumber).SingleOrDefault();
                if(employee!=null)
                {
                    return true;
                }
                return false;
            }
        }
        public List<Employee> GetEmployees()
        {
            using (ContextClass contextClass = new ContextClass())
            {
                return contextClass.Employees.Include("Departments").Include("EmployeeDesignations").Include("Manager").ToList();
            }
        }
        public Employee GetEmployee(int employeeid)
        {
            using(ContextClass contextClass = new ContextClass())
            {
                Employee employee = contextClass.Employees.Include("Departments").Where(id => id.EmployeeId == employeeid).SingleOrDefault();
                return employee;
            }
        
        }
        public int GetEmployeeId(string EmployeeEmail)
        {
            using(ContextClass contextClass=new ContextClass())
            {
                Employee employee= contextClass.Employees.Where(x => x.EmployeeEmail == EmployeeEmail).SingleOrDefault();
                return employee.EmployeeId;
            }
        }
        public void EditEmployee(Employee employee)
        {
            using(ContextClass contextClass = new ContextClass())
            {
                //SqlParameter EmployeeId = new SqlParameter("@EmployeeId", employee.EmployeeId);
                //SqlParameter EmployeeName = new SqlParameter("@EmployeeName", employee.EmployeeName);
                //SqlParameter EmployeePhoneNumber = new SqlParameter("@EmployeePhoneNumber", employee.EmployeePhoneNumber);
                //SqlParameter EmployeeGender = new SqlParameter("@EmployeeGender", employee.EmployeeGender);
                ////SqlParameter EmployeeEmail = new SqlParameter("@EmployeeEmail", employee.EmployeeEmail);
                //SqlParameter DepartmentId = new SqlParameter("@DepartmentId", employee.DepartmentId);
                //SqlParameter DesignationId = new SqlParameter("@DesignationId", employee.DesignationId);
                //SqlParameter ManagerId = new SqlParameter("@ManagerId", employee.ManagerId);
                //var result = contextClass.Database.ExecuteSqlCommand("Employee_Update @EmployeeId,@EmployeeName, @EmployeePhoneNumber, @ManagerId, @DesignationId, @EmployeeGender, @DepartmentId", EmployeeId, EmployeeName, EmployeePhoneNumber, ManagerId, DesignationId, EmployeeGender, DepartmentId);
                contextClass.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                contextClass.SaveChanges();
            }
        }
    }
}
