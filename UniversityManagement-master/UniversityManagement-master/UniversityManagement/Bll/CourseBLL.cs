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

        private CourseGateway aTeacherGetway = new CourseGateway();

        public List<Department> GetAllDepartment()
        {
            return aTeacherGetway.GetAllDepartment();
        }

        public List<Designation> GetAllDesignations()
        {
            return aTeacherGetway.GetAllDesignation();
        }

        public string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacherGetway.SaveTeacher(aTeacher) > 0)
            {
                return "Save Teacher Info";
            }
            else
            {
                return "Error";
            }
        }
    }
}