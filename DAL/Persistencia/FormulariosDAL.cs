using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;


namespace DAL.Persistencia
{
    public class FormulariosDAL : Conexao
    {
        public void Inserir(Formulario f)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Formulario.Formulario(Nome, Empresa, DataCriacao, DataConclusao, UltimoAcesso, Acessado, Email, Enviado) values(@v1, @v2, @v3, NULL, NULL, @v6, @v7, @v8)", Con);
                Cmd.Parameters.AddWithValue("@v1", f.Nome);
                Cmd.Parameters.AddWithValue("@v2", f.Empresa);
                Cmd.Parameters.AddWithValue("@v3", f.DataCriacao);
                //Cmd.Parameters.AddWithValue("@v4", f.DataConclusao);
                // Cmd.Parameters.AddWithValue("@v5", f.UltimoAcesso);
                Cmd.Parameters.AddWithValue("@v6", f.Acessado);
                Cmd.Parameters.AddWithValue("@v7", f.Email);
                Cmd.Parameters.AddWithValue("@v8", f.Enviado);

                Cmd.ExecuteNonQuery(); //executando a consulta..
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir novo formulário: " + ex.Message);
            }
            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }

        public List<Formulario> BuscarTodos()
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select * from Formulario.formulario", Con);
                Dr = Cmd.ExecuteReader();
                //executando e lendo os registros da consulta..
                List<Formulario> lista = new List<Formulario>();

                while (Dr.Read())
                {
                    Formulario f = new Formulario();

                    f.IdFormulario = (Int32)Dr["IdFormulario"];
                    f.Nome = Dr["Nome"].ToString();
                    f.Empresa = Dr["Empresa"].ToString();
                    f.DataCriacao = DateTime.Parse(Dr["DataCriacao"].ToString());
                    f.DataConclusao = Dr["DataConclusao"].ToString();
                    f.UltimoAcesso = Dr["UltimoAcesso"].ToString();
                    f.Acessado = Dr["Acessado"].ToString();
                    f.Email = Dr["Email"].ToString();
                    f.Enviado = (bool)Dr["Enviado"];
                    lista.Add(f);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Formulario.Formulários: " + ex.Message);
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
                Cmd = new SqlCommand("DELETE FROM Formulario.PerguntasPorFormularios WHERE IdFormulario = @v1", Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.ExecuteNonQuery();


                Cmd = new SqlCommand("DELETE FROM Formulario.Formulario WHERE IdFormulario = @v1", Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.ExecuteNonQuery();
                Tr.Commit();
            }
            catch (Exception ex)
            {
                if (Tr != null)
                {
                    Tr.Rollback(); // Desfaz a transação..
                }
                throw new Exception("Não foi possível remover o formulário: " + ex.Message);
            }
        }

        public Formulario BuscaPorId(int id)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select * from Formulario.Formulario where IdFormulario = @v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();
                //executando e lendo os registros da consulta..

                Formulario f = new Formulario();
                while (Dr.Read())
                {
                    f.IdFormulario = (Int32)Dr["IdFormulario"];
                    f.Nome = Dr["Nome"].ToString();
                    f.Empresa = Dr["Empresa"].ToString();
                    f.DataCriacao = DateTime.Parse(Dr["DataCriacao"].ToString());
                    f.DataConclusao = Dr["DataConclusao"].ToString();
                    f.UltimoAcesso = Dr["UltimoAcesso"].ToString();
                    f.Acessado = Dr["Acessado"].ToString();
                    f.Email = Dr["Email"].ToString();
                    f.Enviado = (bool)Dr["Enviado"];
                }
                return f;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Formulário: " + ex.Message);
            }

            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }
        public void Atualizar(Formulario f)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Tr = Con.BeginTransaction();
                Cmd = new SqlCommand("UPDATE Formulario.formulario SET Nome = @v2, Empresa = @v3, Email = @v4 where IdFormulario = @v1", Con, Tr);
                Cmd.Parameters.AddWithValue("@v1", f.IdFormulario);
                Cmd.Parameters.AddWithValue("@v2", f.Nome);
                Cmd.Parameters.AddWithValue("@v3", f.Empresa);
                //Cmd.Parameters.AddWithValue("@v4", f.DataCriacao);
                //Cmd.Parameters.AddWithValue("@v5", f.DataConclusao);
                //Cmd.Parameters.AddWithValue("@v6", f.UltimoAcesso);
                //Cmd.Parameters.AddWithValue("@v7", f.Acessado);
                Cmd.Parameters.AddWithValue("@v4", f.Email);
                Cmd.ExecuteNonQuery();
                Tr.Commit();

            }
            catch (Exception ex)
            {
                if (Tr != null)
                {
                    Tr.Rollback(); // Desfaz a transação..
                }
                throw new Exception("Não foi possível atualizar o Formulário: " + ex.Message);
            }

            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }

        public void AdicionarPerguntas(int idFormulario, int idPergunta)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("insert into Formulario.PerguntasPorFormularios values(@v1, @v2)", Con);
                Cmd.Parameters.AddWithValue("@v1", idFormulario);
                Cmd.Parameters.AddWithValue("@v2", idPergunta);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao vincular perguntas: Pergunta já cadastrada!");
            }
            finally
            {
                FecharConexao();
            }
        }
        public int ExistePergunta(int idFormulario, int idPergunta)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select count(*) as total from Formulario.PerguntasPorFormularios where idFormulario = @v1 and IdPergunta = @v2", Con);
                Cmd.Parameters.AddWithValue("@v1", idFormulario);
                Cmd.Parameters.AddWithValue("@v2", idPergunta);
                Dr = Cmd.ExecuteReader();

                int achou = Int32.Parse(Dr["total"].ToString());

                return achou;
            }
            catch (Exception ex)
            {
                FecharConexao();
                throw new Exception(ex.Message);
            }
        }
        public void AtualizaUltimoAcesso(int id)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Tr = Con.BeginTransaction();
                Cmd = new SqlCommand("UPDATE Formulario.formulario SET UltimoAcesso = '" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "' where IdFormulario = " + id, Con, Tr);
                string t = "UPDATE Formulario.formulario SET UltimoAcesso = '" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "' where IdFormulario = " + id;
                Cmd.ExecuteNonQuery();

                Cmd = new SqlCommand("UPDATE Formulario.Formulario SET Acessado = 'SIM' where IdFormulario = " + id, Con, Tr);
                Cmd.ExecuteNonQuery();

                Tr.Commit();
            }
            catch (Exception ex)
            {
                if (Tr != null)
                {
                    Tr.Rollback(); // Desfaz a transação..
                }
                throw new Exception("Não foi possível atualizar o Formulário: " + ex.Message);
            }

            finally
            {
                FecharConexao(); //fechar conexão..
            }
        }
        public bool ValidaLink(int id, string empresa, string email)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select count(1) as valida from Formulario.Formulario where IdFormulario = @v1, Empresa = @v2, Email = @v3", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Cmd.Parameters.AddWithValue("@v2", empresa);
                Cmd.Parameters.AddWithValue("@v3", email);
                Dr = Cmd.ExecuteReader();

                if (Int32.Parse(Dr["valida"].ToString()) == 1 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int FormularioRespondido(int id)
        {
            try
            {
                AbrirConexao(); //abrir conexão..
                Cmd = new SqlCommand("select DataConclusao from Formulario.Formulario where IdFormulario = @v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();

                if (String.IsNullOrEmpty(Dr["DataConclusao"].ToString()))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

