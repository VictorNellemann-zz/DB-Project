<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_3rd_Handin_Victor_Website.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome to the unofficial Pokémon Database</h1>
    <div>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce quis lectus quis sem lacinia nonummy. Proin mollis lorem non dolor. In hac habitasse platea dictumst. Nulla ultrices odio. Donec augue. Phasellus dui. Maecenas facilisis nisl vitae nibh.</p>
        <p>Proin vel est vitae eros pretium dignissim. Aliquam aliquam sodales orci. Suspendisse potenti. Nunc adipiscing euismod arcu.</p>
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
