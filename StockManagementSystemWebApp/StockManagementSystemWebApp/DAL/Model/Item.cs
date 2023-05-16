using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int AvailableQuantity { get; set; }
        public int StockInItem { get; set; }
        public int StockOutItem { get; set; }
        public int SaleQuantity { get; set; }
        public string DateTime { get; set; }
    }
}