<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Kopera.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Panel Administratora</p>
<p>
    <asp:Button ID="ButtonDodaj" runat="server" onclick="ButtonDodaj_Click" 
        Text="Dodaj" />
&nbsp;
    <asp:Button ID="ButtonUsun" runat="server" onclick="ButtonUsun_Click" 
        Text="Usun" />
</p>
<asp:Panel ID="PanelDodaj" runat="server" Visible="False" style="text-align: left">
    Dodaj ogłoszenie
    <br />
    <br />
    Wybierz kategorie:
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="ListBoxKategoriaDodaj" runat="server" Height="122px">
        <asp:ListItem Value="Agregaty"></asp:ListItem>
        <asp:ListItem Value="Maszyny"></asp:ListItem>
        <asp:ListItem Value="Materialy Budowlane">Materialy Budowlane</asp:ListItem>
        <asp:ListItem Value="Odzież"></asp:ListItem>
        <asp:ListItem Value="Opony"></asp:ListItem>
        <asp:ListItem Value="Pojazdy"></asp:ListItem>
        <asp:ListItem Value="Różne"></asp:ListItem>
    </asp:ListBox>
    <br />
    <br />
    Opis:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBoxOpis" runat="server" Height="200px" 
        TextMode="MultiLine" Width="400px"></asp:TextBox>
    <br />
    <br />
    Cena:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBoxCena" runat="server" Width="200px"></asp:TextBox>
    <br />
    <br />
    Zdjecie:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:FileUpload ID="FileUploadZdjecie" runat="server" />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ButtonDodajZdjecie" runat="server" Text="Dodaj" Width="217px" />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <center>
    <asp:Button ID="ButtonAkceptuj" runat="server" Text="Akceptuj" />
    </center>
    <br />
    
    <br />
</asp:Panel>
<asp:Panel ID="PanelUsun" runat="server" Visible="False">
    Usun Ogłoszenie
    <br />
    <br />
    Wybierz kategorie:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="ListBoxKategoriaUsun" runat="server" Height="122px" 
        onselectedindexchanged="ListBoxKategoriaUsun_SelectedIndexChanged" 
        AutoPostBack="True">
        <asp:ListItem Value="Agregaty"></asp:ListItem>
        <asp:ListItem Value="Maszyny"></asp:ListItem>
        <asp:ListItem Value="MaterialyBudowlane">Materialy Budowlane</asp:ListItem>
        <asp:ListItem Value="Odziez">Odzież</asp:ListItem>
        <asp:ListItem Value="Opony"></asp:ListItem>
        <asp:ListItem Value="Pojazdy"></asp:ListItem>
        <asp:ListItem Value="Rozne">Różne</asp:ListItem>
    </asp:ListBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridViewKategoria" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="opis" HeaderText="opis" SortExpression="opis" />
            <asp:BoundField DataField="cena" HeaderText="cena" SortExpression="cena" />
            <asp:BoundField DataField="foto" HeaderText="foto" SortExpression="foto" />
        </Columns>
    </asp:GridView>
    
    <br />
    <br />
</asp:Panel>

</asp:Content>
