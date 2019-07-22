<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConformationPage.aspx.cs" Inherits="SampleWebApp.ConformationPage" %>
<%@ PreviousPageType VirtualPath="~/ValidationPage.aspx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <style>
        *{
            margin:5px;
            padding:5px;
        }
    </style>
    <h1>These are the details that U have entered!!!!</h1>
    <p>Press Confirm to Save to Database or Back to return to the Previous Page</p>
    <div>
        <h2>The Details:</h2>
        <p>Name: <asp:Label Text="" ID="lblName" runat="server" /></p>
        <p>Email: <asp:Label Text="" ID="lblEmail" runat="server" /></p>
        <p>Age: <asp:Label Text="" ID="lblAge" runat="server" /></p>
    </div>
    <p>
        <asp:Button Text="Go Back <<" runat="server" ID="btnBack" />
        <asp:Button Text="Confirm?" runat="server" ID="btnConfirm" />
    </p>
</asp:Content>
