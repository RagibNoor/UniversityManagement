using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }


         [Required(ErrorMessage = "This Field is Required")]
         [Display(Name = "Department")]

        public int DepartmentId { get; set; }


         [Required(ErrorMessage = "This Field is Required")]
         [Display(Name = "Course")]

        public int CourseId { get; set; }


         [Required(ErrorMessage = "This Field is Required")]
         [Display(Name = "Room No")]

        public int RoomId { get; set; }


         [Required(ErrorMessage = "This Field is Required")]
         [Display(Name = "Day")]


        public string Day { get; set; }


         [Display(Name = "From")]

         [Required(ErrorMessage = "This Field is Required")]
        public string StartTime { get; set; }

         [Display(Name = "To")]

         [Required(ErrorMessage = "This Field is Required")]
        public string EndTime { get; set; }

    }
}