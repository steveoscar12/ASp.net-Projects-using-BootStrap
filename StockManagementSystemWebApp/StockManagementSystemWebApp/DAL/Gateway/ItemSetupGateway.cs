using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.UI;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ItemSetupGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public int Save(Item item1)
        {
            string cayegoryName = item1.CategoryName;
            string companyName = item1.CompanyName;
            SqlConnection connection = new SqlConnection(connectionString);

            //string myQuery = "INSERT INTO Items VALUES('" + item1.ItemName + "','Select Cast(CategoryId As INT) from CategoryDetails where CategoryName='" + item1.CategoryName + "'','Select Cast(CompanyId as INT) from Company where CompanyName='" + item1.CompanyName + "'','" + item1.ReorderLevel + "')";

            string query = "INSERT INTO Items (ItemName,ReorderLevel,CategoryId,CompanyId) Select '" + item1.ItemName + "','" + item1.ReorderLevel + "',(select CategoryDetails.CategoryId from CategoryDetails where CategoryDetails.CategoryName='" + item1.CategoryName + "'),(select Company.CompanyId from Company where Company.CompanyName='" + item1.CompanyName + "');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();


            connection.Close();

            return rowAffected;
        }

        public bool IsItemExists(Item item1)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT ItemName FROM Items WHERE ItemName = '" +item1.ItemName+ "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool hasRow = false;

            if (reader.HasRows)
            {
                hasRow = true;
            }

            reader.Close();
            connection.Close();

            return hasRow;
        }

        public dynamic CompanyLoad()
        {
            string connectionString = @"Server=tcp:JahangirJumon,49172; Database=StockManagementSystemDB; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT CompanyId,CompanyName from Company";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var reader = command.ExecuteReader();
            return reader;
            connection.Close();

        }

        internal dynamic CategoryLoad()
        {
            string connectionString = @"Server=tcp:JahangirJumon,49172; Database=StockManagementSystemDB; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT CategoryId,CategoryName from CategoryDetails";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var reader = command.ExecuteReader();
            return reader;
            connection.Close();
        }
    }
}