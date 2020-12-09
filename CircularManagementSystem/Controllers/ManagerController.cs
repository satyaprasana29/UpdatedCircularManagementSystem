using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using CircularManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CircularManagementSystem.Controllers
{
    /// <summary>
    /// class: Manager Controller
    /// This class have method for Add Circular,View Circular
    /// </summary>
    [Authorize(Roles ="Manager")]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult AddCircular()           //ADD circular to the database get method
        {
            IDepartmentBL departmentBL = new DepartmentBL();
            CircularModel circularModel = new CircularModel();
            circularModel.Departments = departmentBL.GetDepartment().ToList();
            circularModel.SelectedChoices = new List<int>();
            return View(circularModel);
        }
        [HttpPost]
        [Authorize(Roles ="Manager")]
        public ActionResult AddCircular(CircularModel circular)     //Add circular post method
        {
            string filename = Path.GetFileNameWithoutExtension(circular.CircularFile.FileName);
            string extension = Path.GetExtension(circular.CircularFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssff") + extension;
            circular.FilePath = filename;
            if (ModelState.IsValid)
            {
                Circular addCircular = AutoMapper.Mapper.Map<CircularModel, Circular>(circular);
                filename = Path.Combine(Server.MapPath("~/Circular/"), filename);
                ICircularBL circularBL = new CircularBL();
                circular.CircularFile.SaveAs(filename);
                circularBL.AddCircular(addCircular);
                int circularId = circularBL.GetCircularId(circular.FilePath);
                if(circularBL.AddCircularDepartments(circular.SelectedChoices, circularId))
                {
                    TempData["Message"] = "Added Successfully";
                    return View(circular);
                }
            }
                return RedirectToAction("ViewCircular");
            }
        [Authorize(Roles = "Manager")]          //View circular Method
        public ActionResult ViewCircular()      //VIew circular uploaded by manager
        {
            //var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Circular/"));
            CircularBL circularBL = new CircularBL();
            List<Circular> circulars = circularBL.ViewCircular();
            return View(circulars);
        }
        public FileResult DownloadFile(int id)      //Download circular
        {
            CircularBL circularBL = new CircularBL();
            Circular circular = circularBL.GetCircular(id);
            string path = circular.FilePath;
            return File("~/Circular/" + path, "text/plain", circular.CircularName);
        }
    }
}