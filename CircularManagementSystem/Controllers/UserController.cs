using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CircularManagementSystem.Controllers
{
    public class UserController : Controller
    {
        ICircularBL circularBL;
        public UserController()
        {
            circularBL = new CircularBL();
        }
        // GET: User
        public ActionResult ViewCircular()
        {
            
                CircularBL circularBL = new CircularBL();
                List<Circular> circulars = circularBL.ViewCircular();
                return View(circulars);
            
        }
    }
}