<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="RespostasListar.aspx.cs" Inherits="Web.Pages.RespostasListar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Listas de Respostas</h2>

        <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon" Width="100%"></asp:Label>

    <asp:GridView ID="gridFormularios" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false" AllowPaging="true"  OnPageIndexChanging="gridFormularios_PageIndexChanging" PagerSettings-Mode="NumericFirstLast">
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

            <asp:TemplateField HeaderText="Operação">
                <ItemTemplate>
                    <asp:Button ID="btnRespostas" runat="server" Text="Ver Respostas" class="submit" OnClick="btnRespostas_Click" CommandArgument='<%# Eval("IdFormulario") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


</asp:Content>
