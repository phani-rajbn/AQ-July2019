<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ValidationPage.aspx.cs" Inherits="SampleWebApp.ValidationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div style="width: 1169px">
        <p
            >Enter the Name: <asp:TextBox ID="txtName" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Name is mandatory" ControlToValidate="txtName" runat="server" ForeColor="Red" /></p>
        <p>Enter the Email: <asp:TextBox ID="txtEmail" runat="server" /><asp:RegularExpressionValidator ErrorMessage="Email invalid format" ControlToValidate="txtEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" />
        <asp:CustomValidator ErrorMessage="Email Already registered" ControlToValidate="txtEmail" runat="server" ForeColor="Red" OnServerValidate="Unnamed3_ServerValidate" />
        </p>
        <p>
            Enter the Password: <asp:TextBox TextMode="Password" ID="txtPwd" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Password is must" ControlToValidate="txtPwd" runat="server" ForeColor="Red" />
        </p>
        <p>
            ReEnter the Password: <asp:TextBox TextMode="Password" ID="txtRetype" runat="server" />
            <asp:CompareValidator ErrorMessage="Password Mismatch" ControlToValidate="txtRetype" ControlToCompare="txtPwd" Type="String" runat="server" ForeColor="Red" />
        </p>
        <p>
            Enter the Age: <asp:TextBox TextMode="Number" ID="txtAge" runat="server" />
            <asp:RangeValidator ErrorMessage="Age should be 20 to 45" ControlToValidate="txtAge" MinimumValue="20" MaximumValue="45" Type="Integer" runat="server" ForeColor="Red" />
        </p>
        <p>
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" PostBackUrl="~/ConformationPage.aspx" Text="Move Next" />
        </p>
        <p>
            <asp:ValidationSummary runat="server" ShowMessageBox="true" style="margin-top: 0px" />
    </div>
</asp:Content>
