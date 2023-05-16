using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.UI;

namespace StockManagementSystemWebApp.BLL
{
    public class ItemSetupManager
    {
        ItemSetupGateway itemSetupGateway = new ItemSetupGateway();
        public string Save(Item item1)
        {
            if (itemSetupGateway.IsItemExists(item1))
            {
                return "Item Name already exists";
            }
            else
            {
                int rowAffected = itemSetupGateway.Save(item1);
                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                else
                {
                    return "Failed to save";
                }
            }
        }

        public dynamic CompanyLoad()
        {
            return itemSetupGateway.CompanyLoad();
        }
        public dynamic CategoryLoad()
        {
            return itemSetupGateway.CategoryLoad();
        }
    }
}