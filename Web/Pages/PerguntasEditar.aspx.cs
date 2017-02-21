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
    public partial class PerguntasEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int id = Int32.Parse(Request.QueryString["id"].ToString());
                PerguntasDAL pd = new PerguntasDAL();
                Perguntas p = new Perguntas();

                p = pd.BuscaPorId(id);
                txtPergunta.Text = p.Descricao;
                ddlTipo.SelectedValue = p.Tipo;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                PerguntasDAL pd = new PerguntasDAL();
                Perguntas p = new Perguntas();

                p.IdPergunta = Int32.Parse(Request.QueryString["id"].ToString());
                p.Descricao = txtPergunta.Text;
                p.Tipo = ddlTipo.SelectedValue;

                pd.Atualizar(p);

                lblMensagem.Text = "Pergunta atualizada cm sucesso!!";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
 
        }
    }
}