<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="PerguntasCadastro.aspx.cs" Inherits="Web.Pages.PerguntasCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Cadastro de Perguntas</h2>

    <span>Pergunta:</span><br />
    <br />

    <asp:TextBox ID="txtPergunta" runat="server" TextMode="MultiLine"></asp:TextBox><br />
     <asp:RequiredFieldValidator ID="ValidaPergunta" runat="server"
        ControlToValidate="txtPergunta"
        ErrorMessage="Este campo não pode ficar em branco."
        ForeColor="Red"
        Display="Dynamic" />
    <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon"></asp:Label>
    <br />
    <br />
   

    <span>Tipo:</span><br />
    <br />

     <asp:DropDownList ID="ddlTipo" runat="server" >
         <asp:ListItem Value="OPME" Text="OPME"/>
         <asp:ListItem Value="MATMED" Text="MATMED" />
         <asp:ListItem Value="INFRA" Text="INFRA" />
         <asp:ListItem Value="TODOS" Text="TODOS" />
     </asp:DropDownList>

    <br />
    <br />
    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="submit" OnClick="btnCadastrar_Click" />

</asp:Content>


