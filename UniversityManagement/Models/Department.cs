using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Remote("IsNameExist", "Department", ErrorMessage = "Name already exist")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code should be between 2 to 7  characters")]
        [Remote("IsCodeExist", "Department", ErrorMessage = "Code already exist")]
        public string Code { get; set; } 
    }
}