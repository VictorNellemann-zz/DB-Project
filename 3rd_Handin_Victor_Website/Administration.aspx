<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="_3rd_Handin_Victor_Website.Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:inline-block; float:left; width:280px">
        <h1>Administration</h1>
        <div>
            <asp:Button ID="ButtonAdd" runat="server" Text="Add a new pokémon" CssClass="button" PostBackUrl="~/AdminAdd.aspx" Font-Size="Larger" />
        </div>
        <div style="margin-top:20px">
            <asp:Button ID="ButtonUpdate" runat="server" Text="Update a pokémon" CssClass="button" PostBackUrl="~/AdminUpdate.aspx" BackColor="#FFCB06" Font-Size="Larger" />
        </div>
        <div style="margin-top:20px">
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete a pokémon" CssClass="button" PostBackUrl="~/AdminDelete.aspx" BackColor="#F21B23" Font-Size="Larger" />
        </div>
        <div style="margin-top:15px; margin-bottom:15px">
            <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div style="display: inline-block; float: right; width: 580px; padding-left:30px; border-left:solid 1px #ccc; min-height:400px">
        <h2>Pokémons currently in database:</h2>
        <asp:GridView ID="GridViewPokemons" runat="server" Width="100%">
            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" Width="100%" BackColor="#F0F0F0" Height="40px" Font-Names="Arial" />
            <RowStyle Width="100%" HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Font-Names="Roboto" Font-Size="Small" />
        </asp:GridView>
    </div>
</asp:Content>
