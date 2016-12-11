<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="AdminSponsor.aspx.cs" Inherits="_3rd_Handin_Victor_Website.AdminSponsor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:inline-block; float:left; width:280px">
        <h1>Sponsor page</h1>
        <div>
            <asp:DropDownList ID="DropDownListSponsor" runat="server" CssClass="input_field"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="LabelMessage" runat="server" Text="" ForeColor="#CC0000" Font-Names="Arial"></asp:Label>
        </div>
        <div style="padding-top:10px">
            <asp:Label ID="LabelId" runat="server" Text="Sponsor Id (Read only):" CssClass="FormLabels"></asp:Label>
            <asp:TextBox ID="TextBoxId" runat="server" ReadOnly="True" CssClass="input_field" BackColor="#efefef" BorderWidth="1px" BorderColor="#a7a5a5" BorderStyle="Solid" ForeColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelName" runat="server" Text="Sponsor name:" CssClass="FormLabels"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server" CssClass="input_field"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelWebsite" runat="server" Text="Website URL:" CssClass="FormLabels"></asp:Label>
            <asp:TextBox ID="TextBoxWebsite" runat="server" CssClass="input_field"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelLogo" runat="server" Text="Logo reference:" CssClass="FormLabels"></asp:Label>
            <asp:TextBox ID="TextBoxLogo" runat="server" CssClass="input_field"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonCreate" runat="server" Text="Add new sponsor" CssClass="button" Font-Size="Larger" OnClick="ButtonCreate_Click" />
        </div>
        <div style="margin-top:20px">
            <asp:Button ID="ButtonUpdate" runat="server" Text="Update sponsor" CssClass="button" BackColor="#FFCB06" Font-Size="Larger" OnClick="ButtonUpdate_Click" />
        </div>
        <div style="margin-top:20px">
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete sponsor" CssClass="button" BackColor="#F21B23" Font-Size="Larger" OnClick="ButtonDelete_Click" />
        </div>
        <div style="margin-top:20px">
            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="button" BackColor="666666" Font-Size="Larger"  OnClick="ButtonCancel_Click" />
        </div>
    </div>
    <div style="display: inline-block; float: right; width: 590px; padding-left:30px; border-left:solid 1px #ccc; min-height:400px">
        <asp:Repeater ID="RepeaterSponsor" runat="server">            
            <HeaderTemplate>
                <table border="solid" style="width:590px">
                <tr>
                    <td class="table-header">ID</td>
                    <td class="table-header">Name</td>
                    <td class="table-header">Website</td>
                    <td class="table-header">Logo</td>
                    <td class="table-header">Logo preview</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="padding-right:15px">
                    <td class="td-style"><%# Eval("SponsorId") %></td>
                    <td class="td-style"><%# Eval("Name") %></td>
                    <td class="td-style"><%# Eval("Website") %></td>
                    <td class="td-style"><%# Eval("Logo") %></td>
                    <td class="td-style"><img src="Images\SponsorLogos\<%# Eval("Logo") %>.png" alt="Logo" style="width:130px"/></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
