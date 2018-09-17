using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class CourseAssign
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Teacher")]
        public int TeacherID { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Department")]

       public int DepartmentId { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Course Code")]

        public int CourseId { get; set; }

        public decimal CourseCredit { get; set; }
    }
}