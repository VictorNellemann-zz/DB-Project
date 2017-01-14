<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="MyPageAdd.aspx.cs" Inherits="_3rd_Handin_Victor_Website.MyPageAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:inline-block; float:left; width:280PX">
        <h1>Catch a Pokémon</h1>
        <div style="margin-top:20px; margin-bottom:10px">
            <asp:DropDownList ID="DropDownListPokemons" runat="server" CssClass="input_field" AutoPostBack="False" Width="200px" OnSelectedIndexChanged="DropDownListPokemons_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div style="margin-top: 15px; margin-bottom: 15px">
            <asp:Label ID="LabelMessage" runat="server" Text="" Font-Names="roboto"></asp:Label>
        </div>
        <div style="margin-top: 15px; margin-bottom: 15px">
            <asp:Label ID="LabelNeg" runat="server" Text="" Font-Names="roboto" ForeColor="Red"></asp:Label>
            <asp:Label ID="LabelPos" runat="server" Text="" Font-Names="roboto" ForeColor="Green"></asp:Label>
        </div>
        <div>
            <asp:Button ID="ButtonAdd" runat="server" CssClass="button" Text="Attempt catch" OnClick="ButtonAdd_Click" Height="41px" PostBackUrl="~/MyPageAdd.aspx" />
        </div>
    </div>
    <div style="display: inline-block; float: right; width: 580px; padding-left:30px; border-left:solid 1px #ccc; min-height:400px">
        <div style="display: inline-block; float: left; width: 70%">
            <h2>Your Pokémon catches:</h2>
        </div>
        <div style="display: inline-block; float: right; width: 30%">
            <asp:Label ID="LabelPokehunter" runat="server" Text="" Style="font-family:'Roboto', 'Times New Roman', serif;"></asp:Label>
        </div>
        <asp:GridView ID="GridViewCatch" runat="server" Width="100%">
            <HeaderStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" Width="100%" BackColor="#F0F0F0" Height="40px" Font-Names="Arial" />
            <RowStyle Width="100%" HorizontalAlign="Left" VerticalAlign="Middle" Height="30px" Font-Names="Roboto" Font-Size="Small" />
        </asp:GridView>
    </div>
</asp:Content>
