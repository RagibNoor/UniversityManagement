using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagement.Models;

namespace UniversityManagement.Gateway
{
    public class StudentGeteway
    {
        private string ConnectinString =
            WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;

        public static string date1, number = "001";
           

        public int Save(Student student)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query =
                "insert into Student(Name,Eamil,Address,ContactNumber,DepartmentId,Date,RegisterNo) values(@StudentName,@Email,@Address,@ContactNumber,@DepartmentId, @Date,@RegisterNo)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("StudentName", student.Name);
            cmd.Parameters.AddWithValue("Email", student.Email);
            cmd.Parameters.AddWithValue("Address", student.Address);
            cmd.Parameters.AddWithValue("ContactNumber", student.ContactNumber);
            cmd.Parameters.AddWithValue("DepartmentId", student.DepartmentId);
            cmd.Parameters.AddWithValue("Date", student.Date);
            cmd.Parameters.AddWithValue("RegisterNo", student.Registration);

            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public List<Student> GetEmail()
        {

            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> Students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student();

                student.Email = reader["Eamil"].ToString();
                student.Name = reader["Name"].ToString();



                Students.Add(student);

            }
            reader.Close();
            con.Close();
            return Students;
        }


        public string GetDepartmentCode(int Id)
        {

            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Deparment where Id='" + Id + "'";

            //string date = student.Date;
            //date1 = date.Substring(6, 4);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string departmentCode = null;
            while (reader.Read())
            {

                departmentCode = reader["Code"].ToString();

            }

            con.Close();
            return departmentCode;

        }


        public int GetNumberOFstudentInaDepartment(int Id , string year)
        {

            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "SELECT COUNT(Id) FROM Student where  DepartmentId='" + Id + "' and date between '"+year+"-01-01' and '"+year+"-12-31'";

            //string date = student.Date;
            //date1 = date.Substring(6, 4);
            SqlCommand cmd = new SqlCommand(query, con);
           // SqlDataReader reader = cmd.ExecuteReader();
            object value = cmd.ExecuteScalar();
            int a = 1;
            if (value != null)
            {
                a += (int) value;

            }
         

            con.Close();
            return a;

        }

      
    }

}