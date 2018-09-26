using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Gateway;

namespace UniversityManagement.Controllers
{
    public class ResetController : Controller
    {
        ResetGateway reset = new ResetGateway();
        //
        // GET: /Reset/
        [HttpGet]
        public ActionResult UnAssignCourses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAssignCourses(int id)
        {
            reset.UnAssignCourses();
            return View();
        }
        [HttpGet]
        public ActionResult UnalocateClassroom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnalocateClassroom(int id)
        {
            reset.UnallocateClassroom();
            return View();
        }
	}
}