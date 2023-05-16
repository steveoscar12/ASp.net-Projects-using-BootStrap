using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class StockOutGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public dynamic CompanyLoad()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT CompanyId,CompanyName from Company";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var reader = command.ExecuteReader();
            return reader;
            connection.Close();
        }

        public dynamic ItemLoad()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT ItemId,ItemName from Items";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            var reader = command.ExecuteReader();
            return reader;
            connection.Close();

        }

        public Item ReorderAndQuantity(string itemName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT  ReorderLevel FROM Items WHERE ItemName = '" + itemName + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Item item1 = null;
            if (reader.HasRows)
            {
                item1 = new Item();
                reader.Read();
                item1.ReorderLevel = int.Parse(reader["ReorderLevel"].ToString());
                //item1.AvailableQuantityOfItem = int.Parse(reader["Contact"].ToString());
            }


            reader.Close();
            connection.Close();

            return item1;

        }
        Item item2 = new Item();

        public int Save(Item aItem)
        {
            int rowAffected =0;
            item2.ItemName = aItem.ItemName;
            item2.AvailableQuantity = aItem.AvailableQuantity - aItem.StockOutItem;
            item2.StockOutItem = aItem.StockOutItem;
            item2.DateTime = aItem.DateTime;
            
                SqlConnection connection = new SqlConnection(connectionString);

                //string myQuery = "INSERT INTO StockInItem VALUES('SELECT ItemId from Items where IemName=" + item2.ItemName + "',SELECT CompanyId from Items where IemName=" + item2.ItemName + "','" + item2.AvailableQuantity + "','" + item2.StockInItem + "','" + item2.DateTime + "')";
                string query = "Update Tempstock SET AvailableQuantity='" + item2.AvailableQuantity + "' WHERE ItemId =(select Items.ItemId from Items where Items.ItemName='" + item2.ItemName + "')";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                rowAffected = command.ExecuteNonQuery();

                connection.Close();

                return rowAffected;
   
        }

        public Item AvailableQuantity(string itemName)
        {
            //CreateTempTable();
            SqlConnection connection = new SqlConnection(connectionString);

            string querySum = "SELECT AvailableQuantity FROM Tempstock WHERE ItemId =(select Items.ItemId from Items where Items.ItemName='" + itemName + "')";


            SqlCommand commandSum = new SqlCommand(querySum, connection);
            connection.Open();
            SqlDataReader reader = commandSum.ExecuteReader();

            Item item5 = new Item();
            if (reader.HasRows)
            {

                reader.Read();
                item5.AvailableQuantity = int.Parse(reader["AvailableQuantity"].ToString());
                reader.Close();
                connection.Close();

                return item5;

            }
            else
            {
                item5.AvailableQuantity = 0;
                reader.Close();
                connection.Close();
                return item5;
            }


        }

        
        public DataSet GetData(string SPName, SqlParameter SpParameter)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(SPName, connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SpParameter != null)
            {
                dataAdapter.SelectCommand.Parameters.Add(SpParameter);
            }

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public DataSet GetCompanyData()
        {
            return GetData("getCompany", null);
        }

        public DataSet GetItemData(object selectValue)
        {
            SqlParameter parameter = new SqlParameter("@companyId", selectValue);
            return GetData("getItemByCompanyId", parameter);
        }

        public int CreateTempTable()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Tempstock SELECT * FROM StockInItem";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;



        }

        public int DeleteTempTable()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Delete from Tempstock";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;

        }

        internal bool IsSellRecordExists(Item aItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM StockInItem WHERE ItemId = (select Items.ItemId from Items where Items.ItemName='" + aItem.ItemName + "')";

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

        public int SellDataRecord(Item saleItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "insert into SaleRecord values((select Items.ItemId from Items where Items.ItemName='" + saleItem.ItemName + "'),'" + saleItem.SaleQuantity + "','" + saleItem.DateTime + "');Update StockInItem SET AvailableQuantity=(AvailableQuantity-'" + saleItem.SaleQuantity + "') WHERE ItemId = (select Items.ItemId from Items where Items.ItemName='" + saleItem.ItemName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;

        }

        internal int ExistSellDataRecord(Item saleItem)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE SaleRecord SET Quantity = (Quantity+'" + saleItem.SaleQuantity + "') WHERE ItemId = (select Items.ItemId from Items where Items.ItemName='" + saleItem.ItemName + "');Update StockInItem SET AvailableQuantity=(AvailableQuantity-'" + saleItem.SaleQuantity + "') WHERE ItemId = (select Items.ItemId from Items where Items.ItemName='" + saleItem.ItemName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();


            connection.Close();

            return rowAffected;

        }
    }
}