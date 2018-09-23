<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administracija.aspx.cs" Inherits="WebApplication4.Administracija" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="float:left">
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
        <div style="margin-left:575px; padding-left: 25px; border-left-width: 1px; border-left-style: solid;">

        
        Promijeni odjele poslovnice:<br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Broj_poslovnice" DataValueField="Broj_poslovnice" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT [Broj poslovnice] AS Broj_poslovnice FROM [Poslovnica]"></asp:SqlDataSource>
        <br />
        <asp:CheckBox ID="cbxMesnica" runat="server" Text="Mesnica" />
        <br />
        <asp:CheckBox ID="cbxRibarnica" runat="server" Text="Ribarnica" />
        <br />
        <asp:CheckBox ID="cbxGastro" runat="server" Text="Gastro odjel" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Spremi promjene" OnClick="Button1_Click" />
            </div>
        <br /><hr /><br />
        <div style="margin-left:575px; padding-left: 25px; border-left-width: 1px; border-left-style: solid;">

            Promijeni poslovnice regionalnog menadžera:<br />
            <asp:DropDownList ID="DropDownRM" runat="server" DataSourceID="SqlDataSource3" DataTextField="Username" DataValueField="Username" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownPoslovnice" runat="server" DataSourceID="SqlDataSource4" DataTextField="Broj_poslovnice" DataValueField="Broj_poslovnice" AutoPostBack="true">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT [Broj poslovnice] AS Broj_poslovnice FROM [Poslovnica]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT [Username] FROM [Users] WHERE ([RazinaId] = @RazinaId)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="RazinaId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="btnUkloniPoslovnicu" runat="server" Text="Ukloni poslovnicu iz liste" OnClick="btnUkloniPoslovnicu_Click" />

            <asp:Button ID="btnDodajPoslovnicu" runat="server" OnClick="btnDodajPoslovnicu_Click" Text="Dodaj poslovnicu u listu" />
            <br />
            <asp:Button ID="btnUnesiPoslovnice" runat="server" Text="Unesi trenutne poslovnice" OnClick="btnUnesiPoslovnice_Click" />

        </div>
    </form>
</body>
</html>
