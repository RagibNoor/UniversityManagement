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
        public JsonResult IsCodeExist(string code)
        {
            List<Department> departments = departmentBll.GetDepartments();
            bool isExist = departments.FirstOrDefault(u => u.Code.ToLowerInvariant().Equals(code.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IsNameExist(string Name)
        {
            List<Department> departments = departmentBll.GetDepartments();
            bool isExist = departments.FirstOrDefault(u => u.Name.ToLowerInvariant().Equals(Name.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }  
	}
}