<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="PerguntasListaSelecionar.aspx.cs" Inherits="Web.Pages.PerguntasListaSelecionar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Lista de Perguntas cadastradas</h2>
    <asp:Label ID="lblMensagem" runat="server" ForeColor="Maroon" Width="100%"></asp:Label>

    <asp:GridView ID="gridPerguntas" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="gridPerguntas_PageIndexChanging" PagerSettings-Mode="NumericFirstLast" >
        <EmptyDataTemplate>Nenhuma pergunta encontrada!!</EmptyDataTemplate>

        <Columns>

            <asp:TemplateField HeaderText="Marcar" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                <ItemTemplate>

                    <asp:CheckBox ID="chkPergunta" runat="server" />
                    <asp:HiddenField ID="IdPergunta" runat="server" Value='<%# Eval("IdPergunta") %>' />

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Código" Visible="false" ItemStyle-CssClass="search">
                <ItemTemplate>
                    <%# Eval("IdPergunta") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Pergunta">
                <ItemTemplate>
                    <%# Eval("Descricao") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Tipo">
                <ItemTemplate>
                    <%# Eval("Tipo") %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
             
      <asp:Button ID="btnSalvar" runat="server" Text="Salvar" class="submit" OnClick="btnSalvar_Click"/> 
           
</asp:Content>
