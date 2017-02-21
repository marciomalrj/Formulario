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
    public partial class FormulariosCadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Formulario f = new Formulario();
                f.Nome = txtNome.Text;
                f.Empresa = txtEmpresa.Text;
                f.DataCriacao = DateTime.Now;
                f.DataConclusao = "NULL";
                f.UltimoAcesso = "NULL";
                f.Acessado = "NAO";
                f.Email = txtEmail.Text;
                f.Enviado = false;

                FormulariosDAL fd = new FormulariosDAL();
                fd.Inserir(f);

                txtNome.Text = string.Empty;
                txtEmpresa.Text = string.Empty;
                lblMensagem.Text = "Formulário cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao inserir formulário: " + ex.Message;
            }
        }
    }
}