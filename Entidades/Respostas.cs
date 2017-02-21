using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Respostas
    {
        public int IdResposta { get; set; }
        public string Resposta { get; set; }
        public int IdFormulario { get; set; }
        public int IdPergunta { get; set; }
        public DateTime DataResposta { get; set; }
    }
}
