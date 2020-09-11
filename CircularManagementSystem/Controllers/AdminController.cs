using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using CircularManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CircularManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        IDepartmentBL departmentBL;
        IEmployeeBL employeeBL;
        public AdminController()
        {
            employeeBL = new EmployeeBL();
            departmentBL = new DepartmentBL();
        }
        // GET: Admin
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(DepartmentModel departmentModel)
        {
                if (ModelState.IsValid)
                {
                    Department department = new Department();
                    department.DepartmentName = departmentModel.DepartmentName;
                    departmentBL.AddDepartment(department);
                }
           
            return View();
        }
        public ActionResult ViewDepartment()
        {
                IEnumerable<Department> departments = departmentBL.GetDepartment();
                return View(departments);
            
        }
        [HttpGet]
        public ActionResult DeleteDepartment(int departmentId)
        {
                Department department = departmentBL.GetOneDepartment(departmentId);
                return View(department);
        }
        [HttpPost]
        public ActionResult DeleteDepartment(Department department)
        {
                departmentBL.DeleteDepartment(department);
                return RedirectToAction("ViewDepartment");
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
           
                ViewBag.Department = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                ViewBag.Designation = new SelectList(employeeBL.GetDesignations(), "DesignationId", "DesignationName");
                ViewBag.Manager = new SelectList(employeeBL.GetManagers(), "ManagerId", "ManagerName");
                return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(EmployeeModel employeeModel)
        {
           
                ViewBag.Department = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                ViewBag.Designation = new SelectList(employeeBL.GetDesignations(), "DesignationId", "DesignationName");
                ViewBag.Manager = new SelectList(employeeBL.GetManagers(), "ManagerId", "ManagerName");
                if (ModelState.IsValid)
                {
                    var employeeMap = AutoMapper.Mapper.Map<EmployeeModel, Employee>(employeeModel);
                    employeeBL.AddEmployee(employeeMap);
                    AddAccount(employeeModel);
                    return RedirectToAction("ViewEmployee", "Admin");
                }
                return View();
            
        }
        private void AddAccount(EmployeeModel employeeModel)
        {
            Account account = new Account();
            account.EmployeeId = employeeBL.GetEmployeeId(employeeModel.EmployeeEmail);
            account.EmployeeEmail = employeeModel.EmployeeEmail;
            account.Password = employeeBL.GetPassword(employeeModel.EmployeeName, Convert.ToString(employeeModel.EmployeePhoneNumber));
            account.Role = employeeBL.ChooseRole(employeeModel.ManagerId);
            employeeBL.AddAccount(account);

        }
        public ActionResult ViewEmployee()
        {
                List<Employee> employees = employeeBL.GetEmployees();
                return View(employees);
        }
        [HttpGet]
        public ActionResult EditEmployee(int employeeId)
        {
            
                ViewBag.Department = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                ViewBag.Designation = new SelectList(employeeBL.GetDesignations(), "DesignationId", "DesignationName");
                ViewBag.Manager = new SelectList(employeeBL.GetManagers(), "ManagerId", "ManagerName");
                Employee employee = employeeBL.GetEmployee(employeeId);
                var employeeMap = AutoMapper.Mapper.Map<Employee, EmployeeModel>(employee);
                return View(employeeMap);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee employee)
        {
            
                ViewBag.Department = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                employeeBL.EditEmployee(employee);
                return RedirectToAction("ViewEmployee");
            
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int employeeId)
        {
            
                Employee employee = employeeBL.GetEmployee(employeeId);
                return View(employee);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(Employee employee)
        {
            
                employeeBL.DeleteEmployee(employee);
                return RedirectToAction("ViewEmployee");
            
        }
    }
}