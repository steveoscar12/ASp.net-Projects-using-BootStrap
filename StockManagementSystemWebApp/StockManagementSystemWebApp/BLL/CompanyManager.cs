using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.BLL
{
    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();

        public string Save(Company aCompany)
        {
            int rowAffected = aCompanyGateway.Save(aCompany);
            if (rowAffected > 0)
            {
                return "Saved successfully";
            }
            else
            {
                return "Failed to save";
            }

        }

        public List<Company> GetAllCompany()
        {

            return aCompanyGateway.GetAllCompany();
        }
    }
}