using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CircularManagementSystem.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult AddCircular()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCircular(Circular circular)
        {
            
                ICircularBL circularBL = new CircularBL();
                circularBL.AddCircular(circular);
                TempData["Message"] = "Added Successfully";
                return RedirectToAction("ViewCircular");
            
        }
        public ActionResult ViewCircular()
        {
            
                ICircularBL circularBL = new CircularBL();
                List<Circular> circulars = circularBL.ViewCircular();
                return View(circulars);
            
        }
    }
}