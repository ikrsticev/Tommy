<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Poslovnica.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
	</style>
	<script type="text/javascript">

		window.onload = function(){
            
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
    <h1>Poslovnica
        <asp:Label ID="LabelPoslovnica" runat="server"></asp:Label>
        </h1>
        <hr>
	<table>
	<tr>
		<td>Podatci:</td>
		<td>Mesnica</td>
		<td>Ribarnica</td>
		<td>Gastro odijel</td>
		<td>Poslovnica</td>
	</tr>
	<tr>
		<td>Ukupan broj radnika:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Broj radnika koji su radili:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Broj radnika na slobodnim danima:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Broj radnika na godišnjem odmoru:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Broj radnika na kratkotrajnom bolovanju:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Broj radnika na dugotrajnom bolovanju:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Broj studenata:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Utrošeni radni sati:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Promet:</td>
		<td><input class="mesnica"></td>
		<td><input class="ribarnica"></td>
		<td><input class="gastro"></td>
		<td><input class="poslovnica"></td>
	</tr>
	<tr>
		<td>Učinkovitost:</td>
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
	</table><hr>
    </form>
</body>
</html>
