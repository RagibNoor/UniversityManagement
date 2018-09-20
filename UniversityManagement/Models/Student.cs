using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }

        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "This Field is Required")]
        [Remote("IsEmailExist", "Student", ErrorMessage = "Email already exist")]
        public string Email { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public string Date { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Department")]

        public int DepartmentId { get; set; }

        public string Registration { get; set; }
 

    }

}