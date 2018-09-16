using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field is Required")]

        public string Address { get; set; }

        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "This Field is Required")]
        [Remote("IsEmailExist", "Teacher", ErrorMessage = "Email already exist")]
        public string Email { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Department")]

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Credit To Be Taken")]
        [Range(0.0, Double.MaxValue , ErrorMessage = "Please input a Positive Number")]
        public decimal CreditToBeTaken { get; set; }
    }
}