using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.ViewModel
{
    public class CourseAssignToTeacherView
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Semister { get; set; }
        public string AssignTo { get; set; }
    }
}