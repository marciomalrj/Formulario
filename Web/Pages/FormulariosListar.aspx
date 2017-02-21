<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="FormulariosListar.aspx.cs" Inherits="Web.Pages.FormulariosListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Lista de Formulários criados</h2>
    <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon" Width="100%"></asp:Label>

    <asp:GridView ID="gridFormularios" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gridFormularios_PageIndexChanging" PagerSettings-Mode="NumericFirstLast">
        <EmptyDataTemplate>Nenhum Formulário encontrado!!</EmptyDataTemplate>

        <Columns>

            <asp:TemplateField HeaderText="Código" Visible="false">
                <ItemTemplate>
                    <%# Eval("IdFormulario") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Formulário">
                <ItemTemplate>
                    <a href="FormulariosDetalhes?id=<%# Eval("IdFormulario") %>"><%# Eval("Nome") %></a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Empresa">
                <ItemTemplate>
                    <%# Eval("Empresa") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Data Criação">
                <ItemTemplate>
                    <%# Eval("DataCriacao") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Data Conclusão">
                <ItemTemplate>
                    <%# Eval("DataConclusao") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="último Acesso">
                <ItemTemplate>
                    <%# Eval("UltimoAcesso") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acessado">
                <ItemTemplate>
                    <%# Eval("Acessado") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Operação">
                <ItemTemplate>
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="submit" OnClick="btnExcluir_Click" CommandArgument='<%# Eval("IdFormulario") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <div>
        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="submit" OnClick="btnCadastrar_Click" />
    </div>


</asp:Content>
