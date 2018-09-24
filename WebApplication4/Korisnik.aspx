<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Korisnik.aspx.cs" Inherits="WebApplication4.Korisnik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Korisnik</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewPoslovnica" runat="server" AutoGenerateColumns="False" DataKeyNames="ReportId" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="1">
                <Columns>
                    <asp:BoundField DataField="ReportId" HeaderText="ReportId" InsertVisible="False" ReadOnly="True" SortExpression="ReportId" />
                    <asp:BoundField DataField="Ukupan_broj_radnika" HeaderText="Ukupan_broj_radnika" SortExpression="Ukupan_broj_radnika" />
                    <asp:BoundField DataField="Broj_radnika_koji_su_radili" HeaderText="Broj_radnika_koji_su_radili" SortExpression="Broj_radnika_koji_su_radili" />
                    <asp:BoundField DataField="Broj_radnika_na_slobodnim_danima" HeaderText="Broj_radnika_na_slobodnim_danima" SortExpression="Broj_radnika_na_slobodnim_danima" />
                    <asp:BoundField DataField="Broj_radnika_na_godisnjem_odmoru" HeaderText="Broj_radnika_na_godisnjem_odmoru" SortExpression="Broj_radnika_na_godisnjem_odmoru" />
                    <asp:BoundField DataField="Broj_radnika_na_kratkotrajnom_bolovanju" HeaderText="Broj_radnika_na_kratkotrajnom_bolovanju" SortExpression="Broj_radnika_na_kratkotrajnom_bolovanju" />
                    <asp:BoundField DataField="Broj_radnika_na_dugotrajnom_bolovanju" HeaderText="Broj_radnika_na_dugotrajnom_bolovanju" SortExpression="Broj_radnika_na_dugotrajnom_bolovanju" />
                    <asp:BoundField DataField="Broj_studenata" HeaderText="Broj_studenata" SortExpression="Broj_studenata" />
                    <asp:BoundField DataField="Utroseni_radni_sati" HeaderText="Utroseni_radni_sati" SortExpression="Utroseni_radni_sati" />
                    <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                    <asp:BoundField DataField="Ucinkovitost" HeaderText="Ucinkovitost" SortExpression="Ucinkovitost" />
                    <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                    <asp:BoundField DataField="OdjelId" HeaderText="OdjelId" SortExpression="OdjelId" />
                    <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT * FROM [Report] WHERE (([OdjelId] = @OdjelId) AND ([PoslovnicaId] = @PoslovnicaId)) ORDER BY [Datum] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="4" Name="OdjelId" Type="Int32" />
                    <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <asp:GridView ID="GridViewMesnica" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ReportId" DataSourceID="SqlDataSource2" PageSize="1">
            <Columns>
                <asp:BoundField DataField="ReportId" HeaderText="ReportId" InsertVisible="False" ReadOnly="True" SortExpression="ReportId" />
                <asp:BoundField DataField="Ukupan_broj_radnika" HeaderText="Ukupan_broj_radnika" SortExpression="Ukupan_broj_radnika" />
                <asp:BoundField DataField="Broj_radnika_koji_su_radili" HeaderText="Broj_radnika_koji_su_radili" SortExpression="Broj_radnika_koji_su_radili" />
                <asp:BoundField DataField="Broj_radnika_na_slobodnim_danima" HeaderText="Broj_radnika_na_slobodnim_danima" SortExpression="Broj_radnika_na_slobodnim_danima" />
                <asp:BoundField DataField="Broj_radnika_na_godisnjem_odmoru" HeaderText="Broj_radnika_na_godisnjem_odmoru" SortExpression="Broj_radnika_na_godisnjem_odmoru" />
                <asp:BoundField DataField="Broj_radnika_na_kratkotrajnom_bolovanju" HeaderText="Broj_radnika_na_kratkotrajnom_bolovanju" SortExpression="Broj_radnika_na_kratkotrajnom_bolovanju" />
                <asp:BoundField DataField="Broj_radnika_na_dugotrajnom_bolovanju" HeaderText="Broj_radnika_na_dugotrajnom_bolovanju" SortExpression="Broj_radnika_na_dugotrajnom_bolovanju" />
                <asp:BoundField DataField="Broj_studenata" HeaderText="Broj_studenata" SortExpression="Broj_studenata" />
                <asp:BoundField DataField="Utroseni_radni_sati" HeaderText="Utroseni_radni_sati" SortExpression="Utroseni_radni_sati" />
                <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                <asp:BoundField DataField="Ucinkovitost" HeaderText="Ucinkovitost" SortExpression="Ucinkovitost" />
                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                <asp:BoundField DataField="OdjelId" HeaderText="OdjelId" SortExpression="OdjelId" />
                <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT * FROM [Report] WHERE (([OdjelId] = @OdjelId) AND ([PoslovnicaId] = @PoslovnicaId)) ORDER BY [Datum] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="OdjelId" Type="Int32" />
                <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridViewRibarnica" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ReportId" DataSourceID="SqlDataSource3" PageSize="1">
            <Columns>
                <asp:BoundField DataField="ReportId" HeaderText="ReportId" InsertVisible="False" ReadOnly="True" SortExpression="ReportId" />
                <asp:BoundField DataField="Ukupan_broj_radnika" HeaderText="Ukupan_broj_radnika" SortExpression="Ukupan_broj_radnika" />
                <asp:BoundField DataField="Broj_radnika_koji_su_radili" HeaderText="Broj_radnika_koji_su_radili" SortExpression="Broj_radnika_koji_su_radili" />
                <asp:BoundField DataField="Broj_radnika_na_slobodnim_danima" HeaderText="Broj_radnika_na_slobodnim_danima" SortExpression="Broj_radnika_na_slobodnim_danima" />
                <asp:BoundField DataField="Broj_radnika_na_godisnjem_odmoru" HeaderText="Broj_radnika_na_godisnjem_odmoru" SortExpression="Broj_radnika_na_godisnjem_odmoru" />
                <asp:BoundField DataField="Broj_radnika_na_kratkotrajnom_bolovanju" HeaderText="Broj_radnika_na_kratkotrajnom_bolovanju" SortExpression="Broj_radnika_na_kratkotrajnom_bolovanju" />
                <asp:BoundField DataField="Broj_radnika_na_dugotrajnom_bolovanju" HeaderText="Broj_radnika_na_dugotrajnom_bolovanju" SortExpression="Broj_radnika_na_dugotrajnom_bolovanju" />
                <asp:BoundField DataField="Broj_studenata" HeaderText="Broj_studenata" SortExpression="Broj_studenata" />
                <asp:BoundField DataField="Utroseni_radni_sati" HeaderText="Utroseni_radni_sati" SortExpression="Utroseni_radni_sati" />
                <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                <asp:BoundField DataField="Ucinkovitost" HeaderText="Ucinkovitost" SortExpression="Ucinkovitost" />
                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                <asp:BoundField DataField="OdjelId" HeaderText="OdjelId" SortExpression="OdjelId" />
                <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT * FROM [Report] WHERE (([OdjelId] = @OdjelId) AND ([PoslovnicaId] = @PoslovnicaId)) ORDER BY [Datum] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="OdjelId" Type="Int32" />
                <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridViewGastro" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ReportId" DataSourceID="SqlDataSource4" PageSize="1">
            <Columns>
                <asp:BoundField DataField="ReportId" HeaderText="ReportId" InsertVisible="False" ReadOnly="True" SortExpression="ReportId" />
                <asp:BoundField DataField="Ukupan_broj_radnika" HeaderText="Ukupan_broj_radnika" SortExpression="Ukupan_broj_radnika" />
                <asp:BoundField DataField="Broj_radnika_koji_su_radili" HeaderText="Broj_radnika_koji_su_radili" SortExpression="Broj_radnika_koji_su_radili" />
                <asp:BoundField DataField="Broj_radnika_na_slobodnim_danima" HeaderText="Broj_radnika_na_slobodnim_danima" SortExpression="Broj_radnika_na_slobodnim_danima" />
                <asp:BoundField DataField="Broj_radnika_na_godisnjem_odmoru" HeaderText="Broj_radnika_na_godisnjem_odmoru" SortExpression="Broj_radnika_na_godisnjem_odmoru" />
                <asp:BoundField DataField="Broj_radnika_na_kratkotrajnom_bolovanju" HeaderText="Broj_radnika_na_kratkotrajnom_bolovanju" SortExpression="Broj_radnika_na_kratkotrajnom_bolovanju" />
                <asp:BoundField DataField="Broj_radnika_na_dugotrajnom_bolovanju" HeaderText="Broj_radnika_na_dugotrajnom_bolovanju" SortExpression="Broj_radnika_na_dugotrajnom_bolovanju" />
                <asp:BoundField DataField="Broj_studenata" HeaderText="Broj_studenata" SortExpression="Broj_studenata" />
                <asp:BoundField DataField="Utroseni_radni_sati" HeaderText="Utroseni_radni_sati" SortExpression="Utroseni_radni_sati" />
                <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                <asp:BoundField DataField="Ucinkovitost" HeaderText="Ucinkovitost" SortExpression="Ucinkovitost" />
                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                <asp:BoundField DataField="OdjelId" HeaderText="OdjelId" SortExpression="OdjelId" />
                <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT * FROM [Report] WHERE (([OdjelId] = @OdjelId) AND ([PoslovnicaId] = @PoslovnicaId)) ORDER BY [Datum] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="OdjelId" Type="Int32" />
                <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblLabela" runat="server"></asp:Label>
    </form>
</body>
</html>
