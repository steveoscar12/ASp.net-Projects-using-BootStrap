using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class StockInManager
    {
        StockInGateway stockInGateway =new StockInGateway();
        public dynamic CompanyLoad()
        {
            return stockInGateway.CompanyLoad();
        }

        public dynamic ItemLoad()
        {
            return stockInGateway.ItemLoad();
        }

        public Item ReorderAndQuantity(string itemName)
        {
            return stockInGateway.ReorderAndQuantity(itemName);
        }

        //public Item AvailableQuantity(string itemName)
        //{
        //    return stockInGateway.AvailableQuantity(itemName);
        //}

        public string Save(Item aItem)
        {
            Item bItem = aItem;
            if (stockInGateway.IsItemExists(aItem))
            {
                int rowAffected = stockInGateway.SaveExistItem(bItem);
                if (rowAffected > 0)
                {
                    return "Item exist  Saved successfully";
                }
                else
                {
                    return "Item exist Failed to save";
                }
            }
            else
            {
                int rowAffected = stockInGateway.Save(aItem);
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

        public Item AvailableQuantity(string itemName)
        {
            return stockInGateway.AvailableQuantity(itemName);
        }

        public DataSet GetCompanyData()
        {
            return stockInGateway.GetCompanyData();
        }

        public DataSet GetItemData(object selectValue)
        {
            return stockInGateway.GetItemData(selectValue);
        }
 }
}