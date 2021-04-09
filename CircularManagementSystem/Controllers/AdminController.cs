using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using CircularManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
/*
 * Class:Admin Controller
 * Version:1.4
 * Author:Prasana Srinivasan M
 */
namespace CircularManagementSystem.Controllers
{
    /// <summary>
    /// class: Admin Controller 
    /// It have functions for Add,View and Delete department
    /// It also have functions for Add,View,Delete and Edit Employee
    /// </summary>
    [Authorize(Roles ="Admin")]
    [ExceptionHandler]
    public class AdminController : Controller
    {
        IDepartmentBL departmentBL;
        IEmployeeBL employeeBL;
        public AdminController(IDepartmentBL departmentBL,IEmployeeBL employeeBL)                    //Constructor of Admin Controller
        {
            this.departmentBL = departmentBL;
            this.employeeBL = employeeBL;

        }
        // GET: Admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddDepartment()         //Get method of Adding Department
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddDepartment(DepartmentModel departmentModel)      //Post method of Adding Department
        {
            bool check = false;
            bool result = this.departmentBL.CheckDepartment(departmentModel.DepartmentName.ToLower());
                if (ModelState.IsValid&&result==check)
                {
                    Department department = new Department();
                    department.DepartmentName = departmentModel.DepartmentName;
                    departmentBL.AddDepartment(department);
                }
                else if(result!=check)
                {
                    ViewBag.Message = "Department Name already exist";
                }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ViewDepartment()        //View Department Details
        {
                IEnumerable<Department> departments = this.departmentBL.GetDepartment();
                return View(departments);
            
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDepartment(int departmentId)      //Delete Department Details GEt Method
        {
                Department department = this.departmentBL.GetOneDepartment(departmentId);
                return View(department);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDepartment(Department department)     //DElete Department Details Post Method
        {
                this.departmentBL.DeleteDepartment(department);
                return RedirectToAction("ViewDepartment");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddEmployee()           //Add Employee GEt Method
        {
           
                ViewBag.Department = new SelectList(this.departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                ViewBag.Designation = new SelectList(this.employeeBL.GetDesignations(), "DesignationId", "DesignationName");
                ViewBag.Manager = new SelectList(this.employeeBL.GetManagers(), "ManagerId", "ManagerName");
                return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddEmployee(EmployeeModel employeeModel)        //Add Employee Post method
        {
            bool check = false;
                ViewBag.Department = new SelectList(this.departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                ViewBag.Designation = new SelectList(this.employeeBL.GetDesignations(), "DesignationId", "DesignationName");
                ViewBag.Manager = new SelectList(this.employeeBL.GetManagers(), "ManagerId", "ManagerName");
                bool result = employeeBL.CheckEmployee(employeeModel.EmployeeEmail, employeeModel.EmployeePhoneNumber);
                
                if (ModelState.IsValid&&result==check)
                {
                    var employeeMap = AutoMapper.Mapper.Map<EmployeeModel, Employee>(employeeModel);
                    employeeBL.AddEmployee(employeeMap);
                    AddAccount(employeeModel);
                    return RedirectToAction("ViewEmployee", "Admin");
                }
                else if(result!=check)
                {
                ViewBag.Message = "Employee already exist";
                }
                return View();
            
        }
        private void AddAccount(EmployeeModel employeeModel)        //Create Account for employee
        {
            Account account = new Account
            {
                EmployeeId = employeeBL.GetEmployeeId(employeeModel.EmployeeEmail),
                EmployeeEmail = employeeModel.EmployeeEmail,
                Password = this.employeeBL.GetPassword(employeeModel.EmployeeName, Convert.ToString(employeeModel.EmployeePhoneNumber)),
                Role = this.employeeBL.ChooseRole(employeeModel.ManagerId)
            };
            employeeBL.AddAccount(account);

        }
        [Authorize(Roles = "Admin")]
        public ActionResult ViewEmployee()      //View Employee Details
        {
                List<Employee> employees = this.employeeBL.GetEmployees();
                return View(employees);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditEmployee(int employeeId)        //Edit employee details get  method
        {
            if(ModelState.IsValid)
            {
                ViewBag.Department = new SelectList(this.departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                ViewBag.Designation = new SelectList(this.employeeBL.GetDesignations(), "DesignationId", "DesignationName");
                ViewBag.Manager = new SelectList(this.employeeBL.GetManagers(), "ManagerId", "ManagerName");
                Employee employee = this.employeeBL.GetEmployee(employeeId);
                var employeeMap = AutoMapper.Mapper.Map<Employee, EmployeeModel>(employee);
                return View(employeeMap);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditEmployee(Employee employee)         //Edit employee details post method
        {
            
                ViewBag.Department = new SelectList(this.departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
                employeeBL.EditEmployee(employee);
                return RedirectToAction("ViewEmployee");
            
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEmployee(int employeeId)      //Delete employee details get method
        {
            
                Employee employee = this.employeeBL.GetEmployee(employeeId);
                return View(employee);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEmployee(Employee employee)       //Delete employee Details post method
        {
            
                this.employeeBL.DeleteEmployee(employee);
                return RedirectToAction("ViewEmployee");
            
        }
        
    }
}