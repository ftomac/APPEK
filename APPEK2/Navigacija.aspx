<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Navigacija.aspx.cs" Inherits="APPEK2.Navigacija" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="~/css/navigacija.css" rel="stylesheet"/>
    <title> Odabir laboratorija </title>
</head>

<body> 
    <form id="form1" runat="server">
        <div class="odabir">
            <asp:RadioButtonList ID="rbNavigacija" runat="server">
                <asp:ListItem> Admin </asp:ListItem>
                <asp:ListItem> Lab 1 </asp:ListItem> 
                <asp:ListItem> Lab 2 </asp:ListItem>
            </asp:RadioButtonList>

                <br />
            <asp:Button ID="btnUlazak" runat="server" OnClick="btnUlazak_Click" Text="Odaberi" />
        </div>
    </form>

    <div class="footer">
        Copyright &copy; Bognolo & Tomac <br />
        Programsko inženjerstvo, ak. god. 2021./2022.
    </div>
</body>
</html>
