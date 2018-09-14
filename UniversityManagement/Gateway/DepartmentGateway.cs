using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagement.Models;

namespace UniversityManagement.Gateway
{
    public class DepartmentGateway
    {
        private string ConnectinString =
           WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;

        public int Save(Department department)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();

            string query = "insert into Deparment(Name,Code) values(@Name,@code)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Name", department.Name);
            cmd.Parameters.AddWithValue("Code", department.Code);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public bool IsExsit(string code , string name)
        {
            // SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Deparment where Name = @Name OR Code = @Code";
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

        public List<Department> GetDepartments()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Deparment";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department();
                department.Name = reader["Name"].ToString();
                department.Code = reader["Code"].ToString();
                department.Id = Convert.ToInt32(reader["Id"].ToString());

                departments.Add(department);

            }
            reader.Close();
            con.Close();
            return departments;
        }
    }
}