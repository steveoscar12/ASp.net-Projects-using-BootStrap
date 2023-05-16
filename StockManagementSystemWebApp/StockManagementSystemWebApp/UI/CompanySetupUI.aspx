<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.CompanySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company Setup</title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
        .auto-style2 {
            margin-left: 49px;
        }
    </style>
</head>
<body>
    <form id="companyInForm" runat="server">
         
        <div style="height: 276px; width: 401px">
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="nameTextBox" runat="server" CssClass="auto-style1"></asp:TextBox>
            <br />
           <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="auto-style2" Width="76px" OnClick="saveButton_Click" />
             <tr>
            <td></td>
            <td>
            <br />
            <br />
            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
            <br />
            </td>
        </tr>
            <asp:GridView ID="companyInformationGridView" runat="server" AutoGenerateColumns ="False" Width="383px">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate><%#Eval("CompanyName")%> </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             
        </div>
    </form>
</body>
</html>
