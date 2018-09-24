﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administracija.aspx.cs" Inherits="WebApplication4.Administracija" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administracija</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UserId" DataSourceID="SqlDataSource1" AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="25">
                <AlternatingRowStyle BackColor="White" />
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
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="#FFCC66" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
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
            <br />
            <asp:Label ID="lblUnosOdjeli" runat="server"></asp:Label>
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
            <asp:Button ID="btnUnesiPoslovnice" runat="server" Text="Spremi trenutne poslovnice" OnClick="btnUnesiPoslovnice_Click" />

            <br />
            <asp:Label ID="lblUnosRegPoslovnice" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
