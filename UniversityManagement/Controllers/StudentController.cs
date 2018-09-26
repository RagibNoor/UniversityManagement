using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using UniversityManagement.Bll;
using UniversityManagement.Gateway;
using UniversityManagement.Models;
using UniversityManagement.ViewModel;

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
            string departmentCode = astudentBll.GetDepartmentCode(astudent.DepartmentId);
            string year = astudent.Date.Substring(0, 4);
            string count = astudentBll.GetNumberOFstudentInaDepartment(astudent.DepartmentId, year).ToString("000");

            astudent.Registration = departmentCode + "-" + year + "-" + count;
            ViewBag.Departments = departmentBll.GetDepartments();
            
            ViewBag.Message = astudentBll.Save(astudent);
            
         // GET: Employees/Create
       

            return View();
        }
        [HttpGet]
        public ActionResult StudentEnrollCourse()
        {
            ViewBag.Student = astudentBll.GetStudents();
            return View();
        }
        [HttpPost]
        public ActionResult StudentEnrollCourse(StudentEnrollCourse studentEnrollCourse)
        {
            if (astudentBll.SaveStudentEnrollCourse(studentEnrollCourse)>0)
            {
                ViewBag.Message = "Save";
            }
            ViewBag.Student = astudentBll.GetStudents();
            return View();
        }
        public ActionResult IsCourseEnrolled(int studentId , int courseId)
        {
            var result = astudentBll.IsCourseEnrolled(studentId, courseId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SelectedStudentInfo(int id)
        {
            List<StudentView> student = astudentBll.GetStudents();
            StudentView selectedStudent = student.SingleOrDefault(a => a.Id == id);
            return Json(selectedStudent, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult IsEmailExist(string email)
        {
            List<Student> students = astudentBll.GetEmail();
            bool isExist = students.FirstOrDefault(u => u.Email.ToLowerInvariant().Equals(email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AssignGrade()
        {
            ViewBag.Student = astudentBll.GetStudents();
            ViewBag.Grade = GetGrades();
            return View();
        }
        [HttpPost]
        public ActionResult AssignGrade(StudentEnrollCourse student)
        {
            ViewBag.Message = astudentBll.UpdateGrade(student);
            ViewBag.Student = astudentBll.GetStudents();
            ViewBag.Grade = GetGrades();
            return View();
        }
        public ActionResult SelectedStudentCourseEnroll(int Id)
        {
            List<StudentEnrollCourseView> student = astudentBll.GetSelectedStudetEnrollCourse(Id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewResult()
        {
            ViewBag.Student = astudentBll.GetStudents();

            return View();
        }
        public List<Grades> GetGrades()
        {
          List<Grades> grades = new List<Grades>
            {
                new Grades{Grade = "A+"},
                new Grades{Grade = "A"},
                new Grades{Grade = "A-"},
                new Grades{Grade = "B+"},
                new Grades{Grade = "B"},
                new Grades{Grade = "B-"},
                new Grades{Grade = "C+"},
                new Grades{Grade = "C"},
                new Grades{Grade = "C-"},
                new Grades{Grade = "D+"},
                new Grades{Grade = "D"},
                new Grades{Grade = "D-"},
                new Grades{Grade = "F"},
            };
            return grades;

        } 



    }
}