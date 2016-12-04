<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_3rd_Handin_Victor_Website.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome to the unofficial Pokémon Database</h1>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce quis lectus quis sem lacinia nonummy. Proin mollis lorem non dolor. In hac habitasse platea dictumst. Nulla ultrices odio.</p>
    <div style="display:block;overflow: auto;margin-top:30px;border-bottom:1px;border-color:#333;border-bottom-style:solid;">
        <div style="display:inline-flex; background-color:#333;width:30%;height:50px;float:left">
            <p style="color: #fff; margin: 15px; font-size: 17px">Most popular Pokémons</p>
        </div>
        <div style="display:inline-flex;width:70%;height:50px;float:right;">
        </div>
    </div>
    <div style="margin-top: 30px">
        <asp:Repeater ID="RepeaterFrontpage" runat="server">
            <ItemTemplate>
                <tr>
                    <img src='/Images/Pokemons/<%# DataBinder.Eval(Container.DataItem, "PictureLink") %>'  
                    alt="" style="width:180px;"/>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
