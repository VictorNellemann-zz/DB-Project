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
            <div>
                <asp:Repeater ID="RepeaterSponsors" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td><%# Eval("Name") %></td>
                            </tr>
                            <tr>
                                <td><a href="<%# Eval("Website") %>"><img src="Images/SponsorLogos/<%# Eval("Logo") %>"/></a></td>
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
