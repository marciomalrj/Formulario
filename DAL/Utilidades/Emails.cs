using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace DAL.Utilidades
{
    public class Emails
    {
        private readonly string conta = "marcio@tanis.com.br";
        private readonly string senha = "1213mm";
        private readonly string smtp = "smtp.tanis.com.br";
        private readonly int porta = 587;

        //método para enviar um email de confirmação para um cliente..
        public void Enviar(string nome, string destino, string titulo, string link)
        {

            //passo 1) criar a mensagem..
            MailMessage msg = new MailMessage(conta, destino); //DE->PARA

            msg.Subject = titulo;
            msg.Body = "Olá, conforme contato, segue o formulário com algumas perguntas para melhor nos conhecermos." + "\n" +
                       "Clique no Link abaixo para acessá-lo: \n" + 
                        link;

            //passo 2) enviar a mensagem..
            SmtpClient s = new SmtpClient(smtp, porta);
            s.EnableSsl = true; //habilitar o uso de criptografia..
            s.Credentials = new NetworkCredential(conta, senha); //autenticação..
            s.Send(msg); //enviando a mensagem..
        }
    }
}
