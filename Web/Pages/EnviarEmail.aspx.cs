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
    public partial class EnviarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["id"].ToString()))
                {
                    lblMensagem.Text = "Não foi Possível achar o formulário.";
                    return;
                }

                int idForm = Int32.Parse(Request.QueryString["id"].ToString());
                Formulario f = new Formulario();
                FormulariosDAL fd = new FormulariosDAL();

                f = fd.BuscaPorId(idForm);

                txtNome.Text = f.Nome;
                txtEmpresa.Text = f.Empresa;
                txtEmail.Text = f.Email;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string link = "http://localhost:55682/Pages/FormularioRespostas?form=";
                EmailDAL email = new EmailDAL();

                link += email.Criptografar(Request.QueryString["id"].ToString()) + "&";
                link += "ep=" + email.Criptografar(txtEmpresa.Text) + "&";
                link += "em=" + email.Criptografar(txtEmail.Text);

                email.Enviar(txtEmail.Text, link);

                lblMensagem.Text = "Email enviado com sucesso para a empresa " + txtEmpresa.Text ;                
            }
            catch (Exception ex)
            {
                
                lblMensagem.Text = ex.Message;
            }
 
        }
    }
}