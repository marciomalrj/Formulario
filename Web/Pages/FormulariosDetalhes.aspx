<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="FormulariosDetalhes.aspx.cs" Inherits="Web.Pages.FormulariosDetalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalhes do Formulário</h2>
   <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon" Width="100%"></asp:Label>
    <div>

        <span>Nome do Formulário: </span>
        <asp:Literal ID="ltrNome" runat="server" />
        <br />

        <span>Nome da Empresa:</span>
        <asp:Literal ID="ltrEmpresa" runat="server" />
        <br />

        <span>Data da Criação: </span>
        <asp:Literal ID="ltrDataCriacao" runat="server" />
        <br />

        <span>Data da Conclusão: </span>
        <asp:Literal ID="ltrDataConclusao" runat="server" />
        <br />

        <span>Último Acesso: </span>
        <asp:Literal ID="ltrUltimoAcesso" runat="server" />
        <br />

        <span>Acessado: </span>
        <asp:Literal ID="ltrAcessado" runat="server" />
        <br />
        <br />
    </div>
    <hr />

    <div>
        <asp:Literal runat="server" ID="ltrPerguntas" />
    </div>

    <div id="perguntas">

           <h2>Lista de Perguntas Associadas</h2>
     <asp:Label ID="Label1" runat="server" ForeColor="Maroon"></asp:Label>

    <asp:GridView ID="gridPerguntas" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false">
        <EmptyDataTemplate>Nenhuma pergunta associada!!</EmptyDataTemplate>

        <Columns>

            <asp:TemplateField HeaderText="Código" Visible="false">
                <ItemTemplate>
                    <%# Eval("IdPergunta") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Pergunta">
                <ItemTemplate>
                    <a href="PerguntasEditar?id=<%# Eval("IdPergunta") %>"><%# Eval("Descricao") %></a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo">
                <ItemTemplate>
                    <%# Eval("Tipo") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Operação">
                <ItemTemplate>
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="submit" OnClick="btnExcluir_Click" CommandArgument='<%# Eval("IdPergunta") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    </div>

    <asp:Button ID="btnAddPerguntas" runat="server" Text="Cadastrar Perguntas" CssClass="submit" OnClick="btnAddPerguntas_Click" />
    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="submit" OnClick="btnEditar_Click" />
    <asp:Button ID="btnEmail" runat="server" Text="Enviar Email" CssClass="submit" OnClick="btnEmail_Click" />


</asp:Content>
