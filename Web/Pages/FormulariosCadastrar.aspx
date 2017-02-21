<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="FormulariosCadastrar.aspx.cs" Inherits="Web.Pages.FormulariosCadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Cadastro de Formulários</h2>
    <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon"></asp:Label><br />
    <br />

    <span>Nome do Formulário:</span><br />
    <br />
    <asp:TextBox ID="txtNome" runat="server" />
    <asp:RequiredFieldValidator ID="ValidaNome" runat="server"
        ControlToValidate="txtNome"
        ErrorMessage="Este campo não pode ficar em branco."
        ForeColor="Red"
        Display="Dynamic" />
    <br />
    <br />

    <span>Nome da Empresa:</span><br />
    <br />

    <asp:TextBox ID="txtEmpresa" runat="server" />
    <br />
    <asp:RequiredFieldValidator ID="ValidaEmpresa" runat="server"
        ControlToValidate="txtEmpresa"
        ErrorMessage="Este campo não pode ficar em branco."
        ForeColor="Red"
        Display="Dynamic" />
    <br />
   
    <span>Email:</span><br />
    <br />

    <asp:TextBox ID="txtEmail" runat="server" />
    <br />
    <asp:RequiredFieldValidator ID="ValidaEmail" runat="server"
        ControlToValidate="txtEmail"
        ErrorMessage="Este campo não pode ficar em branco."
        ForeColor="Red"
        Display="Dynamic" />
    <br />
    <br />

    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="submit" OnClick="btnSalvar_Click" />
</asp:Content>
