<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administracija.aspx.cs" Inherits="WebApplication4.Administracija" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="UserId" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime" />
                    <asp:BoundField DataField="prezime" HeaderText="prezime" SortExpression="prezime" />
                    <asp:BoundField DataField="RazinaId" HeaderText="RazinaId" SortExpression="RazinaId" />
                    <asp:CheckBoxField DataField="disabled" HeaderText="disabled" SortExpression="disabled" />
                    <asp:CheckBoxField DataField="write" HeaderText="write" SortExpression="write" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" DeleteCommand="DELETE FROM [Users] WHERE [UserId] = @UserId" InsertCommand="INSERT INTO [Users] ([Username], [Ime], [prezime], [RazinaId], [disabled], [write]) VALUES (@Username, @Ime, @prezime, @RazinaId, @disabled, @write)" SelectCommand="SELECT * FROM [Users]" UpdateCommand="UPDATE [Users] SET [Username] = @Username, [Ime] = @Ime, [prezime] = @prezime, [RazinaId] = @RazinaId, [disabled] = @disabled, [write] = @write WHERE [UserId] = @UserId">
                <UpdateParameters>
                    <asp:Parameter Name="Username" Type="String" />
                    <asp:Parameter Name="Ime" Type="String" />
                    <asp:Parameter Name="prezime" Type="String" />
                    <asp:Parameter Name="RazinaId" Type="Int32" />
                    <asp:Parameter Name="disabled" Type="Boolean" />
                    <asp:Parameter Name="write" Type="Boolean" />
                    <asp:Parameter Name="UserId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Povratak" />
        </div>
    </form>
</body>
</html>
