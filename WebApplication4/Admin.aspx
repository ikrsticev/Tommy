<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication4.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link rel="stylesheet" type="text/css" href="tema.css"/>
    <style>
        div{
            text-align: center;
            width:auto;
            margin-left: auto;
	        margin-right: auto;
        }
        #btnAdministracija{
            width: 35%;
        }
        #btnUnos{
            width: 25%;
        }
        #btnLogout{
            width: 15%;
        }
	</style>
	<script type="text/javascript">

        window.onload = function () {

		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    <span class="naslov">Admin</span>
        <br /><hr /><br />
    <span style="color:black;"><b>User:<asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label></b>
&nbsp; 
        <br />
        <br />
        </span>
    

        <asp:Button ID="btnAdministracija" CssClass="botun" runat="server" Text="Pregled i administracija korisnika" OnClick="btnAdministracija_Click" />

        <br />
        <br />
        &nbsp;<asp:Button ID="btnUnos" CssClass="botun" runat="server" OnClick="btnUnos_Click" Text="Unos novog korisnika" />

        <br />
        <br />
        &nbsp;<asp:Button ID="Button1" CssClass="botun" runat="server" OnClick="Button1_Click" Text="Pregled logina" />

        <br />
        <br />
        <asp:Button ID="btnLogout" CssClass="botun" runat="server" OnClick="btnLogout_Click" Text="Logout" />

    </div>
    </form>
</body>
</html>
