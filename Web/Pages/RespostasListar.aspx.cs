using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using DAL.Persistencia;

namespace Web.Pages
{
    public partial class RespostasListar : System.Web.UI.Page
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

        protected void btnRespostas_Click(object sender, EventArgs e)
        {
            //sender -> sempre é o elemento que chamou o evento.. (Button)
            Button btnExcluir = (Button)sender;
            //resgatar o id enviado pelo CommandArgumment
            int id = Int32.Parse(btnExcluir.CommandArgument);

            Response.Redirect("RespostaslistarPorFormulario.aspx?form=" + id);
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