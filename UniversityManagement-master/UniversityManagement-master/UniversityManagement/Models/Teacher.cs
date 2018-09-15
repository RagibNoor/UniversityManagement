using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Teacher
    {
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherEmail { get; set; }
        public int TeacherNumber { get; set; }
        public int TeacherDepId { get; set; }
        public int TeacherDesigId { get; set; }
        public decimal TeacherCredit { get; set; }
    }
}