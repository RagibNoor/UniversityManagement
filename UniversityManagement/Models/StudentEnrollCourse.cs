using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class StudentEnrollCourse
    {
        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Registration No")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]

        public string Date { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]

        public string Grade { get; set; }
    }
}