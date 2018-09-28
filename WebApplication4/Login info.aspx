<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login info.aspx.cs" Inherits="WebApplication4.Login_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login info</title>
    <style>
        div{
            text-align: center;
            width:auto;
            margin-left: auto;
	        margin-right: auto;
        }
        .naslov {
    font-size: 150%;
    font-style: oblique;
    color: black;
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
            <b>
            <br />
            <span class="naslov">Povijest logiranja svih korisnika</span><br />
            </b><br /><hr /><br />

        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="20">
            <Columns>
                <asp:BoundField DataField="LoginId" HeaderText="LoginId" InsertVisible="False" ReadOnly="True" SortExpression="LoginId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Vrijeme_prijave" HeaderText="Vrijeme_prijave" SortExpression="Vrijeme_prijave" />
            </Columns>
            <HeaderStyle BackColor="#E90000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT LoginId, Username, Vrijeme_prijave FROM Users U
left outer join Logins L on L.UserId = U.UserId
WHERE LoginId is not null
ORDER BY LoginId DESC"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" CssClass="botun" runat="server" OnClick="Button1_Click" Text="Povratak" />
    </form>
</body>
</html>
