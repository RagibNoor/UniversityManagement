using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagement.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Bll
{
    public class CourseBLL
    {
        CourseGateway courseGateway = new CourseGateway();

        public List<Semister> GetSemister()
        {
            return courseGateway.GetSemister();
        }

        public string Save(Course course)
        {
          
                if (courseGateway.Save(course)> 0)
                {
                    return "Save";
                }
                else
                {
                    return "Error";
                }
            

            

        }

        public string SaveAssignTeacher(CourseAssign course)
        {
            if (courseGateway.SaveAssignTeacher(course)> 0)
            {
                return "Save";
            }
            else
            {
                return "Error";
            }
            
        }

        public List<Course> GetCourses()
        {
            return courseGateway.GetCourses();
        }
    }
}