<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="FormulariosEditar.aspx.cs" Inherits="Web.Pages.FormulariosEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Detalhes do Formulário</h2>
    
       <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon" Width="100%" /><br /><br />
   
     <div>

        <span>Nome do Formulário: </span><br />
        <asp:TextBox ID="txtNome" runat="server" />
        <br />
        <br />

        <span>Nome da Empresa:</span><br />
        <asp:TextBox ID="txtEmpresa" runat="server" />
        <br />
        <br />
       
        <span>Email: </span><br />
        <asp:TextBox ID="txtEmail" runat="server" />
        <br />
        <br />
    </div>
    <hr />

    <div>
        <asp:Literal runat="server" ID="ltrPerguntas" />
    </div>

    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" class="submit" OnClick="btnSalvar_Click" CommandArgument='<%# Eval("IdPergunta") %>' />
</asp:Content>
