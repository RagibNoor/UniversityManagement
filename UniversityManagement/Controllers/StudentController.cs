using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Bll;
using UniversityManagement.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class StudentController : Controller
    {
        private StudentBLL astudentBll = new StudentBLL();
        private DepartmentBLL departmentBll = new DepartmentBLL();
        //
        // GET: /Student/
        public ActionResult Index()
        {
            ViewBag.Departments = departmentBll.GetDepartments();
            return View();
        }


        [HttpPost]
        public ActionResult Index(Student astudent)
        {
            StudentGeteway astGeteway=new StudentGeteway();
            ViewBag.Departments = departmentBll.GetDepartments();
            ViewBag.Departmentcode = astudentBll.GetDepartmentCode(astudent);
            ViewBag.Message = astudentBll.Save(astudent);
            
         // GET: Employees/Create
       

            return View();
        }

        [HttpGet]
        public JsonResult IsEmailExist(string email)
        {
            List<Student> students = astudentBll.GetEmail();
            bool isExist = students.FirstOrDefault(u => u.Email.ToLowerInvariant().Equals(email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }



    }
}