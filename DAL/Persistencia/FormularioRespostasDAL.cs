using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;


namespace DAL.Persistencia
{
    class FormularioRespostasDAL : Conexao
    {
        public Perguntas BuscarPerguntasPorFormularios(int id)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select * from Formulario.Perguntas where IdPergunta = @v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();
                //executando e lendo os registros da consulta..

                Perguntas p = new Perguntas();
                while (Dr.Read())
                {
                    p.IdPergunta = (Int32)Dr["IdPergunta"];
                    p.Descricao = Dr["Descricao"].ToString();
                    p.Tipo = Dr["Tipo"].ToString();
                }
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar as pergunta: " + ex.Message);
            }

            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }
    }
}
