<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication4.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        td{ width:64px; }
        td.prvi { width: auto;}
        table {
            table-layout:fixed;
        }
        input{
            width:64px;
        }
	</style>
	<script type="text/javascript">

        window.onload = function () {

		}
        
        function CheckPoslovnica(){
			if(document.getElementById("CBposlovnica").checked){
				var x = document.getElementsByClassName("poslovnica");
				var i;
				for(i = 0; i < x.length; i++){
					x[i].style.pointerEvents = "auto";
					x[i].style.color = "#000000";
					x[i].style.background = "#FFFFFF";
				}
			}
			else{
				var x = document.getElementsByClassName("poslovnica");
				var i;
				for(i = 0; i < x.length; i++){
					x[i].style.pointerEvents = "none";
					x[i].style.color = "#AAA";
					x[i].style.background = "#F5F5F5";
				}
			}
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <span id="spsp"></span>
    
    <div style="float: left;">
        <h1>Poslovnica</h1>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Broj_poslovnice" DataValueField="Broj_poslovnice">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT [Broj poslovnice] AS Broj_poslovnice FROM [Poslovnica]"></asp:SqlDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource><br />
    <table>
	<tr>
		<td class="prvi">Podatci:</td>
		<td>Mesnica</td>
		<td>Ribarnica</td>
		<td>Gastro odijel</td>
		<td>Poslovnica</td>
	</tr>
	<tr>
		<td class="prvi">Ukupan broj radnika:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Broj radnika koji su radili:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Broj radnika na slobodnim danima:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Broj radnika na godišnjem odmoru:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Broj radnika na kratkotrajnom bolovanju:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Broj radnika na dugotrajnom bolovanju:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Broj studenata:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Utrošeni radni sati:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Promet:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td class="prvi">Učinkovitost:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td></td>
		<td></td>
		<td></td>
		<td></td>
        <td><input type="button" value="Posalji" onclick="Posalji()"></td>
	</tr>
	</table>
    </div>
    <div >
    <table>
        <tr>
            <td><h1>Unos novog korisnika</h1></td>
            <td></td>
        </tr>
        <tr>
            <td>Razina korisnika:</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Value="4">Korisnik</asp:ListItem>
                    <asp:ListItem Value="3">Poslovnica</asp:ListItem>
                    <asp:ListItem Value="2">Regionalni menadzer</asp:ListItem>
                    <asp:ListItem Value="1">Admin</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Username:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
