using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexao
    {
        
        protected SqlConnection Con; //conexão com o banco..
        protected SqlCommand Cmd; //executar comandos sql no banco..
        protected SqlDataReader Dr; //ler os dados de consultas..
        protected SqlTransaction Tr; // Efetuar transações (commit / rollback)

        protected void AbrirConexao() //abrir conexão..
        {
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["formulario"].ConnectionString);
            Con.Open(); //conectado..
        }

        protected void FecharConexao() //fechar conexão..
        {
            Con.Close(); //desconectado..
        }
    }
}
