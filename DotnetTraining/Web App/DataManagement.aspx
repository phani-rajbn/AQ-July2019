<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DataManagement.aspx.cs" Inherits="SampleWebApp.DataManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <table>
            <td>
                <h3>List of Products</h3>
                <asp:listbox runat="server" ID="lstProducts" Height="550px" Width="250px" OnSelectedIndexChanged="lstProducts_SelectedIndexChanged" AutoPostBack="True"/>    
            </td>
            <td>
                <h2>Details of the Selected Product</h2>
                <p>ProductID: <asp:label text="" runat="server" ID="lblProductID"/></p>
                <p>ProductName: <asp:label text="" runat="server" ID="lblName"/></p>
                <p style="color:gold;font-weight:bolder">ProductPrice: <asp:label text="" runat="server" ID="lblPrice"/></p>
                <p>
                    Quantity:
                    <asp:dropdownlist runat="server" ID="dpCount">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>                        
                    </asp:dropdownlist>
                </p>
                <asp:button text="Add To Cart" runat="server" ID="btnAdd" />
            </td>
        </table>
    </div>
</asp:Content>
