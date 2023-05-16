using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class Gateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}