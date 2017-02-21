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
    public partial class PerguntasCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipo.SelectedItem.Text = "OPME";
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Perguntas p = new Perguntas();
                p.Descricao = txtPergunta.Text;
                p.Tipo = ddlTipo.Text;

                PerguntasDAL pd = new PerguntasDAL();
                pd.Inserir(p);

                txtPergunta.Text = string.Empty;
                lblMensagem.Text = "Pergunta cadastrada com sucesso!";

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}