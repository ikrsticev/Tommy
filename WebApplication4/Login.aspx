<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="tema.css"/>
    <style type="text/css">
        .container{
            height: 300px;
        }
        #logo{
            width:40%;
        }
        #Button1 {
            width: 173px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <img src="Tommy_logo.jpg" id="logo" />
            <br />
            Korisničko ime:&nbsp; <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" CssClass="botun" runat="server" OnClick="Button1_Click" Text="Log in" />
                    
            
            <br />
            <br />
            
            <asp:Label ID="LabelLogin" runat="server"></asp:Label>
            
        </div>
        
    </form>
</body>
</html>
