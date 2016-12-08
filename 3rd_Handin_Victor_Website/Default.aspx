<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_3rd_Handin_Victor_Website.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome to the unofficial Pokémon Database</h1>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce quis lectus quis sem lacinia nonummy. Proin mollis lorem non dolor. In hac habitasse platea dictumst. Nulla ultrices odio.</p>
    <div style="display:block;overflow: auto;margin-top:30px;border-bottom:1px;border-color:#333;border-bottom-style:solid;">
        <div style="display:inline-flex; background-color:#333;width:25%;height:50px;float:left">
            <p style="color: #fff; margin: 15px; font-size: 17px">Most popular Pokémons</p>
        </div>
    </div>
    <div style="margin-top: 30px">
        <asp:Repeater ID="RepeaterFrontpage" runat="server">
            <ItemTemplate>
                <tr>
                    <img src='/Images/Pokemons/<%# DataBinder.Eval(Container.DataItem, "PictureLink") %>'  
                    alt="" style="width:152px;"/>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <div style="display:block;overflow: auto;margin-top:30px;border-bottom:1px;border-color:#333;border-bottom-style:solid;">
            <div style="display:inline-flex; background-color:#333;width:25%;height:50px;float:left">
                <p style="color: #fff; margin: 15px; font-size: 17px">Top 5 Sponsors</p>
            </div>
        </div>
        <div style="margin-top: 30px">
            <asp:Repeater ID="RepeaterSponsors" runat="server">
                <ItemTemplate>
                    <table>
                        <tbody>
                            <tr>
                                <td style="text-align:center; margin-left:15px; margin-right:15px; font-family:Arial"><%# Eval("Name") %></td>
                            </tr>
                            <tr>
                                <td style="margin-left:15px; margin-right:15px"><a href="<%# Eval("Website") %>">
                                    <img src="Images/SponsorLogos/<%# Eval("Logo") %>.png"; Style="width:170px"/></a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
