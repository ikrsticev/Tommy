<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Korisnik.aspx.cs" Inherits="WebApplication4.Korisnik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Korisnik</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewPoslovnica" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="1" Font-Names="Courier New">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Ukupan broj radnika" HeaderText="Ukupan broj radnika" SortExpression="Ukupan broj radnika" />
                    <asp:BoundField DataField="Broj radnika koji su radili" HeaderText="Broj radnika koji su radili" SortExpression="Broj radnika koji su radili" />
                    <asp:BoundField DataField="Broj radnika na slobodnim danima" HeaderText="Broj radnika na slobodnim danima" SortExpression="Broj radnika na slobodnim danima" />
                    <asp:BoundField DataField="Broj radnika na godišnjem odmoru" HeaderText="Broj radnika na godišnjem odmoru" SortExpression="Broj radnika na godišnjem odmoru" />
                    <asp:BoundField DataField="Broj radnika na kratkotrajnom bolovanju" HeaderText="Broj radnika na kratkotrajnom bolovanju" SortExpression="Broj radnika na kratkotrajnom bolovanju" />
                    <asp:BoundField DataField="Broj radnika na dugotrajnom bolovanju" HeaderText="Broj radnika na dugotrajnom bolovanju" SortExpression="Broj radnika na dugotrajnom bolovanju" />
                    <asp:BoundField DataField="Broj studenata" HeaderText="Broj studenata" SortExpression="Broj studenata" />
                    <asp:BoundField DataField="Utrošeni radni sati" HeaderText="Utrošeni radni sati" SortExpression="Utrošeni radni sati" />
                    <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                    <asp:BoundField DataField="Učinkovitost" HeaderText="Učinkovitost" SortExpression="Učinkovitost" />
                    <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                    <asp:BoundField DataField="Odjel" HeaderText="Odjel" SortExpression="Odjel" />
                    <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
                </Columns>
                <HeaderStyle BackColor="#E90000" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT ReportId AS ID, Ukupan_broj_radnika AS [Ukupan broj radnika], Broj_radnika_koji_su_radili AS [Broj radnika koji su radili], Broj_radnika_na_slobodnim_danima AS [Broj radnika na slobodnim danima], Broj_radnika_na_godisnjem_odmoru AS [Broj radnika na godišnjem odmoru], Broj_radnika_na_kratkotrajnom_bolovanju AS [Broj radnika na kratkotrajnom bolovanju], Broj_radnika_na_dugotrajnom_bolovanju AS [Broj radnika na dugotrajnom bolovanju], Broj_studenata AS [Broj studenata], Utroseni_radni_sati AS [Utrošeni radni sati], Promet, Ucinkovitost AS Učinkovitost, Datum, OdjelId AS Odjel, PoslovnicaId FROM Report WHERE (OdjelId = @OdjelId) AND (PoslovnicaId = @PoslovnicaId) ORDER BY Datum DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="4" Name="OdjelId" Type="Int32" />
                    <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <asp:GridView ID="GridViewMesnica" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" PageSize="1" Font-Names="Courier New">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Ukupan broj radnika" HeaderText="Ukupan broj radnika" SortExpression="Ukupan broj radnika" />
                <asp:BoundField DataField="Broj radnika koji su radili" HeaderText="Broj radnika koji su radili" SortExpression="Broj radnika koji su radili" />
                <asp:BoundField DataField="Broj radnika na slobodnim danima" HeaderText="Broj radnika na slobodnim danima" SortExpression="Broj radnika na slobodnim danima" />
                <asp:BoundField DataField="Broj radnika na godišnjem odmoru" HeaderText="Broj radnika na godišnjem odmoru" SortExpression="Broj radnika na godišnjem odmoru" />
                <asp:BoundField DataField="Broj radnika na kratkotrajnom bolovanju" HeaderText="Broj radnika na kratkotrajnom bolovanju" SortExpression="Broj radnika na kratkotrajnom bolovanju" />
                <asp:BoundField DataField="Broj radnika na dugotrajnom bolovanju" HeaderText="Broj radnika na dugotrajnom bolovanju" SortExpression="Broj radnika na dugotrajnom bolovanju" />
                <asp:BoundField DataField="Broj studenata" HeaderText="Broj studenata" SortExpression="Broj studenata" />
                <asp:BoundField DataField="Utrošeni radni sati" HeaderText="Utrošeni radni sati" SortExpression="Utrošeni radni sati" />
                <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                <asp:BoundField DataField="Učinkovitost" HeaderText="Učinkovitost" SortExpression="Učinkovitost" />
                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                <asp:BoundField DataField="Odjel" HeaderText="Odjel" SortExpression="Odjel" />
                <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
            </Columns>
            <HeaderStyle BackColor="#E90000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT ReportId as ID, Ukupan_broj_radnika as [Ukupan broj radnika],
