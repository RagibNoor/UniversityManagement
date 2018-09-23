using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityManagement.Bll;
using UniversityManagement.Models;
using UniversityManagement.ViewModel;

namespace UniversityManagement.Controllers
{
    public class ClassRoomController : Controller
    {
        DepartmentBLL departmentBll = new DepartmentBLL();
        CourseBLL courseBll = new CourseBLL();
        ClassRoomAllocationBLL classRoomAllocationBll = new ClassRoomAllocationBLL();
        //
        // GET: /ClassRoom/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Departments = departmentBll.GetDepartments();
            ViewBag.days = Weekdayses();
            ViewBag.Rooms = classRoomAllocationBll.GetRooms();
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClassRoom classRoom)
        {
            ViewBag.Message = classRoomAllocationBll.AllocateClassRoom(classRoom);
            ViewBag.Departments = departmentBll.GetDepartments();
            ViewBag.days = Weekdayses();
            ViewBag.Rooms = classRoomAllocationBll.GetRooms();
            return View();
        }

        [HttpGet]
        public ActionResult ViewClassRoomAllocation()
        {
            ViewBag.Departments = departmentBll.GetDepartments();
            return View();
        }

        public ActionResult ViewCourseAssignToTeacher(int id)
        {
            List<ClassRoomAllocationView> courses = classRoomAllocationBll.ViewClassRoomAllocation(id);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        public List<Weekdays> Weekdayses()
        {
            List<Weekdays> weekdayses =  new List<Weekdays>
            {
                new Weekdays{Name = "Sunday"},
                new Weekdays{Name = "Monday"},
                new Weekdays{Name = "Tuesday"},
                new Weekdays{Name = "Wednesday"},
                new Weekdays{Name = "Thrusday"},
                new Weekdays{Name = "Friday"},
                new Weekdays{Name = "Saturday"}

            };
            return weekdayses;
        } 

    }
}