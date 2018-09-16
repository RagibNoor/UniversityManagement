using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "This Field is Required")]
         [Remote("IsNameExist", "Course", ErrorMessage = "Name already exist")]
        public string Name { get; set; }

         [Required(ErrorMessage = "This Field is Required")]
         [StringLength(100, MinimumLength = 5, ErrorMessage = "Code should be 5  characters")]
         [Remote("IsCodeExist", "Course", ErrorMessage = "Code already exist")]
        public string Code { get; set; }


         [Required(ErrorMessage = "This Field is Required")]
         [Range(0.5, 5, ErrorMessage = "Please input Between 0.5 to 5")]
        public decimal Credit { get; set; }

        public string Description { get; set; }

         [Required(ErrorMessage = "This Field is Required")]
         [Display(Name = "Department")]

        public int DepartmentId { get; set; }

         [Required(ErrorMessage = "This Field is Required")]
         [Display(Name = "Semister")]
        public int SemisterId { get; set; }
    }
}