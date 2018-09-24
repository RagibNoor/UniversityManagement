using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.ViewModel
{
    public class StudentEnrollCourseView
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Grade { get; set; }
        public int CourseId { get; set; }
    }
}