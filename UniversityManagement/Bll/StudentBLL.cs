using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagement.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Bll
{
    public class StudentBLL
    {
         StudentGeteway astudentGetway = new StudentGeteway();

        public Department GetDepartmentCode(Student student)
        {
            return astudentGetway.GetDepartmentCode(student);
        }

    

        public string Save(Student student)
        {

            if (astudentGetway.Save(student) > 0)
            {
                return "Save";
            }
            else
            {
                return "Error";
            }

        }

        public List<Student> GetEmail()
        {
            return astudentGetway.GetEmail();
        }
    }

}