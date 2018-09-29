<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Poslovnica.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Poslovnica</title>
    <style>
	    .auto-style1 {
            height: 26px;
        }
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
	<script type="text/javascript">

		window.onload = function(){
            
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Poslovnica
        <asp:Label ID="LabelPoslovnica" runat="server"></asp:Label>
        </h1>
        <hr/>
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
            <asp:TextBox ID="txtPoslovnicaUBR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaUBR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaUBR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroUBR" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika koji su radili:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRKR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRKR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRKR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRKR" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na slobodnim danima:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRSD" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRSD" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRSD" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRSD" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na godišnjem odmoru:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRGO" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRGO" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRGO" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRGO" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na kratkotrajnom bolovanju:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRKB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRKB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRKB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRKB" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na dugotrajnom bolovanju:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRDB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBRDB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRDB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRDB" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj studenata:</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBS" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaBS" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBS" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBS" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Utrošeni radni sati (A):</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaSati" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaSati" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaSati" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroSati" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td class="auto-style1">Promet (B):</td>
		<td class="auto-style1">
            <asp:TextBox ID="txtPoslovnicaPromet" runat="server"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtMesnicaPromet" runat="server"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtRibarnicaPromet" runat="server"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtGastroPromet" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Učinkovitost (A/B):</td>
		<td>
            <asp:TextBox ID="txtPoslovnicaUcinkovitost" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtMesnicaUcinkovitost" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaUcinkovitost" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroUcinkovitost" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td></td>
		<td></td>
		<td></td>
		<td></td>
        <td>
            <asp:Button ID="btnUnesi" CssClass="botun" runat="server" OnClick="btnUnesi_Click" Text="Unesi" />
        </td>
	</tr>
	</table><hr />
        <br />
        <asp:Button ID="btnLogout" CssClass="botun" runat="server" Text="Odjava" OnClick="btnLogout_Click" />
        <br />
        <br />
        <asp:Label ID="lblLabela" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
