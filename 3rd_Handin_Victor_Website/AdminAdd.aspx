<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="_3rd_Handin_Victor_Website.AdminAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:inline-block; float:left; width:280PX">
        <h1>Add a new pokémon</h1>

        <asp:Label ID="LabelPokeName" runat="server" Text="Pokémon name:" CssClass="FormLabels"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPokeName" runat="server" ErrorMessage="Name missing" CssClass="input_field" ForeColor="#CC0000" EnableClientScript="False" ControlToValidate="TextBoxPokeName"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TextBoxPokeName" runat="server" CssClass="input_field" CausesValidation="True"></asp:TextBox>

        <asp:Label ID="LabelNextEvol" runat="server" Text="Set next evolution:" CssClass="FormLabels"></asp:Label>
        <asp:TextBox ID="TextBoxNextEvol" runat="server" CssClass="input_field"></asp:TextBox>

        <asp:Label ID="LabelPic" runat="server" Text="Add link to picture:" CssClass="FormLabels"></asp:Label>
        <asp:TextBox ID="TextBoxPic" runat="server" CssClass="input_field"></asp:TextBox>

        <asp:Label ID="LabelMessageAdd" runat="server" Text="" ForeColor="#CC0000" Font-Names="Arial"></asp:Label>

        <asp:Button ID="ButtonAddPokemon" runat="server" Text="Add Pokémon" CssClass="button" PostBackUrl="~/AdminAdd.aspx" OnClick="ButtonAddPokemon_Click" />
    </div>
    <div style="display: inline-block; float: right; width: 580px; padding-left:30px; border-left:solid 1px #ccc; min-height:400px">
        <h2>Pokémons currently in database:</h2>
        <asp:GridView ID="GridViewAdd" runat="server" Width="100%">
            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" Width="100%" BackColor="#F0F0F0" Height="40px" Font-Names="Arial" />
            <RowStyle Width="100%" HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Font-Names="Roboto" Font-Size="Small" />
        </asp:GridView>
    </div>
</asp:Content>