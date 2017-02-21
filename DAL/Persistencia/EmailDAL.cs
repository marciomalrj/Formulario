using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using Entidades;
using DAL.Persistencia;
using System.Net;
using System.Net.Mail;

namespace DAL.Persistencia
{
    public class EmailDAL
    {
        private readonly string conta = "mercantis@tanis.com.br";
        private readonly string senha = "email1970";
        private readonly string smtp  = "smtp.tanis.com.br";
        private readonly int porta = 587;

        public void Enviar(string destino, string link)
        {           
            //passo 1) criar a mensagem..
            MailMessage msg = new MailMessage(conta, destino); //DE->PARA

            msg.Subject = "Tanis Informática - Formulário de Perguntas";
            msg.Body = "Olá, conforme contato, segue o formulário com algumas perguntas para melhor nos conhecermos." + "\n" +
                       "Clique no Link abaixo para acessá-lo: \n" +
                        link;

            //passo 2) enviar a mensagem..
            SmtpClient s = new SmtpClient(smtp, porta);
            s.EnableSsl = false; //habilitar o uso de criptografia..
            s.Credentials = new NetworkCredential(conta, senha); //autenticação..
            s.Send(msg); //enviando a mensagem..
        }

        public string Criptografar(string texto)
        {
            try
            {
                string chaveCriptografia = "1970--TanisInformatica";
                byte[] chave = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                chave = System.Text.Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(texto);
                MemoryStream memoria = new MemoryStream();
                CryptoStream cs = new CryptoStream(memoria, des.CreateEncryptor(chave, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(memoria.ToArray());
            }
            catch (Exception ex)
            {
                
                throw new Exception("Erro ao gerar criptografia: " + ex.Message);
            }
 
        }

        public string Descriptografar(string texto)
        {
            try
            {
                texto = texto.Replace(" ", "+");
                string chaveDescriptografia = "1970--TanisInformatica";
                byte[] chave = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                byte[] inputByteArray = new byte[texto.Length];

                chave = System.Text.Encoding.UTF8.GetBytes(chaveDescriptografia.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(texto);
                MemoryStream memoria = new MemoryStream();
                CryptoStream cs = new CryptoStream(memoria, des.CreateDecryptor(chave, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(memoria.ToArray());
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

        }
    }
}
