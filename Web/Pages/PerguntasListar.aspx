<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="PerguntasListar.aspx.cs" Inherits="Web.Pages.PerguntasListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- <select id="ddlTipo" style="width: 100px" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged"> <option value="" selected="selected" >Tipo</option> <option value="INFRA">INFRA</option> <option value="TODOS">TODOS</option>  <option value="OPME">OPME</option> <option value="MATMED">MATMED</option> </select> -->
    <h2>Lista de Perguntas cadastradas</h2>
    <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon" Width="100%"></asp:Label>

    <asp:GridView ID="gridPerguntas" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gridPerguntas_PageIndexChanging" PagerSettings-Mode="NumericFirstLast">
        <EmptyDataTemplate>Nenhuma pergunta encontrada!!</EmptyDataTemplate>

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
                    
            <asp:TemplateField HeaderText="Tipo" >
                <ItemTemplate>
                    <%# Eval("Tipo") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Operação">
                <ItemTemplate>
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="submit" OnClick="btnExcluir_Click" CommandArgument='<%# Eval("IdPergunta") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div>
        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="submit" OnClick="btnCadastrar_Click" />
    </div>

    <!--
            <asp:TemplateField HeaderText="Marcar">
                <ItemTemplate>
                    <asp:CheckBox ID="chkPergunta" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
-->
</asp:Content>
