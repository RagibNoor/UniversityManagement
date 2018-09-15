using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Bll;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBLL departmentBll = new DepartmentBLL();
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View("Save");
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            ViewBag.Message = departmentBll.Save(department);
            return View();
        }

        public ActionResult ViewAllDepartment()
        {
            List<Department> departments = departmentBll.GetDepartments();
            return View(departments);
        }
	}
}