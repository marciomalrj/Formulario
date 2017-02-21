using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Persistencia;


namespace Web.Pages
{
    public partial class PerguntasListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PerguntasDAL pd = new PerguntasDAL();
                    gridPerguntas.DataSource = pd.BuscarTodos();
                    gridPerguntas.DataBind();

//                    DropDownList dl = new DropDownList();
//                    dl.Attributes.Add("Testando", "Testando");                  
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerguntasCadastro.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //sender -> sempre é o elemento que chamou o evento.. (Button)
                Button btnExcluir = (Button)sender;
                //resgatar o id enviado pelo CommandArgumment
                int id = Int32.Parse(btnExcluir.CommandArgument);

                PerguntasDAL pd = new PerguntasDAL();
                pd.Excluir(id);

                Response.Redirect("PerguntasListar.aspx");
                lblMensagem.Text = "Pergunta excluida com sucesso!";

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        /*
        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }
         
        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Page.RegisterStartupScript("POST", "alert('Eu sou um alert!');");
 
        }
        */
        protected void gridPerguntas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Seleciona qual a página a ser exibida
            gridPerguntas.PageIndex = e.NewPageIndex;

            //Faz a busca
            PerguntasDAL pd = new PerguntasDAL();
            gridPerguntas.DataSource = pd.BuscarTodos();
            gridPerguntas.DataBind();
        }
    }
}