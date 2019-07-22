<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FinalCart.aspx.cs" Inherits="SampleWebApp.FinalCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <div style="display:inline-block; width:80%">
                <h1>List  of Items: </h1>
    <asp:repeater runat="server" ID="rpCart">
    <HeaderTemplate>
        <table border="1">
            <tr>
                <th>ProductID</th>
                <th>ProductName</th>
                <th>ProductCost</th>
                <th>Quantity</th>
                <th>Total</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Eval("ProductID")%> </td>
            <td><%# Eval("ProductName")%> </td>
            <td><%# Eval("ProductCost")%> </td>
            <td><%# Eval("Quantity")%> </td>
            <td><%# int.Parse(Eval("Quantity").ToString()) * double.Parse(Eval("ProductCost").ToString()) %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:repeater>
        </div>
        <div style="display:inline-block; width:20%">
            <p style="font-size:40pt">Total  Amount:</p>
            <asp:Label Text="" ID="lblFinalPrice" runat="server" />
        </div>
    </div>
   <asp:Button Text="Make Payment" ID="btnPayment" runat="server" OnClick="btnPayment_Click" />
</asp:Content>
