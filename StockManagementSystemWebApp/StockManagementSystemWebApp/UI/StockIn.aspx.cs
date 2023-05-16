using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;
using StockManagementSystemWebApp.UI;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockIn : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CompanyLoad();
                

            }
            
        }

        StockInManager stockInManager =new StockInManager();
        public void CompanyLoad()
        {
            companyDropDownList.DataSource = stockInManager.GetCompanyData();
            companyDropDownList.DataBind();
            itemDropDownList.Enabled = false;

        }

        //public DataSet ItemLoad()
        //{
        //    return stockInManager.GetItemData(itemDropDownList.SelectedValue);
        //}

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = itemDropDownList.SelectedItem.Text;
            Item item1 = stockInManager.ReorderAndQuantity(itemName);
            reorderTextBox.Text = item1.ReorderLevel.ToString();

            Item item5 = stockInManager.AvailableQuantity(itemName);
            quantityTextBox.Text = item5.AvailableQuantity.ToString();

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Item aItem = new Item();
            aItem.CompanyName = companyDropDownList.SelectedItem.Text;
            aItem.ItemName = itemDropDownList.SelectedItem.Text;
            aItem.StockInItem = int.Parse(stockInTextBox.Text);
            aItem.ReorderLevel = int.Parse(reorderTextBox.Text);
            aItem.AvailableQuantity = int.Parse(quantityTextBox.Text);
            aItem.StockInItem = int.Parse(stockInTextBox.Text);
            aItem.DateTime = DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’");

            messageLabel.Text = stockInManager.Save(aItem);
            companyDropDownList.SelectedIndex = 0;
            itemDropDownList.SelectedIndex = 0;
            reorderTextBox.Text=String.Empty;
            quantityTextBox.Text=String.Empty;
            stockInTextBox.Text=String.Empty;

            itemDropDownList.Items.Clear();
            ListItem list = new ListItem("--Select an Item", "-1");
            itemDropDownList.Items.Insert(0, list);
            


        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemDropDownList.Items.Clear();
            ListItem list = new ListItem("--Select an Item", "-1");
            itemDropDownList.Items.Insert(0, list);
            reorderTextBox.Text=String.Empty;
            quantityTextBox.Text = "0";

            if (companyDropDownList.SelectedIndex == 0)
            {
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Items.Clear();
                itemDropDownList.Items.Insert(0,list);
                itemDropDownList.Enabled = false;
            }

            else
            {
                itemDropDownList.Enabled = true;
                object selectValue= companyDropDownList.SelectedValue;
                DataSet dataSet = stockInManager.GetItemData(selectValue);

                itemDropDownList.DataSource = dataSet;
                itemDropDownList.DataBind();

            }
        }

    }
}