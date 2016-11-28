<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="_3rd_Handin_Victor_Website.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome back! Login:</h1>
    <div id="login_wrapper" style="margin-top: 20px; width:300px">
        <asp:Label ID="Label_Name" runat="server" Text="Name" Font-Size="Medium" Font-Names="Roboto"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server" CssClass="input_field" ForeColor="#333333" TabIndex="1"></asp:TextBox>
        <asp:Label ID="Label_Password" runat="server" Text="Password" Font-Size="Medium" Font-Names="Roboto"></asp:Label>
        <asp:TextBox ID="TextBoxPassword" runat="server" MaxLength="8" CssClass="input_field" ForeColor="#333333" TabIndex="2" TextMode="Password"></asp:TextBox>
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="button" OnClick="ButtonLogin_Click" />
        <div style="margin-top: 15px"><asp:Label ID="LabelLogin" runat="server" ForeColor="#CC0000" Font-Size="Medium" Font-Names="Roboto"></asp:Label></div>    
    </div>
</asp:Content>
