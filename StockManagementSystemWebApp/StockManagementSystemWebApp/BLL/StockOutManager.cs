using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class StockOutManager
    {
        StockOutGateway stockOutGateway = new StockOutGateway();
        public dynamic CompanyLoad()
        {
            return stockOutGateway.CompanyLoad();
        }

        public dynamic ItemLoad()
        {
            return stockOutGateway.ItemLoad();
        }

        public Item ReorderAndQuantity(string itemName)
        {
            return stockOutGateway.ReorderAndQuantity(itemName);
        }

        //public Item AvailableQuantity(string itemName)
        //{
        //    return stockOutGateway.AvailableQuantity(itemName);
        //}

        public string Save(Item aItem)
        {
            Item bItem = aItem;
            
                int rowAffected = stockOutGateway.Save(aItem);
                if (rowAffected > 0)
                {
                    return "Item Listed succesfully for stocking out ";
                }
                else
                {
                    return "Not Available Quantity";
                }
        }

        public Item AvailableQuantity(string itemName)
        {
            return stockOutGateway.AvailableQuantity(itemName);
        }

        public DataSet GetCompanyData()
        {
            return stockOutGateway.GetCompanyData();
        }

        public DataSet GetItemData(object selectValue)
        {
            return stockOutGateway.GetItemData(selectValue);
        }

        public string CreateTempTable()
        {
            int rowAffected = stockOutGateway.CreateTempTable();
            if (rowAffected > 0)
            {
                return "";
            }
            else
            {
                return "";
            }
        }

        public string DeleteTempTable()
        {
            int rowAffected = stockOutGateway.DeleteTempTable();
            if (rowAffected > 0)
            {
                return "";
            }
            else
            {
                return "";
            }
        }

        public string SellDataRecord(Item saleItem)
        {
            if (stockOutGateway.IsSellRecordExists(saleItem))
            {
                int rowAffected = stockOutGateway.ExistSellDataRecord(saleItem);
                if (rowAffected > 0)
                {
                    return "Exist Sale record updated successfully";
                }
                else
                {
                    return "Failed!! Sorry Try Again ";
                }
            }
            else
            {
                int rowAffected = stockOutGateway.SellDataRecord(saleItem);
                if (rowAffected > 0)
                {
                    return "Sale record saved successfully";
                }
                else
                {
                    return "Failed!! Sorry Try Again ";
                }
                
            }
            
        }
    }
}