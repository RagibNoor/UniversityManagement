using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagement.Models;
using UniversityManagement.ViewModel;

namespace UniversityManagement.Gateway
{
    public class CourseGateway
    {
        private string ConnectinString =
          WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;
        public List<Semister> GetSemister()
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Semister";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Semister> semisters = new List<Semister>();
            while (reader.Read())
            {
                Semister semister = new Semister();
                semister.Name = reader["Name"].ToString();
                semister.Id = Convert.ToInt32(reader["Id"].ToString());

                semisters.Add(semister);

            }
            reader.Close();
            con.Close();
            return semisters;
        }

        public int SaveAssignTeacher(CourseAssign course)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "insert into AssignTeacher(Credit,DepartmentId,CourseId,TeacherId,Status) values(@Credit,@DepartmentId,@CourseId,@TeacherId,'True')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Credit", course.CourseCredit);
            cmd.Parameters.AddWithValue("DepartmentId", course.DepartmentId);
            cmd.Parameters.AddWithValue("CourseId", course.CourseId);
            cmd.Parameters.AddWithValue("TeacherId", course.TeacherID);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        //save Course
        public int Save(Course course)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query;
            if (course.Description == null)
            {
                query = "insert into Course(Name,Code,Credit,DepartmentId,SemisterId) values(@Name,@Code,@Credit,@DepartmentId,@SemisterId)";

            }
            else
            {
                query = "insert into Course(Name,Code,Credit,Description,DepartmentId,SemisterId) values(@Name,@Code,@Credit,@Description,@DepartmentId,@SemisterId)";

            }
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Name", course.Name);
            cmd.Parameters.AddWithValue("Code", course.Code);
            cmd.Parameters.AddWithValue("Credit", course.Credit);
            if (course.Description != null)
            {
                cmd.Parameters.AddWithValue("Description", course.Description);

            }
            cmd.Parameters.AddWithValue("DepartmentId", course.DepartmentId);
            cmd.Parameters.AddWithValue("SemisterId", course.SemisterId);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }


        //public bool IsExsit(string code, string name)
        //{
        //    SqlConnection con = new SqlConnection(ConnectinString);
        //    con.Open();
        //    string query = "select * from  Course where Name = @Name OR Code = @Code";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.Parameters.Clear();
        //    cmd.Parameters.AddWithValue("Name", name);
        //    cmd.Parameters.AddWithValue("Code", code);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        return true;
        //    }
        //    return false;

        //}

        //get Course
        public List<Course> GetCourses()
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Course";
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (reader.Read())
            {
                Course course = new Course();
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.DepartmentId = (int) reader["DepartmentID"];
                course.SemisterId = (int)reader["SemisterId"];
                course.Credit =  (decimal) reader["Credit"];
                course.Id = (int) reader["Id"];

                courses.Add(course);
            }
            reader.Close();
            con.Close();
            return courses;
        } 

        //Get course assign to teacher
        public List<CourseAssignToTeacherView> GetCourseAssignToTeacherViews( int id)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  CourseAssignToTeacher where Status = 'True' And DepartmentId = '"+id+"' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CourseAssignToTeacherView> courses = new List<CourseAssignToTeacherView>();

            while (reader.Read())
            {
                CourseAssignToTeacherView course = new CourseAssignToTeacherView();
                course.Code = reader["CourseCode"].ToString();
                course.Name = reader["CourseName"].ToString();
                course.AssignTo = reader["TeacherName"].ToString();
                if (course.AssignTo=="")
                {
                    course.AssignTo = "Not Assign Yet";
                }
                course.Semister = reader["SemisterName"].ToString(); 

                courses.Add(course);
            }
            reader.Close();
            con.Close();
            return courses;
        }

        public List<CourseAssign> GetAssignCourses()
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  AssignTeacher where Status = 'True'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CourseAssign> courses = new List<CourseAssign>();

            while (reader.Read())
            {
                CourseAssign course = new CourseAssign();

                course.CourseId = (int)reader["CourseId"];

                courses.Add(course);
            }
            reader.Close();
            con.Close();
            return courses;
        } 


       

    }
}