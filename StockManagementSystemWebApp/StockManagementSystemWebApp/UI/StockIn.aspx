<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockIn.aspx.cs" Inherits="StockManagementSystemWebApp.UI.StockIn" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <title>Stock IN </title>
</head>
<body>
    <form id="stockInForm" runat="server">
    <div>
        
        <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="companyDropDownList" runat="server" DataTextField="CompanyName" DataValueField="CompanyId"  AppendDataBoundItems="true"  Height="23px" Width="163px" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="True" >
        <asp:ListItem Text="--Select a company" Value="" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="itemDropDownList" runat="server" DataTextField="ItemName" DataValueField="ItemId" AppendDataBoundItems="true" Height="18px" Width="167px" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" >
            <asp:ListItem Text="--Select an Item" Value="" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="reorderTextBox" runat="server" Width="165px" readonly></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label>
&nbsp;<asp:TextBox ID="quantityTextBox" runat="server" Width="162px"  Text="0" readonly ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Stock In Quantity"></asp:Label>
&nbsp;<asp:TextBox ID="stockInTextBox" runat="server" Width="162px"></asp:TextBox>
        <br />
        <br />
&nbsp;
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
    
        <br />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>

    
    </div>
    </form>
</body>
</html>
