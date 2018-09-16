using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagement.Gateway
{
    public class Getway
    {
        private string ConnectinString =
              WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataReader reader { get; set; }
        public string Query { get; set; }

        public Getway()
        {
            Connection = new SqlConnection(ConnectinString);
        }
    }
}