Broj_radnika_koji_su_radili as [Broj radnika koji su radili],
Broj_radnika_na_slobodnim_danima as [Broj radnika na slobodnim danima],
Broj_radnika_na_godisnjem_odmoru as [Broj radnika na godišnjem odmoru],
Broj_radnika_na_kratkotrajnom_bolovanju as [Broj radnika na kratkotrajnom bolovanju],
Broj_radnika_na_dugotrajnom_bolovanju as [Broj radnika na dugotrajnom bolovanju],
Broj_studenata as [Broj studenata], Utroseni_radni_sati as [Utrošeni radni sati],
Promet, Ucinkovitost as Učinkovitost, Datum, OdjelId as Odjel, PoslovnicaId
 FROM Report WHERE (([OdjelId] = @OdjelId) AND ([PoslovnicaId] = @PoslovnicaId)) ORDER BY [Datum] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="OdjelId" Type="Int32" />
                <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridViewRibarnica" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource3" PageSize="1" Font-Names="Courier New">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Ukupan broj radnika" HeaderText="Ukupan broj radnika" SortExpression="Ukupan broj radnika" />
                <asp:BoundField DataField="Broj radnika koji su radili" HeaderText="Broj radnika koji su radili" SortExpression="Broj radnika koji su radili" />
                <asp:BoundField DataField="Broj radnika na slobodnim danima" HeaderText="Broj radnika na slobodnim danima" SortExpression="Broj radnika na slobodnim danima" />
                <asp:BoundField DataField="Broj radnika na godišnjem odmoru" HeaderText="Broj radnika na godišnjem odmoru" SortExpression="Broj radnika na godišnjem odmoru" />
                <asp:BoundField DataField="Broj radnika na kratkotrajnom bolovanju" HeaderText="Broj radnika na kratkotrajnom bolovanju" SortExpression="Broj radnika na kratkotrajnom bolovanju" />
                <asp:BoundField DataField="Broj radnika na dugotrajnom bolovanju" HeaderText="Broj radnika na dugotrajnom bolovanju" SortExpression="Broj radnika na dugotrajnom bolovanju" />
                <asp:BoundField DataField="Broj studenata" HeaderText="Broj studenata" SortExpression="Broj studenata" />
                <asp:BoundField DataField="Utrošeni radni sati" HeaderText="Utrošeni radni sati" SortExpression="Utrošeni radni sati" />
                <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                <asp:BoundField DataField="Učinkovitost" HeaderText="Učinkovitost" SortExpression="Učinkovitost" />
                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                <asp:BoundField DataField="Odjel" HeaderText="Odjel" SortExpression="Odjel" />
                <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
            </Columns>
            <HeaderStyle BackColor="#E90000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT ReportId as ID, Ukupan_broj_radnika as [Ukupan broj radnika],
