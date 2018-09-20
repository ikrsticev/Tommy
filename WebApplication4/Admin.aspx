<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication4.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div{
            text-align: center;
            width:auto;
            margin-left: auto;
	        margin-right: auto;
        }
	</style>
	<script type="text/javascript">

        window.onload = function () {

		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <span>User:<asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
&nbsp; </span>
    <div>

        <asp:Button ID="btnAdministracija" runat="server" Text="Pregled i administracija korisnika" OnClick="btnAdministracija_Click" />

        <br />
        <br />
        <asp:Button ID="btnUnos" runat="server" OnClick="btnUnos_Click" Text="Unos novog korisnika" />

    </div>
    </form>
</body>
</html>
