<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.ItemSetupUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item Setup </title>
</head>
<body>
    <form id="itemSetupForm" runat="server">
    <div style="height: 268px; width: 388px">
    
        <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="categoryDropDownList" runat="server"  AppendDataBoundItems="true"  Height="23px" Width="163px" >
        <asp:ListItem Text="--Select a Category" Value="" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="companyDropDownList" runat="server"  AppendDataBoundItems="true"  Height="18px" Width="167px">
        <asp:ListItem Text="--Select a Company" Value="" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="itemTextBox" runat="server" Width="165px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Reorder Level"></asp:Label>
&nbsp;<asp:TextBox ID="reorderTextBox" runat="server" Width="162px" >0</asp:TextBox>
        <br />
        <br />
&nbsp;<asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
    
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
    
    </div>
    </form>

</body>
</html>
