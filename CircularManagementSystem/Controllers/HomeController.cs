using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using CircularManagementSystem.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CircularManagementSystem.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel accountModel)
        {
            //try
            {
                IEmployeeBL employeeBL = new EmployeeBL();
                Account account = new Account();
                if (ModelState.IsValid)
                {
                    account.EmployeeEmail = accountModel.UserName;
                    account.Password = accountModel.Password;
                    Account account1 = employeeBL.Login(account.EmployeeEmail, account.Password);
                    if(account1!=null)
                    {
                        FormsAuthentication.SetAuthCookie(account1.EmployeeEmail, false);

                        var authTicket = new FormsAuthenticationTicket(1, account1.EmployeeEmail, DateTime.Now, DateTime.Now.AddMinutes(20), false, account1.Role);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        HttpContext.Response.Cookies.Add(authCookie);
                        if (account1.Role == "Admin")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (account1.Role == "Manager")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (account1.Role == "User")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    ViewBag.Message = "User id or password is wrong";
                }
                return View();
            }
            //catch (Exception)
            //{
            //    return RedirectToAction("Error", "Home");
            //}
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}