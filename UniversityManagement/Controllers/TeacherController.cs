using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Bll;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
	public class TeacherController : Controller
	{
        DepartmentBLL departmentBll = new DepartmentBLL();
        TeacherBLL teacherBll = new TeacherBLL();
		//
		// GET: /Teacher/
		[HttpGet]
		public ActionResult Index()
		{
            ViewBag.Departments = departmentBll.GetDepartments();
		    ViewBag.Designations = teacherBll.GetDesignation();
			return View();
		}
		
		[HttpPost]
		public ActionResult Index(Teacher teacher)
		{
            ViewBag.Departments = departmentBll.GetDepartments();
            ViewBag.Designations = teacherBll.GetDesignation();
		    ViewBag.Message = teacherBll.Save(teacher);

			return View();
		}

        [HttpGet]  
        public JsonResult IsEmailExist(string email)
        {
            List<Teacher> teachers = teacherBll.GetTeachers();
            bool isExist = teachers.FirstOrDefault(u => u.Email.ToLowerInvariant().Equals(email.ToLower())) != null;  
            return Json(!isExist, JsonRequestBehavior.AllowGet);  
        }  
	}
}