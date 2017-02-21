using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAL.Persistencia
{
    public class PerguntasDAL : Conexao
    {
        public void Inserir(Perguntas p)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Formulario.Perguntas(Descricao, Tipo) values(@v1, @v2)", Con);
                Cmd.Parameters.AddWithValue("@v1", p.Descricao);
                Cmd.Parameters.AddWithValue("@v2", p.Tipo);
                Cmd.ExecuteNonQuery(); //executando a consulta..
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir nova Pergunta: " + ex.Message);
            }
            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }
        public List<Perguntas> BuscarTodos()
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select * from Formulario.Perguntas", Con);
                Dr = Cmd.ExecuteReader();
                //executando e lendo os registros da consulta..
                List<Perguntas> lista = new List<Perguntas>();

                while (Dr.Read())
                {
                    Perguntas p = new Perguntas();

                    p.IdPergunta = (Int32)Dr["IdPergunta"];
                    p.Descricao = Dr["Descricao"].ToString();
                    p.Tipo = Dr["Tipo"].ToString();
                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as perguntas: " + ex.Message);
            }

            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }

        public List<Perguntas> BuscarTodos(int numPag)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select * from Formulario.Perguntas order by IdPergunta OFFSET ((" + numPag + "- 1) * 10) ROWS FETCH NEXT 10 ROWS ONLY", Con);
                Dr = Cmd.ExecuteReader();
                //executando e lendo os registros da consulta..
                List<Perguntas> lista = new List<Perguntas>();

                while (Dr.Read())
                {
                    Perguntas p = new Perguntas();

                    p.IdPergunta = (Int32)Dr["IdPergunta"];
                    p.Descricao = Dr["Descricao"].ToString();
                    p.Tipo = Dr["Tipo"].ToString();
                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as perguntas: " + ex.Message);
            }

            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }

        public Perguntas BuscaPorId(int id)
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
        public void Excluir(int id)
        {
            try
            {
                AbrirConexao();
                Tr = Con.BeginTransaction();
                Cmd = new SqlCommand("DELETE FROM Formulario.Perguntas WHERE IdPergunta = @v1", Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.ExecuteNonQuery();
                Tr.Commit();
            }
            catch (Exception)
            {
                if (Tr != null)
                {
                    Tr.Rollback(); // Desfaz a transação..
                }
                throw new Exception("Erro: Pergunta pertence a algum formulário!");
            }
        }
        public void Atualizar(Perguntas p)
        {
            try
            {
                AbrirConexao();
                Tr = Con.BeginTransaction();
                Cmd = new SqlCommand("UPDATE Formulario.Perguntas SET descricao = @v2, tipo = @v3 WHERE IdPergunta = @v1", Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", p.IdPergunta);
                Cmd.Parameters.AddWithValue("@v2", p.Descricao);
                Cmd.Parameters.AddWithValue("@v3", p.Tipo);
                Cmd.ExecuteNonQuery();
                Tr.Commit();
            }
            catch (Exception ex)
            {
                if (Tr != null)
                {
                    Tr.Rollback(); // Desfaz a transação..
                }
                throw new Exception("Não foi possível atualizar a pergunta: " + ex.Message);
            }
            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }
        public List<Perguntas> BuscarTipos()
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select distinct Tipo from Formulario.Perguntas", Con);
                Dr = Cmd.ExecuteReader();
                //executando e lendo os registros da consulta..
                List<Perguntas> lista = new List<Perguntas>();

                while (Dr.Read())
                {
                    Perguntas p = new Perguntas();

                    p.IdPergunta = (Int32)Dr["IdPergunta"];
                    p.Descricao = Dr["Descricao"].ToString();
                    p.Tipo = Dr["Tipo"].ToString();
                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as perguntas: " + ex.Message);
            }

            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }
    }
}
