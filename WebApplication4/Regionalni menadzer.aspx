﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regionalni menadzer.aspx.cs" Inherits="WebApplication4.Regionalni_menadzer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="tema.css"/>
    <title>Regionalni menadžer</title>
    <style>
        th{
            background-color: #E90000;
        }
        body{
             background-color: white;
             color: black;
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
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Broj poslovnice" DataValueField="Broj poslovnice" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Enabled="False">Odaberite poslovnicu</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT P.[Broj poslovnice] FROM Poslovnica AS P LEFT OUTER JOIN Poslovnica_Users AS PU ON P.PoslovnicaId = PU.PoslovnicaId WHERE (PU.UserId = @UserId)">
            <SelectParameters>
                <asp:SessionParameter Name="UserId" SessionField="ID" />
            </SelectParameters>
        </asp:SqlDataSource>
        </h1>
        <hr>
	<table>
	<tr>
		<th>Podatci:</th>
		<th>Mesnica</th>
		<th>Ribarnica</th>
		<th>Gastro odijel</th>
		<th>Poslovnica</th>
	</tr>
	<tr>
		<td>Ukupan broj radnika:</td>
		<td>
            <asp:TextBox ID="txtMesnicaUBR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaUBR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroUBR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaUBR" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika koji su radili:</td>
		<td>
            <asp:TextBox ID="txtMesnicaBRKR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRKR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRKR" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRKR" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na slobodnim danima:</td>
		<td>
            <asp:TextBox ID="txtMesnicaBRSD" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRSD" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRSD" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRSD" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na godišnjem odmoru:</td>
		<td>
            <asp:TextBox ID="txtMesnicaBRGO" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRGO" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRGO" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRGO" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na kratkotrajnom bolovanju:</td>
		<td>
            <asp:TextBox ID="txtMesnicaBRKB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRKB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRKB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRKB" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj radnika na dugotrajnom bolovanju:</td>
		<td>
            <asp:TextBox ID="txtMesnicaBRDB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBRDB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBRDB" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBRDB" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Broj studenata:</td>
		<td>
            <asp:TextBox ID="txtMesnicaBS" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaBS" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroBS" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaBS" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Utrošeni radni sati (A):</td>
		<td>
            <asp:TextBox ID="txtMesnicaSati" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaSati" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroSati" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaSati" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td class="auto-style1">Promet (B):</td>
		<td class="auto-style1">
            <asp:TextBox ID="txtMesnicaPromet" runat="server"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtRibarnicaPromet" runat="server"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtGastroPromet" runat="server"></asp:TextBox>
        </td>
		<td class="auto-style1">
            <asp:TextBox ID="txtPoslovnicaPromet" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td>Učinkovitost (A/B):</td>
		<td>
            <asp:TextBox ID="txtMesnicaUcinkovitost" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtRibarnicaUcinkovitost" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtGastroUcinkovitost" runat="server"></asp:TextBox>
        </td>
		<td>
            <asp:TextBox ID="txtPoslovnicaUcinkovitost" runat="server"></asp:TextBox>
        </td>
	</tr>
	<tr>
		<td></td>
		<td></td>
		<td></td>
		<td></td>
        <td>
            <asp:Button ID="btnUnesi" CssClass="botun" runat="server" Text="Unesi" OnClick="btnUnesi_Click" />
        </td>
	</tr>
	</table><hr/>
        <asp:Label ID="lblLabela" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
