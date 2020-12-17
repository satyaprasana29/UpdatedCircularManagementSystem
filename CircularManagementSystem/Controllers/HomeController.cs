using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using CircularManagementSystem.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CircularManagementSystem.Controllers
{
    /// <summary>
    /// class:Home Controller
    /// In this controller It have Index method for home page.
    /// It have Login method for Logging in application
    /// </summary>
    public class HomeController : Controller
    {
        
        // GET: Index
        public ActionResult Index()     //Home page of Controller
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()     //Login get method 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel accountModel)        //Login post method
        {
                IEmployeeBL employeeBL = new EmployeeBL();
                if (ModelState.IsValid)
                {
                    Account account = employeeBL.Login(accountModel.UserName, accountModel.Password);
                    if(account!=null)
                    {
                        FormsAuthentication.SetAuthCookie(account.EmployeeEmail, false);
                        var authTicket = new FormsAuthenticationTicket(1, account.EmployeeEmail, DateTime.Now, DateTime.Now.AddMinutes(20), false, account.Role);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        HttpContext.Response.Cookies.Add(authCookie);
                        if (account.Role == "Admin")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (account.Role == "Manager")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (account.Role == "User")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "User id or password is wrong";
                    }
                }
            return View();
        }
        public ActionResult LogOff()            //Log Out Function
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            IEmployeeBL employeeBL = new EmployeeBL();
            string user = HttpContext.User.Identity.Name;
            Account account = employeeBL.GetUserDetails(user);
            AccountPasswordModel accountPasswordModel = new AccountPasswordModel();
            accountPasswordModel.Password = account.Password;
            accountPasswordModel.UserName = account.EmployeeEmail;
            return View(accountPasswordModel);
        }
        [HttpPost]
        public ActionResult ChangePassword(AccountPasswordModel accountModel)
        {
           if(ModelState.IsValid)
            {
                IEmployeeBL employeeBL = new EmployeeBL();

                bool result = employeeBL.UpdatePassword(accountModel.UserName, accountModel.Password);
                if (result)
                {
                    ViewBag.Message = "Password Updated";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Please Try again!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult MyProfile()
        {
            IEmployeeBL employeeBL = new EmployeeBL();
            IDepartmentBL departmentBL = new DepartmentBL();
            ViewBag.Department = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.Designation = new SelectList(employeeBL.GetDesignations(), "DesignationId", "DesignationName");
            ViewBag.Manager = new SelectList(employeeBL.GetManagers(), "ManagerId", "ManagerName");
            string user = HttpContext.User.Identity.Name;
            Employee employee = employeeBL.GetEmployeeDetails(user);
            var employeeMap = AutoMapper.Mapper.Map<Employee, EmployeeModel>(employee);
            return View(employeeMap);
        }
    }
}