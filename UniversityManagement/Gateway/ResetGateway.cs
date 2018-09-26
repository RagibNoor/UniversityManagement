using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagement.Models;

namespace UniversityManagement.Gateway
{
    public class ResetGateway
    {
        private string ConnectinString =
          WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;
        public int UnAssignCourses()
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query =
                "Update AssignTeacher set Status = 'False' where Status ='True'";

            SqlCommand cmd = new SqlCommand(query, con);
          

            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public int UnallocateClassroom()
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query =
                "Update ClassAllocation set Status = 'False' where Status ='True'";

            SqlCommand cmd = new SqlCommand(query, con);


            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }
    }
}