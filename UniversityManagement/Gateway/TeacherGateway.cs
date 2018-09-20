using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagement.Models;

namespace UniversityManagement.Gateway
{
    public class TeacherGateway
    {
        private string ConnectinString =
           WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;

        public List<Designation> GetDesignation()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Designation";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (reader.Read())
            {
                Designation designation = new Designation();
                designation.DesignationName = reader["Designation"].ToString();
                designation.Id = Convert.ToInt32(reader["Id"].ToString());

                designations.Add(designation);

            }
            reader.Close();
            con.Close();
            return designations;
        }

        public int Save(Teacher teacher)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "insert into Teacher(TeacherName,Address,Email,ContactNumber,DesignationId,DepartmentId,CreditToBeTaken) values(@TeacherName,@Address,@Email,@ContactNumber,@DesignationId,@DepartmentId,@CreditToBeTaken)";
           
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("TeacherName", teacher.Name);
            cmd.Parameters.AddWithValue("Address", teacher.Address);
            cmd.Parameters.AddWithValue("Email", teacher.Email);
            cmd.Parameters.AddWithValue("ContactNumber", teacher.ContactNumber);
            cmd.Parameters.AddWithValue("DepartmentId", teacher.DepartmentId);
            cmd.Parameters.AddWithValue("DesignationId", teacher.DesignationId);
            cmd.Parameters.AddWithValue("CreditToBeTaken", teacher.CreditToBeTaken);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public decimal GetRemainingCredit(int id)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select Credit from AssignTeacher where TeacherID= '" + id + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            decimal remainingCredit = 0;
            while (reader.Read())
            {
                remainingCredit += (decimal) reader["Credit"];
            }

            reader.Close();
            con.Close();
            return remainingCredit;

        }

        public List<Teacher> GetTeachers()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Teacher";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Name = reader["TeacherName"].ToString();
                teacher.Email = reader["Email"].ToString();
                teacher.ContactNumber = reader["ContactNumber"].ToString();
                teacher.Address = reader["Address"].ToString();
                teacher.Id = Convert.ToInt32(reader["Id"].ToString());
                teacher.DesignationId = Convert.ToInt32(reader["DesignationId"].ToString());
                teacher.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                teacher.CreditToBeTaken = (decimal) reader["CreditToBeTaken"];
                teacher.Id = (int)reader["Id"];
                teacher.RemainigCredit = teacher.CreditToBeTaken - GetRemainingCredit(teacher.Id);



                teachers.Add(teacher);

            }
            reader.Close();
            con.Close();
            return teachers;
        }


    }

}