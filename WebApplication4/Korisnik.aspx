<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Korisnik.aspx.cs" Inherits="WebApplication4.Korisnik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Korisnik</title>
    <style>
        th{
            background-color:#E90000;
        }
        .botun {
            font-family: Courier New;
            color: white;
            background: #E90000;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br /><b>Poslovnica:<asp:Label ID="lblPoslovnica" runat="server"></asp:Label>
            <br />
            <br />
            Datum:</b><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Datum" DataValueField="Datum" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT LEFT([Datum],11) AS datum FROM [Report] WHERE (([PoslovnicaId] = @PoslovnicaId) AND ([OdjelId] = @OdjelId)) ORDER BY [Datum] DESC">
                <SelectParameters>
                    <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
                    <asp:Parameter DefaultValue="4" Name="OdjelId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br /><hr /><br />
            <table>
	<tr>
		<th>Podatci:</th>
		<th>Poslovnica</th>
		<th>Mesnica</th>
		<th>Ribarnica</th>
		<th>Gastro odjel</th>
	</tr>
	<tr>
		<td>Ukupan broj radnika:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaUBR" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaUBR" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaUBR" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroUBR" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika koji su radili:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRKR" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRKR" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRKR" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRKR" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na slobodnim danima:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRSD" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRSD" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRSD" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRSD" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na godišnjem odmoru:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRGO" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRGO" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRGO" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRGO" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na kratkotrajnom bolovanju:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRKB" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRKB" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRKB" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRKB" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na dugotrajnom bolovanju:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRDB" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRDB" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRDB" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRDB" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj studenata:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBS" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBS" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBS" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBS" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Utrošeni radni sati (A):</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaSati" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaSati" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaSati" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroSati" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td class="auto-style1">Promet (B):</td>
		<td class="auto-style1">
            <asp:TextBox ID="txtPoslovnicaPromet" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtMesnicaPromet" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtRibarnicaPromet" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtGastroPromet" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Učinkovitost (A/B):</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaUcinkovitost" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaUcinkovitost" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaUcinkovitost" runat="server" Enabled="False"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroUcinkovitost" runat="server" Enabled="False"></asp:TextBox>
        </td>
	</tr>
	</table><hr />
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="botun" Text="Odjava" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="lblLabela" runat="server"></asp:Label>
            </div>
    </form>
</body>
</html>
