using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Entidades;
using DAL.Persistencia;

namespace Web.Pages
{
    public partial class FormularioRespostas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    EmailDAL decrip = new EmailDAL();
                    FormulariosDAL fd = new FormulariosDAL();
                                       
                    int idForm = Int32.Parse(decrip.Descriptografar(Request.QueryString["form"]));
                    string empresa = decrip.Descriptografar(Request.QueryString["ep"]);
                    string email = decrip.Descriptografar(Request.QueryString["em"]);

                    if (fd.FormularioRespondido(idForm) == 1)
                    {
                        lblMensagem.Text = "<h1>Formulário já respondido!!</h1>";
                        btnEnviar.Visible = false;
                        return;
                    }
                    if (fd.ValidaLink(idForm, empresa, email))
                    {
                        lblMensagem.Text = "<h1>Não existe Formulários para este Link</h1>";
                        btnEnviar.Visible = false;
                        return;
                    }

                    Response.Cookies["idFormulario"].Value = idForm.ToString();
                    Response.Cookies["idFormulario"].Expires = DateTime.Now.AddHours(4);

                    fd.AtualizaUltimoAcesso(idForm);

                    List<Perguntas> perguntas = new List<Perguntas>();

                    PerguntasPorFormulariosDAL ppfd = new PerguntasPorFormulariosDAL();
                    perguntas = ppfd.ListaPerguntasVinculadas(idForm);

                    string campos = "";
                    int numPergunta = 1;

                    foreach (Perguntas pergunta in perguntas)
                    {

                        campos += "<h4>" + numPergunta + " - " + pergunta.Descricao + "</h4><br />";
                        campos += "<textarea name=\"resposta" + pergunta.IdPergunta + "\" class=\"contact textarea\" rows=\"5\" cols=\"100\" style=\"height: 70px; width: 800px;\" runat=\"server\"></textarea><br /><br />";

                        Response.Cookies["idPergunta"].Values[numPergunta.ToString()] = pergunta.IdPergunta.ToString();
                        numPergunta++;
                    }

                    Response.Cookies["idPergunta"].Expires = DateTime.Now.AddHours(4);

                    ltrConteudo.Text = campos;
                }
            }
            catch (Exception)
            {
                
                lblMensagem.Text = "<h1>Não foi possível acessar o formulário. </h1>";
                btnEnviar.Visible = false;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                int idFormulario = Int32.Parse(Request.Cookies["idFormulario"].Value);

                for (int i = 1; i <= Request.Cookies["idPergunta"].Values.Count; i++)
                {
                    Respostas r = new Respostas();
                    RespostasDAL rd = new RespostasDAL();

                    string resposta = "resposta" + Request.Cookies["idPergunta"].Values[i.ToString()].ToString();

                    if (Request.Form[resposta].Trim() == "")
                    {
                        throw new Exception("Nenhum campo pode ficar vazio!!");
                    }
                    else
                    {
                        r.Resposta = Request.Form[resposta];
                        r.IdFormulario = idFormulario;
                        r.IdPergunta = Int32.Parse(Request.Cookies["idPergunta"].Values[i.ToString()]);
                        r.DataResposta = DateTime.Now;

                        //string t = "";
                        rd.Inserir(r);
                    }
                }
               
                Response.Redirect("http://tanis.com.br");
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}