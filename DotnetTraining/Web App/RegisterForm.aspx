<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="SampleWebApp.RegisterForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h2>Register for the Application</h2>
    <p>
        Enter the Name: <asp:TextBox runat="server" ID="txtName"/>
    </p>
    <p>
        Enter the Email Address: <asp:TextBox runat="server" ID="txtEmail"/>
    </p>
    <p>
        Enter the Password:
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        ReType the Password:
        <asp:TextBox ID="txtRetype" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        Enter the Qualification: <asp:TextBox runat="server" ID="txtDetails"/>
    </p>
    <p>
        Enter the Phone no: <asp:TextBox runat="server" ID="txtPhone"/>
    </p>
    <p>
        <asp:Button Text="Register" runat="server" ID="btnRegister" OnClick="btnRegister_Click"/>
    </p>
    <div>
        <asp:Label Text="" runat="server" ID="lblDisplay" BorderStyle="Dotted" BorderColor="IndianRed" />
    </div>
</asp:Content>
