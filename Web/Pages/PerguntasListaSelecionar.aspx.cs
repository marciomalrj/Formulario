using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Persistencia;

namespace Web.Pages
{
    public partial class PerguntasListaSelecionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PerguntasDAL pd = new PerguntasDAL();
                gridPerguntas.DataSource = pd.BuscarTodos();
                gridPerguntas.DataBind();
               
            }
            
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int idFormulario = Int32.Parse(Request.Cookies["idFormulario"].Value);

                foreach (GridViewRow linha in gridPerguntas.Rows)
                {
                    //pegar o checkbox contido em cada linha do grid..
                    CheckBox chkPergunta = (CheckBox)linha.FindControl("chkPergunta");

                    if (chkPergunta.Checked) //se o checkbox esta marcado..
                    {
                        //resgatar o id da conta armazenado no HiddenField
                        HiddenField txtIdPergunta = (HiddenField)linha.FindControl("IdPergunta");
                        int idPergunta = Int32.Parse(txtIdPergunta.Value);

                        FormulariosDAL fd = new FormulariosDAL();
                        fd.AdicionarPerguntas(idFormulario, idPergunta);                    
                    }
                }
                Response.Redirect("FormulariosDetalhes?id=" + idFormulario);
                lblMensagem.Text = "Perguntas associadas com sucesso!!";
                
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void gridPerguntas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPerguntas.PageIndex = e.NewPageIndex;

            PerguntasDAL pd = new PerguntasDAL();
            gridPerguntas.DataSource = pd.BuscarTodos();
            gridPerguntas.DataBind();

            
        }
    }
}