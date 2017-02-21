using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Persistencia;

namespace Web.Pages
{
    public partial class FormulariosListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FormulariosDAL fd = new FormulariosDAL();
                gridFormularios.DataSource = fd.BuscarTodos();
                gridFormularios.DataBind();
            }

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //sender -> sempre é o elemento que chamou o evento.. (Button)
                Button btnExcluir = (Button)sender;
                //resgatar o id enviado pelo CommandArgumment
                int id = Int32.Parse(btnExcluir.CommandArgument);

                FormulariosDAL fd = new FormulariosDAL();
                fd.Excluir(id);

                Response.Redirect("FormulariosListar.aspx");
                lblMensagem.Text = "Formulário excluido com sucesso!";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormulariosCadastrar.aspx");
        }

        protected void gridFormularios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridFormularios.PageIndex = e.NewPageIndex;

            FormulariosDAL fd = new FormulariosDAL();
            gridFormularios.DataSource = fd.BuscarTodos();
            gridFormularios.DataBind();
        }
    }
}