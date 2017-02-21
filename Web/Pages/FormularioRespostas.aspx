<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Formulario.Master" AutoEventWireup="true" CodeBehind="FormularioRespostas.aspx.cs" Inherits="Web.Pages.FormularioRespostas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Formulário de Respostas</h2>
    <asp:Label ID="lblMensagem" runat="server" Text="" ForeColor="Maroon" Width="100%"></asp:Label><br />
    
    <div>
        <asp:Literal ID="ltrConteudo" runat="server"></asp:Literal>
    </div>

    <asp:Button ID="btnEnviar" runat="server" Text="Enviar Formulário" CssClass="submit" OnClick="btnEnviar_Click" OnClientClick="return confirm('Obrigado pelas informaçoes!');"/>
</asp:Content>
