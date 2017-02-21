<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="RespostaslistarPorFormulario.aspx.cs" Inherits="Web.Pages.RespostaslistarPorFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Lista de Respostas da empresa </h2>

    <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon" Width="100%" /> <br /><br />
    
    <asp:Literal ID="ltrConteudo" runat="server"></asp:Literal>

</asp:Content>
