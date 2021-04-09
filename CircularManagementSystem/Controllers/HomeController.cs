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
    public enum EmployeeRole
    {
        Admin,
        Manager,
        User
    }
public class HomeController : Controller
    {
        IEmployeeBL employeeBL;
        IDepartmentBL departmentBL;
        public HomeController()
        {
            employeeBL = new EmployeeBL();
            departmentBL = new DepartmentBL();
        }
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
                        if (account.Role == EmployeeRole.Admin.ToString())
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (account.Role == EmployeeRole.Manager.ToString())
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (account.Role == EmployeeRole.User.ToString())
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
            ViewBag.Department = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.Designation = new SelectList(employeeBL.GetDesignations(), "DesignationId", "DesignationName");
            ViewBag.Manager = new SelectList(employeeBL.GetManagers(), "ManagerId", "ManagerName");
            string user = HttpContext.User.Identity.Name;
            Employee employee = employeeBL.GetEmployeeDetails(user);
            var employeeMap = AutoMapper.Mapper.Map<Employee, EmployeeModel>(employee);
            return View(employeeMap);
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}