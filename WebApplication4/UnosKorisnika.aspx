<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnosKorisnika.aspx.cs" Inherits="WebApplication4.UnosKorisnika" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="tema.css"/>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="container">
        <div>
            
            <table class="auto-style1">
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Ime</td>
                    <td>
                        <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Prezime</td>
                    <td>
                        <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Razina</td>
                    <td>
                        <asp:RadioButton ID="rdb1" runat="server" Text="Admin" GroupName="Radio" OnCheckedChanged="rdb1_CheckedChanged" AutoPostBack="true" />
                        <asp:RadioButton ID="rdb2" runat="server" Text="Regionalni menadzer" GroupName="Radio" OnCheckedChanged="rdb2_CheckedChanged" AutoPostBack="true" />
                        <asp:RadioButton ID="rdb3" runat="server" Text="Poslovnica" GroupName="Radio" OnCheckedChanged="rdb3_CheckedChanged" AutoPostBack="true" />
                        <asp:RadioButton ID="rdb4" runat="server" Text="Korisnik" Checked="True" GroupName="Radio" OnCheckedChanged="rdb4_CheckedChanged" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td>disabled</td>
                    <td>
                        <asp:CheckBox ID="cbxDisabled" runat="server" Text="Disabled" />
                    </td>
                </tr>
                <tr>
                    <td>write</td>
                    <td>
                        <asp:CheckBox ID="cbxWrite" runat="server" Checked="True" Text="Write" />
                    </td>
                </tr>
            </table>
            
        </div>
        <div>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Broj_poslovnice" DataValueField="Broj_poslovnice">
        </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT [Broj poslovnice] AS Broj_poslovnice FROM [Poslovnica]"></asp:SqlDataSource>
&nbsp;
        <asp:Button ID="btnDodajPoslovnicu" runat="server" OnClick="btnDodajPoslovnicu_Click" Text="Dodaj poslovnicu" />
            <br />
        <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
        <br />
        </div>
        <div >
        <asp:Label ID="lblOdijeli" runat="server" Text="Odijeli poslovnice:" Visible="False"></asp:Label>
        <br />
        <asp:CheckBox ID="cbxMesnica" runat="server" Text="Mesnica" Visible="False" />
        <asp:CheckBox ID="cbxRibarnica" runat="server" Text="Ribarnica" Visible="False" />
        <asp:CheckBox ID="cbxGastro" runat="server" Text="Gastro" Visible="False" />
        <br />
        <br />
        </div>
        <div>
        <asp:Button ID="btnUnos" runat="server" OnClick="btnUnos_Click" Text="Unesi novog korisnika" />
            <br />
            <br />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Povratak" />
        <br />
        <br />
        <asp:Label ID="lblLabela" runat="server"></asp:Label>
        </div>
            </div>
    </form>
</body>
</html>
