using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Persistencia;
using Entidades;
using System.Net;

namespace Web.Pages
{
    public partial class FormulariosDetalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int id = Int32.Parse(Request.QueryString["id"]);

                    Response.Cookies["idFormulario"].Value = id.ToString();
                    Response.Cookies["idFormulario"].Expires = DateTime.Now.AddMinutes(10);

                    FormulariosDAL fd = new FormulariosDAL();

                    Formulario f = fd.BuscaPorId(id);

                    ltrNome.Text = f.Nome;
                    ltrEmpresa.Text = f.Empresa;
                    ltrDataCriacao.Text = f.DataCriacao.ToString("dd/MM/yyyy");
                    ltrDataConclusao.Text = f.DataConclusao.ToString() != "" ? DateTime.Parse(f.DataConclusao).ToString("dd/MM/yyyy") : "N/A";
                    ltrUltimoAcesso.Text = f.UltimoAcesso.ToString() != "" ? DateTime.Parse(f.UltimoAcesso).ToString("dd/MM/yyyy") : "N/A";
                    ltrAcessado.Text = f.Acessado;

                    PerguntasPorFormulariosDAL ppfd = new PerguntasPorFormulariosDAL();
                    gridPerguntas.DataSource = ppfd.ListaPerguntasVinculadas(id);
                    gridPerguntas.DataBind();
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message; ;
                }
            }
        }

        protected void btnAddPerguntas_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerguntasListaSelecionar.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int idFormulario = Int32.Parse(Request.Cookies["idFormulario"].Value);
                Button btnExcluir = (Button)sender;
                //resgatar o id enviado pelo CommandArgumment
                int idPergunta = Int32.Parse(btnExcluir.CommandArgument);

                PerguntasPorFormulariosDAL pd = new PerguntasPorFormulariosDAL();
                pd.Excluir(idFormulario, idPergunta);

                lblMensagem.Text = "Pergunta excluida com sucesso!";
                Response.Redirect("FormulariosDetalhes?id=" + idFormulario);

            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idFormulario = Int32.Parse(Request.Cookies["idFormulario"].Value);
            Response.Redirect("FormulariosEditar?id=" + idFormulario);
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            int idFormulario = Int32.Parse(Request.Cookies["idFormulario"].Value);
            Response.Redirect("EnviarEmail?id=" + idFormulario);
        }

    }
}