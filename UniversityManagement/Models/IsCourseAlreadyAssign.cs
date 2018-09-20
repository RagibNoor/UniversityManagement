using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagement.Bll;

namespace UniversityManagement.Models
{
    public class IsCourseAlreadyAssign: ValidationAttribute
    {
        CourseBLL courseBll = new CourseBLL();
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    List<CourseAssign> teachers = courseBll.GetAssignCourses();
        //    bool isExist = teachers.FirstOrDefault(u => u.CourseId.Equals(value)) != null;

        //    var assignCourse = (CourseAssign) validationContext.ObjectInstance;
        //    if (isExist)
        //    {
        //        return new ValidationResult("Course Already assign"); 
        //    }
        //    else
        //    {
        //        return  ValidationResult.Success;
        //    }
        //}

        public override bool IsValid(object value)
        {
            List<CourseAssign> teachers = courseBll.GetAssignCourses();
            bool isExist = teachers.FirstOrDefault(u => u.CourseId.Equals(value)) != null;
            return !isExist;
        }
    }
}