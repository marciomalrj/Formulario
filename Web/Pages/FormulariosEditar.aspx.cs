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
    public partial class FormulariosEditar : System.Web.UI.Page
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Formulario f = new Formulario();
                f.IdFormulario = Int32.Parse(Request.QueryString["id"].ToString());
                f.Nome = txtNome.Text;
                f.Empresa = txtEmpresa.Text;
                f.Email = txtEmail.Text;

                FormulariosDAL fd = new FormulariosDAL();
                fd.Atualizar(f);

                lblMensagem.Text = "Formulário atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                
                lblMensagem.Text = ex.Message;
            }
        }
    }
}