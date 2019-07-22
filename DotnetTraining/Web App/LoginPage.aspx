<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SampleWebApp.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <asp:Login runat="server" Height="286px" Width="584px" ID="loginCtrl" OnAuthenticate="loginCtrl_Authenticate" />
</asp:Content>
