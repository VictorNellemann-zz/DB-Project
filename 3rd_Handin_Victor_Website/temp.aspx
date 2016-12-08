<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="_3rd_Handin_Victor_Website.temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 150px">
            <asp:Repeater ID="RepeaterSponsors" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><%# Eval("Name") %></td>
                        </tr>
                        <tr>
                            <td><a href="<%# Eval("Website") %>">
                                <img src="Images/SponsorLogos/<%# Eval("Logo") %>.png" /></a>
                            </td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
