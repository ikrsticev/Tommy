<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnosKorisnika.aspx.cs" Inherits="WebApplication4.UnosKorisnika" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <table class="auto-style1">
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Ime</td>
                    <td>
                        <asp:TextBox ID="tbxIme" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Prezime</td>
                    <td>
                        <asp:TextBox ID="tbxPrezime" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>RazinaId</td>
                    <td>
                        <asp:RadioButton ID="rdb1" runat="server" Text="Admin" GroupName="Radio" />
                        <asp:RadioButton ID="rdb2" runat="server" Text="Regionalni menadzer" GroupName="Radio" />
                        <asp:RadioButton ID="rdb3" runat="server" Text="Poslovnica" GroupName="Radio" />
                        <asp:RadioButton ID="rdb4" runat="server" Text="Korisnik" Checked="True" GroupName="Radio" />
                    </td>
                </tr>
                <tr>
                    <td>disabled</td>
                    <td>
                        <asp:CheckBox ID="cbxDisabled" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>enabled</td>
                    <td>
                        <asp:CheckBox ID="cbxEnabled" runat="server" />
                    </td>
                </tr>
            </table>
            
        </div>
        <br />
        <asp:Button ID="btnUnos" runat="server" OnClick="btnUnos_Click" Text="Unesi novog korisnika" />
        <br />
        <br />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Povratak" />
        <br />
        <br />
        <asp:Label ID="lblLabela" runat="server"></asp:Label>
    </form>
</body>
</html>
