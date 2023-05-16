using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        public bool createTemp = false;
        private DataTable table = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!createTemp)

                {
                    DeleteTempTable();
                    CreateTempTable();
                    createTemp = true;
                }
                CompanyLoad();
                saleButton.Visible = false;
                damageButton.Visible = false;
                lostButton.Visible = false;

                if (ViewState["Records"] == null)
                {
                    table.Columns.Add("Item");
                    table.Columns.Add("Company");
                    table.Columns.Add("Quantity");
                    ViewState["Records"] = table;

                }

            }

        }

        public void CreateTempTable()
        {
            stockOutManager.CreateTempTable();
        }

        public void DeleteTempTable()
        {
            stockOutManager.DeleteTempTable();
        }

        private StockOutManager stockOutManager = new StockOutManager();

        public void CompanyLoad()
        {
            companyDropDownList.DataSource = stockOutManager.GetCompanyData();
            companyDropDownList.DataBind();
            itemDropDownList.Enabled = false;

        }

        //Item item5=new Item();
        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = itemDropDownList.SelectedItem.Text;
            Item item1 = stockOutManager.ReorderAndQuantity(itemName);
            reorderTextBox.Text = item1.ReorderLevel.ToString();

            Item item5 = stockOutManager.AvailableQuantity(itemName);
            quantityTextBox.Text = item5.AvailableQuantity.ToString();

        }

        protected void addButton_Click(object sender, EventArgs e)
        {

            Item aItem = new Item();
            aItem.CompanyName = companyDropDownList.SelectedItem.Text;
            aItem.ItemName = itemDropDownList.SelectedItem.Text;
            aItem.StockOutItem = int.Parse(stockInTextBox.Text);
            aItem.ReorderLevel = int.Parse(reorderTextBox.Text);
            aItem.AvailableQuantity = int.Parse(quantityTextBox.Text);
            aItem.DateTime = DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’");
            table = (DataTable) ViewState["Records"];

            if ((aItem.AvailableQuantity - aItem.StockOutItem) < 0)
            {
                messageLabel.Text = "Not enough Quantity";
            }

            else
            {
                String val = aItem.ItemName;
                bool errorFound = false;

                foreach (GridViewRow rows in stockOutGridView.Rows)
                {
                    String cellText = rows.Cells[1].Text;
                    if (val == cellText)
                    {
                        errorFound = true;
                        int updateData = (int.Parse(rows.Cells[3].Text) + aItem.StockOutItem);
                        table = (DataTable) ViewState["Records"];

                        GridViewRow row = stockOutGridView.Rows[rows.RowIndex];
                        table.Rows[row.DataItemIndex]["Item"] = rows.Cells[1].Text;
                        table.Rows[row.DataItemIndex]["Company"] = rows.Cells[1].Text;
                        table.Rows[row.DataItemIndex]["Quantity"] = updateData;
                        stockOutGridView.DataSource = table;
                        stockOutGridView.DataBind();
                        messageLabel.Text = stockOutManager.Save(aItem);
                        ClearTexboxData();
                        saleButton.Visible = true;
                        damageButton.Visible = true;
                        lostButton.Visible = true;
                    }

                }

                if (!errorFound)
                {
                    table = (DataTable) ViewState["Records"];
                    table.Rows.Add(aItem.ItemName, aItem.CompanyName, aItem.StockOutItem);
                    stockOutGridView.DataSource = table;
                    stockOutGridView.DataBind();
                    messageLabel.Text = stockOutManager.Save(aItem);
                    ClearTexboxData();


                    saleButton.Visible = true;
                    damageButton.Visible = true;
                    lostButton.Visible = true;
                }
            }

        }

        private void ClearTexboxData()
        {
            companyDropDownList.SelectedIndex = 0;
            itemDropDownList.SelectedIndex = 0;
            reorderTextBox.Text = String.Empty;
            quantityTextBox.Text = String.Empty;
            stockInTextBox.Text = String.Empty;

            itemDropDownList.Items.Clear();
            ListItem list = new ListItem("--Select an Item", "-1");
            itemDropDownList.Items.Insert(0, list);

        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemDropDownList.Items.Clear();
            ListItem list = new ListItem("--Select an Item", "-1");
            itemDropDownList.Items.Insert(0, list);
            reorderTextBox.Text = String.Empty;
            quantityTextBox.Text = "0";

            if (companyDropDownList.SelectedIndex == 0)
            {
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Items.Clear();
                itemDropDownList.Items.Insert(0, list);
                itemDropDownList.Enabled = false;
            }

            else
            {
                itemDropDownList.Enabled = true;
                object selectValue = companyDropDownList.SelectedValue;
                DataSet dataSet = stockOutManager.GetItemData(selectValue);

                itemDropDownList.DataSource = dataSet;
                itemDropDownList.DataBind();

            }

        }

        protected void saleButton_Click(object sender, EventArgs e)
        {
            Item saleItem = new Item();
            if (stockOutGridView.Rows.Count > 0)
            {
                foreach (GridViewRow rows in stockOutGridView.Rows)
                {
                    saleItem.ItemName = rows.Cells[1].Text;
                    saleItem.CompanyName = rows.Cells[2].Text;
                    saleItem.SaleQuantity = int.Parse(rows.Cells[3].Text);
                    saleItem.DateTime = DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’");
    
                    messageLabel.Text = stockOutManager.SellDataRecord(saleItem);
                    ClearTexboxData();
                    stockOutGridView.DataSource = null;
                    stockOutGridView.DataBind();

                }
                
            }
            
            
        }

    }
}