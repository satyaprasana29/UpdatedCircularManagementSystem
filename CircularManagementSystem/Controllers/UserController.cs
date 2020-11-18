using CircularManagementSystem.BL;
using CircularManagementSystem.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CircularManagementSystem.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Class:User Controller
        /// It have function for View circular
        /// Download file for downloding file from database
        /// </summary>
        ICircularBL circularBL;
        public UserController()         //Constructor for intiating objects 
        {
            circularBL = new CircularBL();
        }
        // GET: User
        public ActionResult ViewCircular()      //VIew circular uploaded by manager
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Circular/"));
                CircularBL circularBL = new CircularBL();
            List<Circular> circulars = circularBL.ViewCircular();
                return View(circulars);
        }
        public FileResult DownloadFile(int id)      //Download circular
        {
            Circular circular = circularBL.GetCircular(id);
            string path = circular.FilePath;
            return File("~/Circular/"+path, "text/plain", circular.CircularName);
            //return File(circular.FilePath, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}