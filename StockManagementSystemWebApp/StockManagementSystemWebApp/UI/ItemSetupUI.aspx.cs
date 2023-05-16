using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class ItemSetupUi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CategoryLoad();
                CompanyLoad();
            }



        }

        ItemSetupManager itemManager = new ItemSetupManager();
        public void CategoryLoad()
        {

            categoryDropDownList.DataSource = itemManager.CategoryLoad();
            categoryDropDownList.DataTextField = "CategoryName";
            categoryDropDownList.DataValueField = "CategoryId";
            categoryDropDownList.DataBind();
           

        }
        public void CompanyLoad()
        {
            companyDropDownList.DataSource=itemManager.CompanyLoad();
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataValueField = "CompanyId";
            companyDropDownList.DataBind();

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Item item1 = new Item();
            item1.ItemName = itemTextBox.Text;
            item1.ReorderLevel = int.Parse(reorderTextBox.Text);
            item1.CategoryName = categoryDropDownList.SelectedItem.Text;
            item1.CompanyName = companyDropDownList.SelectedItem.Text;
            
            messageLabel.Text = itemManager.Save(item1);
            

        }

    }
}
