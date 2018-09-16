using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagement.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Bll
{
    public class TeacherBLL
        
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        public List<Designation> GetDesignation()
        {
            return teacherGateway.GetDesignation();
        }

        public string Save(Teacher teacher)
        {
            
            if (teacherGateway.Save(teacher)>0)
            {
                return "Save";
            }
            else
            {
                return "Error";
            }
        }

        public List<Teacher> GetTeachers()
        {
            return teacherGateway.GetTeachers();
        }
    }
}