<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="AdminUpdate.aspx.cs" Inherits="_3rd_Handin_Victor_Website.AdminUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:inline-block; float:left; width:280PX">
        <h1>Update a Pokémon</h1>
        <div style="margin-bottom:10px">
        </div>
        <asp:Label ID="LabelPokeName" runat="server" Text="Pokémon name:" CssClass="FormLabels"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUpdateName" runat="server" ErrorMessage="Name missing" CssClass="input_field" ForeColor="#CC0000" EnableClientScript="False" ControlToValidate="TextBoxUpdateName" Width="150px" Font-Names="Roboto"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TextBoxUpdateName" runat="server" CssClass="input_field" CausesValidation="True"></asp:TextBox>

        <asp:Label ID="LabelNextEvol" runat="server" Text="Set next evolution:" CssClass="FormLabels"></asp:Label>
        <asp:TextBox ID="TextBoxUpdateEvol" runat="server" CssClass="input_field"></asp:TextBox>

        <asp:Label ID="LabelPic" runat="server" Text="Change link to picture:" CssClass="FormLabels"></asp:Label>
        <asp:TextBox ID="TextBoxUpdatePic" runat="server" CssClass="input_field"></asp:TextBox>
        
        <div style="margin-bottom:20px">       
            <asp:Label ID="LabelMessageUpdate" runat="server" Text="" ForeColor="#CC0000" Font-Names="Arial"></asp:Label>
        </div>
        
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update Pokémon" BackColor="#FFCB06" CssClass="button" OnClick="ButtonUpdate_Click" />

    </div>
    <div style="display: inline-block; float: right; width: 580px; padding-left:30px; border-left:solid 1px #ccc; min-height:400px">
        <h2>Pokémons currently in database:</h2>
        <asp:GridView ID="GridViewUpdate" runat="server" Width="100%" OnSelectedIndexChanged="GridViewUpdate_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField AccessibleHeaderText="Select:" ShowSelectButton="True" />
            </Columns>
            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" Width="100%" BackColor="#F0F0F0" Height="40px" Font-Names="Arial" />
            <RowStyle Width="100%" HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Font-Names="Roboto" Font-Size="Small" />
        </asp:GridView>
    </div>
</asp:Content>
