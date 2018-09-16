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
            if (!courseGateway.IsExsit(course.Code, course.Name))
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

            else
            {
                return "Already Exist";
            }

        }

        public List<Course> GetCourses()
        {
            return courseGateway.GetCourses();
        }
    }
}