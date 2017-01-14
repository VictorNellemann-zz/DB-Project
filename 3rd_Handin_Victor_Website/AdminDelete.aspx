<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="AdminDelete.aspx.cs" Inherits="_3rd_Handin_Victor_Website.AdminDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display:inline-block; float:left; width:280PX">
        <h1>Delete Pokémon</h1>        
        <div style="margin-top:20px; margin-bottom:10px">
            <asp:DropDownList ID="DropDownListPokemons" runat="server" CssClass="input_field" AutoPostBack="False" Width="200px" OnSelectedIndexChanged="DropDownListPokemons_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div style="margin-top: 15px; margin-bottom: 15px">
            <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="ButtonDelete" runat="server" CssClass="button" OnClick="ButtonDelete_Click" Text="Delete" />
        </div>
    </div>
    <div style="display: inline-block; float: right; width: 580px; padding-left:30px; border-left:solid 1px #ccc; min-height:400px">
        <h2>Pokémons currently in database:</h2>
        <asp:GridView ID="GridViewDelete" runat="server" Width="100%">
            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" Width="100%" BackColor="#F0F0F0" Height="40px" Font-Names="Arial" />
            <RowStyle Width="100%" HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Font-Names="Roboto" Font-Size="Small" />
        </asp:GridView>
    </div>
</asp:Content>
