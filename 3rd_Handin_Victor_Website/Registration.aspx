<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_3rd_Handin_Victor_Website.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <div style="display: inline-block; float: left; width: 40%; margin-right: 30px">
        <h1>Not already a registered Pokehunter?</h1>
        <p>Then sign up today and get all the benefits of the unofficial Pokehunter database.</p>
        <p>Fusce vehicula quam erat, nec dapibus est vehicula sit amet. Sed ornare eros id odio auctor cursus. Integer efficitur luctus mauris sit amet vulputate. </p>
        <p>Sed aliquet ultrices metus, eget luctus neque ullamcorper quis. Cras ex diam, hendrerit at sapien eget, sollicitudin fringilla nunc. </p>
    </div>
    <div style="display: inline-block; float: left; width: 28%; padding-left: 30px; border-left: 1px solid #ccc">
        <h2>Register here:</h2>        
        <asp:Label ID="LabelName" runat="server" Text="Name:" CssClass="FormLabels"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="Name is missing" ForeColor="Red"></asp:RequiredFieldValidator>        
        <asp:TextBox ID="TextBoxName" runat="server" CssClass="input_field" CausesValidation="True"></asp:TextBox>
        
        <asp:Label ID="LabelMail" runat="server" Text="E-mail:" CssClass="FormLabels"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxMail" EnableClientScript="False" ErrorMessage="E-mail is missing" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="TextBoxMail" EnableClientScript="False" ErrorMessage="E-mail must use correct format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TextBoxMail" runat="server" CssClass="input_field" CausesValidation="True"></asp:TextBox>
        
        <asp:Label ID="LabelPassword" runat="server" Text="Password:" CssClass="FormLabels"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Password is missing" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Your password must contain between 4 and 8 characters" ForeColor="Red" ValidationExpression="^\w{4,8}"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="input_field" CausesValidation="True"></asp:TextBox>
        
        <asp:Button ID="ButtonSignUp" runat="server" Text="Sign up now!" CssClass="button" OnClick="ButtonSignUp_Click" PostBackUrl="~/Registration.aspx" />
        
        <div style="margin-top:10px">
            <asp:Label ID="LabelMessage" runat="server" ForeColor="#CC0000" Font-Names="Arial"></asp:Label>
        </div>
    </div>
    <div style="display: inline-block; float: right; width: 20%; margin-top: -30px">
        <img src="/images/AshKetchum_standing2.png" alt="Sign up, mate!" height="420px">
    </div>
</div>
</asp:Content>
