using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Bll;
using UniversityManagement.Models;
using UniversityManagement.ViewModel;

namespace UniversityManagement.Controllers
{
	public class CourseController : Controller
	{
		DepartmentBLL departmentBll = new DepartmentBLL();
        CourseBLL courseBll = new CourseBLL();
        TeacherBLL teacherBll = new TeacherBLL();
        
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

        [HttpGet]
        public ActionResult AssignTeacher()
        {
            ViewBag.Departments = departmentBll.GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult AssignTeacher(CourseAssign courseAssign)
        {
            ViewBag.Message = courseBll.SaveAssignTeacher(courseAssign);
            ViewBag.Departments = departmentBll.GetDepartments();
            return RedirectToAction("AssignTeacher");
        }
        public ActionResult SelectedDepartmentCourse(int id)
        {
            List<Course> courses = courseBll.GetCourses();
            var selectedCourse = courses.FindAll(a => a.DepartmentId == id).ToList();
            return Json(selectedCourse, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SelectedDepartmentTeacher(int id)
        {
            List<Teacher> teachers = teacherBll.GetTeachers();
            var selectedTeacher = teachers.FindAll(a => a.DepartmentId == id).ToList();
            return Json(selectedTeacher, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewCourseStatics()
        {
            ViewBag.Departments = departmentBll.GetDepartments();
            return View();
        }

        public ActionResult ViewCourseAssignToTeacher(int id)
        {
            List<CourseAssignToTeacherView> courses = courseBll.GetCourseAssignToTeacherViews(id);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult IsCourseExist(int Id)
        {
            List<CourseAssign> teachers = courseBll.GetAssignCourses();
            bool isExist = teachers.FirstOrDefault(u => u.CourseId.Equals(Id)) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }  
	}
}