<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SessionManagement.aspx.cs" Inherits="SampleWebApp.SessionManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h1>Session State management</h1>
    <div>
        <p>
            Enter the Word:
            <asp:TextBox runat="server" ID="txtWord"/>
        </p>
        <p>
            Enter the Meaning:
            <asp:TextBox runat="server" ID="txtMeaning"/>
        </p>
        <p><asp:Button Text="Save Word" runat="server" ID="btnSave" OnClick="btnSave_Click" />
            <asp:Button Text="Show My Words" runat="server" ID="btnShow" OnClick="btnShow_Click" />
        
            </p>
    </div>
    <asp:GridView runat="server" ID="grdWords">

    </asp:GridView>
</asp:Content>
