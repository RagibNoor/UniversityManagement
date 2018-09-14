using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagement.Models;

namespace UniversityManagement.Gateway
{
    public class CourseGateway
    {
        private string ConnectinString =
          WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;
        public List<Semister> GetSemister()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
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

        public int Save(Course course)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query;
            if (course.Description==null)
            {
                 query = "insert into Course(Name,Code,Credit,DepartmentId,SemisterId) values(@Name,@code,@Credit,@DepartmentId,@SemisterId)";
                
            }
            else
            {
                 query = "insert into Course(Name,Code,Credit,Description,DepartmentId,SemisterId) values(@Name,@code,@Credit,@Description,@DepartmentId,@SemisterId)";
                
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

        public bool IsExsit(string code, string name)
        {
            // SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Course where Name = @Name OR Code = @Code";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Name", name);
            cmd.Parameters.AddWithValue("Code", code);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;

        }
    }
}