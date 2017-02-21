using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Formulario
    {
        public int IdFormulario { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public DateTime DataCriacao { get; set; }
        public string DataConclusao { get; set; }
        public string UltimoAcesso { get; set; }
        public string Acessado { get; set; }
        public string Email { get; set; }
        public bool Enviado { get; set; }

        public Formulario()
        {

        }
        public Formulario(string Nome, string Empresa, string Email)
        {
            this.Nome = Nome;
            this.Empresa = Empresa;
            this.Email = Email;
        }
    }
    
}
