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
        
            [HttpGet]
        public JsonResult IsCodeExist(string code)
        {
            List<Course> courses = courseBll.GetCourses();
            bool isExist = courses.FirstOrDefault(u => u.Code.ToLowerInvariant().Equals(code.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IsNameExist(string Name)
        {
            List<Course> courses = courseBll.GetCourses();
            bool isExist = courses.FirstOrDefault(u => u.Name.ToLowerInvariant().Equals(Name.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssignTeacher()
        {
            ViewBag.Departments = departmentBll.GetDepartments();
            return View();
        }
        public ActionResult SelectedDepartment(int id)
        {
            List<Course> courses = courseBll.GetCourses();
            var selectedCustomer = courses.FindAll(a => a.DepartmentId == id).ToList();
            return Json(selectedCustomer, JsonRequestBehavior.AllowGet);
        }
	}
}