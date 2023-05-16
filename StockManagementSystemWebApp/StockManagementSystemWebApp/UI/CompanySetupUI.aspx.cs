using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystemWebApp.UI
{
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManger = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();

        }

        private void PopulateGridView()
        {
            List<Company> aCompany = aCompanyManger.GetAllCompany();
            companyInformationGridView.DataSource = aCompany;
            companyInformationGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company aCompany = new Company();
            aCompany.CompanyName = nameTextBox.Text; ;
       
            messageLabel.Text = aCompanyManger.Save(aCompany);
            nameTextBox.Text = "";
            
            PopulateGridView();
        }
    }
}