Broj_radnika_koji_su_radili as [Broj radnika koji su radili],
Broj_radnika_na_slobodnim_danima as [Broj radnika na slobodnim danima],
Broj_radnika_na_godisnjem_odmoru as [Broj radnika na godišnjem odmoru],
Broj_radnika_na_kratkotrajnom_bolovanju as [Broj radnika na kratkotrajnom bolovanju],
Broj_radnika_na_dugotrajnom_bolovanju as [Broj radnika na dugotrajnom bolovanju],
Broj_studenata as [Broj studenata], Utroseni_radni_sati as [Utrošeni radni sati],
Promet, Ucinkovitost as Učinkovitost, Datum, OdjelId as Odjel, PoslovnicaId
 FROM Report WHERE (([OdjelId] = @OdjelId) AND ([PoslovnicaId] = @PoslovnicaId)) ORDER BY [Datum] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="OdjelId" Type="Int32" />
                <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridViewGastro" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource4" PageSize="1" Font-Names="Courier New">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Ukupan broj radnika" HeaderText="Ukupan broj radnika" SortExpression="Ukupan broj radnika" />
                <asp:BoundField DataField="Broj radnika koji su radili" HeaderText="Broj radnika koji su radili" SortExpression="Broj radnika koji su radili" />
                <asp:BoundField DataField="Broj radnika na slobodnim danima" HeaderText="Broj radnika na slobodnim danima" SortExpression="Broj radnika na slobodnim danima" />
                <asp:BoundField DataField="Broj radnika na godišnjem odmoru" HeaderText="Broj radnika na godišnjem odmoru" SortExpression="Broj radnika na godišnjem odmoru" />
                <asp:BoundField DataField="Broj radnika na kratkotrajnom bolovanju" HeaderText="Broj radnika na kratkotrajnom bolovanju" SortExpression="Broj radnika na kratkotrajnom bolovanju" />
                <asp:BoundField DataField="Broj radnika na dugotrajnom bolovanju" HeaderText="Broj radnika na dugotrajnom bolovanju" SortExpression="Broj radnika na dugotrajnom bolovanju" />
                <asp:BoundField DataField="Broj studenata" HeaderText="Broj studenata" SortExpression="Broj studenata" />
                <asp:BoundField DataField="Utrošeni radni sati" HeaderText="Utrošeni radni sati" SortExpression="Utrošeni radni sati" />
                <asp:BoundField DataField="Promet" HeaderText="Promet" SortExpression="Promet" />
                <asp:BoundField DataField="Učinkovitost" HeaderText="Učinkovitost" SortExpression="Učinkovitost" />
                <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                <asp:BoundField DataField="Odjel" HeaderText="Odjel" SortExpression="Odjel" />
                <asp:BoundField DataField="PoslovnicaId" HeaderText="PoslovnicaId" SortExpression="PoslovnicaId" />
            </Columns>
            <HeaderStyle BackColor="#E90000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Tommy_upgradeConnectionString %>" SelectCommand="SELECT ReportId as ID, Ukupan_broj_radnika as [Ukupan broj radnika],
Broj_radnika_koji_su_radili as [Broj radnika koji su radili],
Broj_radnika_na_slobodnim_danima as [Broj radnika na slobodnim danima],
Broj_radnika_na_godisnjem_odmoru as [Broj radnika na godišnjem odmoru],
Broj_radnika_na_kratkotrajnom_bolovanju as [Broj radnika na kratkotrajnom bolovanju],
Broj_radnika_na_dugotrajnom_bolovanju as [Broj radnika na dugotrajnom bolovanju],
Broj_studenata as [Broj studenata], Utroseni_radni_sati as [Utrošeni radni sati],
Promet, Ucinkovitost as Učinkovitost, Datum, OdjelId as Odjel, PoslovnicaId
 FROM Report WHERE (([OdjelId] = @OdjelId) AND ([PoslovnicaId] = @PoslovnicaId)) ORDER BY [Datum] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="OdjelId" Type="Int32" />
                <asp:SessionParameter Name="PoslovnicaId" SessionField="PoslId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblLabela" runat="server"></asp:Label>
    </form>
</body>
</html>
