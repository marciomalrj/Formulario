using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using DAL.Persistencia;
using System.Data.SqlClient;

namespace Web.Pages
{
    public partial class RespostaslistarPorFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["form"]))
                {
                    lblMensagem.Text = "Não foi Possível achar as perguntas do formulário.";
                    return;
                }

                RespostasDAL rd = new RespostasDAL();
                SqlDataReader form = rd.BuscarPerguntasPorFormulario(Int32.Parse(Request.QueryString["form"].ToString()));
                string conteudo = "";
                int count = 0;

                if (form.HasRows)
                {
                    while (form.Read())
                    {
                        count++;
                        conteudo += "<spam style=\"color: #8b020f\" >" + count + ". " + form["Descricao"].ToString() + "</spam> <br>" + form["Resposta"].ToString() + "<br><br>";
                    }
                }
                else
                {
                    lblMensagem.Text = "Nenhuma resposta para o formulário.";
                    return;
                }

                ltrConteudo.Text = conteudo;
            }

        }
    }
}