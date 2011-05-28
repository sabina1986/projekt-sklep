<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kopera.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style5
        {
            text-align: center;
            font-size: xx-large;
        }
    .style6
    {
        font-family: "Comic Sans MS";
        font-size: xx-large;
        color: #33CCFF;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="630px">

        <div class="style5">
            <strong style="text-align: left">
            <br />
            Witamy<br /> nasz firma zajmuje się sprzedaża<br /> maszyn prądotwórczych, 
            pojazdów, opon,<br /> materiałów budowlanych oraz usług transportowych<br />
            <br />
            </strong>
        </div>

        <div style="font-size: medium; font-family: 'Times New Roman', Times, serif">

            Dane Kontaktowe:<br /> Paweł Kopera<br /> ul. Częstochowska 45<br /> 42-120 
            Miedźno<br /> tel: 601 886 563
            <br />
            <br />
        </div>
        <br />
        <br />
        <div style="text-align: center">

            <span class="style6">ZAPRASZAMY </span>
            <br class="style6" />
            <span class="style6">DO ZAPOZNANIA SIE Z </span>
            <br class="style6" />
            <span class="style6">NASZĄ OFERTA</span></div>

    </asp:Panel>
</asp:Content>
