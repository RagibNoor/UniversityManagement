using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Bll;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
	public class CourseController : Controller
	{
		DepartmentBLL departmentBll = new DepartmentBLL();
        CourseBLL courseBll = new CourseBLL();
		//
		// GET: /Course/
		public ActionResult Index()
		{
			return View("Save");
		}

        [HttpGet]
		public ActionResult Save()

		{
			ViewBag.Departments = departmentBll.GetDepartments();
		    ViewBag.Semister = courseBll.GetSemister();

			return View();
		}
        [HttpPost]
        public ActionResult Save(Course course)
        {
            ViewBag.Departments = departmentBll.GetDepartments();
            ViewBag.Semister = courseBll.GetSemister();
            ViewBag.Message = courseBll.Save(course);

            return View();
        }
	}
}