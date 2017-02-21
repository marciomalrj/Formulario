using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace DAL.Persistencia
{
    public class RespostasDAL : Conexao
    {
        public void Inserir(Respostas r)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Formulario.Respostas(IdPergunta, Resposta, DataResposta, IdFormulario) values(@v1, @v2, @v3, @v4)", Con);
                Cmd.Parameters.AddWithValue("@v1", r.IdPergunta);
                Cmd.Parameters.AddWithValue("@v2", r.Resposta);
                Cmd.Parameters.AddWithValue("@v3", r.DataResposta);
                Cmd.Parameters.AddWithValue("@v4", r.IdFormulario);
                Cmd.ExecuteNonQuery(); //executando a consulta..
                
                AtualizaDataRespostaFormulario(r.IdFormulario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir respostas: " + ex.Message);
            }
            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }
        public SqlDataReader BuscarPerguntasPorFormulario(int idForm)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select f.Nome, p.descricao, r.Resposta " +
                                        "from Formulario.Respostas r " +
                                        "join Formulario.Formulario f on (r.IdFormulario = f.IdFormulario) " +
                                        "join Formulario.Perguntas p on (r.IdPergunta = p.IdPergunta) " +
                                        "where r.IdFormulario = " + idForm + " order by p.descricao", Con);
                Dr = Cmd.ExecuteReader();
                return Dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as respostas: " + ex.Message);
            }
        }

        public void AtualizaDataRespostaFormulario(int idFormulario)
        {
            AbrirConexao();
            Cmd = new SqlCommand("update Formulario.Formulario set DataConclusao = @v1 where IdFormulario = " + idFormulario, Con);
            Cmd.Parameters.AddWithValue("@v1", DateTime.Now);
            Cmd.ExecuteNonQuery();
            FecharConexao();
        }
    }
}
