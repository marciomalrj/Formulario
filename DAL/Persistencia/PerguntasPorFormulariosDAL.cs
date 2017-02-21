using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;


namespace DAL.Persistencia
{
    public class PerguntasPorFormulariosDAL : Conexao
    {
        public List<Perguntas> ListaPerguntasVinculadas(int idFormulario)
        {
            try
            {
                List<Perguntas> perguntas = new List<Perguntas>();
                string sql = "select p.IdPergunta, p.Descricao, p.Tipo from Formulario.PerguntasPorFormularios ppf " +
                              "join Formulario.Formulario f on (ppf.IdFormulario = f.IdFormulario) " +
                              "join Formulario.Perguntas p on (ppf.IdPergunta = p.IdPergunta) " +
                              "where ppf.IdFormulario =" + idFormulario; //+ "and p.IdPergunta =" + idPergunta
                    AbrirConexao();
                Cmd = new SqlCommand(sql, Con);
                Dr = Cmd.ExecuteReader();

                while(Dr.Read())
                {
                    Perguntas p = new Perguntas();
                    p.IdPergunta = Int32.Parse(Dr["idPergunta"].ToString());
                    p.Descricao = Dr["Descricao"].ToString();
                    p.Tipo = Dr["Tipo"].ToString();
                    perguntas.Add(p);
                }
                return perguntas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar perguntas vinculadas: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(int idFormulario, int idPergunta)
        {
            try
            {
                AbrirConexao();
                Tr = Con.BeginTransaction();
                Cmd = new SqlCommand("DELETE FROM Formulario.PerguntasPorFormularios WHERE IdFormulario = " + idFormulario + " and IdPergunta =" + idPergunta, Con, Tr);
                Cmd.ExecuteNonQuery();
                Tr.Commit();
            }
            catch (Exception ex)
            {
                if (Tr != null)
                {
                    Tr.Rollback(); // Desfaz a transação..
                }
                throw new Exception("Não foi possível remover a pergunta: " + ex.Message);
            }
        }
    }
}
