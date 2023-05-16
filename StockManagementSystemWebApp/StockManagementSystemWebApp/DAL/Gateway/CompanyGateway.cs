using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class CompanyGateway:Gateway
    {
        public int Save(Company aCompany)
        {
            Query = "INSERT INTO Company VALUES('"+aCompany.CompanyName+"')";
            Command = new SqlCommand(Query, Connection);
            //Command.Parameters.Clear();

            //Command.Parameters.Add("CompanyName", SqlDbType.VarChar);
            //Command.Parameters["CompanyName"].Value = aCompany.CompanyName;
          


            //command.CommandText = query;
            //command.Connection = connection;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();


            Connection.Close();

            return rowAffected;
        }


        public List<Company> GetAllCompany()
        {

            Query = "SELECT CompanyName FROM Company";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            List<Company> cities = new List<Company>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Company aCompany = new Company();

                aCompany.CompanyName = Reader["CompanyName"].ToString();
                cities.Add(aCompany);
            }
            Reader.Close();
            Connection.Close();
            return cities;
        }

        
    }
}