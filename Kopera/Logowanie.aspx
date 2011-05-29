<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Logowanie.aspx.cs" Inherits="Kopera.Logowanie" %>
<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Panel Administratora:&nbsp;
        <asp:Label ID="LabelOstrzezenie" runat="server"></asp:Label>
    </p>
    <p>
        Login: 
        <asp:TextBox ID="TextBoxLogin" runat="server" Width="220px"></asp:TextBox>
    </p>
    <p>
        Hasło:
        <asp:TextBox ID="TextBoxHaslo" runat="server" Width="220px"></asp:TextBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:Button ID="ButtonLoguj" runat="server" onclick="ButtonLoguj_Click" 
            Text="Loguj" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
