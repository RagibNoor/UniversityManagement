using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagement.Gateway;
using UniversityManagement.Models;
using UniversityManagement.ViewModel;

namespace UniversityManagement.Bll
{
    public class StudentBLL
    {
         StudentGeteway astudentGetway = new StudentGeteway();

        public string GetDepartmentCode(int id)
        {
            return astudentGetway.GetDepartmentCode(id);
        }

        public int GetNumberOFstudentInaDepartment(int Id , string year)
        {
            return astudentGetway.GetNumberOFstudentInaDepartment(Id, year);
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

        public List<StudentView> GetStudents()
        {
            return astudentGetway.GetStudents();
        }

        public int SaveStudentEnrollCourse(StudentEnrollCourse student)
        {
            return astudentGetway.SaveStudentEnrollCourse(student);
        }

        public bool  IsCourseEnrolled(int studentId , int courseId)
        {
            return astudentGetway.IsCourseEnrolled(studentId, courseId);
        }

        public List<StudentEnrollCourseView> GetSelectedStudetEnrollCourse(int id)
        {
            return astudentGetway.GetSelectedStudetEnrollCourse(id);
        }

        public string UpdateGrade(StudentEnrollCourse student)
        {
            if (astudentGetway.UpdateGrade(student) > 0)
            {
                return "Save";
            }
            else
            {
                return "Error";
            }
        }
    }

}