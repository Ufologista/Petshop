﻿using PetShop.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop.Entities
{
    class Fornecedor
    {
        private static SqlCeConnection connection = new SqlCeConnection(Properties.Settings.Default.PetShopDbConnectionString);
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Tipo_Fornecimento { get; set; }
        public string Apelido { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Observacoes { get; set; }

        public Fornecedor(string nome, string tipo_Fornecimento, string apelido, string endereco, string bairro, string cidade, string estado, string cep, string telefone, string celular, string cnpj, string cpf, string email, string observacoes)
        {
            Nome = nome;
            Tipo_Fornecimento = tipo_Fornecimento;
            Apelido = apelido;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Telefone = telefone;
            Celular = celular;
            Cnpj = cnpj;
            Cpf = cpf;
            Email = email;
            Observacoes = observacoes;
        }

        public Fornecedor(int idFornecedor)
        {
            BuscarFornecedor(idFornecedor);
        }

        public static DataTable ListarFornecedores()
        {
            DataTable dta = new DataTable();
            try
            {
                connection.Open();
                SqlCeCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT * FROM Fornecedor";
                comando.ExecuteNonQuery();
                SqlCeDataAdapter dataadp = new SqlCeDataAdapter(comando);
                dataadp.Fill(dta);
                dta.Columns["Tipo_Fornecimento"].ColumnName = "Tipo de Fornecimento";
                dta.Columns["Endereco"].ColumnName = "Endereço";
                dta.Columns["Cep"].ColumnName.ToUpper();
                dta.Columns["Observacoes"].ColumnName = "Observações";
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show("Erro ao exibir os dados na lista: " + ex.Message, "Erro de exibição da lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return dta;
        }

        private void BuscarFornecedor(int idFornecedor)
        {
            try
            {
                connection.Open();

                SqlCeCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Fornecedor WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", idFornecedor);
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IdFornecedor = (int)reader["Id"];
                        Nome = reader["Nome"].ToString();
                        Tipo_Fornecimento = reader["Tipo_Fornecimento"].ToString();
                        Apelido = reader["Apelido"].ToString();
                        Endereco = reader["Endereco"].ToString();
                        Bairro = reader["Bairro"].ToString();
                        Cidade = reader["Cidade"].ToString();
                        Estado = reader["Estado"].ToString();
                        Cep = reader["Cep"].ToString();
                        Telefone = reader["Telefone"].ToString();
                        Celular = reader["Celular"].ToString();
                        Cnpj = reader["Cnpj"].ToString();
                        Cpf = reader["Cpf"].ToString();
                        Email = reader["Email"].ToString();
                        Observacoes = reader["Observacoes"].ToString();
                    }
                }
            }
            catch (SqlCeException e)
            {
                MessageBox.Show("Falha ao localizar fornecedor: " + e.Message, "Não foi possível localizar o fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AdicionarEditarFornecedor(TipoOperacao operacao)
        {
            try
            {
                connection.Open();
                SqlCeCommand command = connection.CreateCommand();
                if (operacao == TipoOperacao.Adicionar)
                {
                    command.CommandText = "INSERT INTO Fornecedor (Nome, Tipo_Fornecimento, Apelido, Endereco, Bairro, Cidade, Estado, Cep, Telefone, Celular, Cnpj, Cpf, Email, Observacoes) VALUES (@Nome, @Tipo_Fornecimento, @Apelido, @Endereco, @Bairro, @Cidade, @Estado, @Cep, @Telefone, @Celular, @Cnpj, @Cpf, @Email, @Observacoes)";
                }
                else
                {
                    command.CommandText = "UPDATE Fornecedor SET Nome = @Nome, Tipo_Fornecimento = @Tipo_Fornecimento, Apelido = @Apelido, Endereco = @Endereco, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, Cep = @Cep, Telefone = @Telefone, Celular = @Celular, Cnpj = @Cnpj, Cpf = @Cpf, Email = @Email, Observacoes = @Observacoes WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", IdFornecedor);
                }

                command.Parameters.AddWithValue("@Nome", Nome);
                command.Parameters.AddWithValue("@Tipo_Fornecimento", Tipo_Fornecimento);
                command.Parameters.AddWithValue("@Apelido", Apelido);
                command.Parameters.AddWithValue("@Endereco", Endereco);
                command.Parameters.AddWithValue("@Bairro", Bairro);
                command.Parameters.AddWithValue("@Cidade", Cidade);
                command.Parameters.AddWithValue("@Estado", Estado);
                command.Parameters.AddWithValue("@Cep", Cep);
                command.Parameters.AddWithValue("@Telefone", Telefone);
                command.Parameters.AddWithValue("@Celular", Celular);
                command.Parameters.AddWithValue("@Cnpj", Cnpj);
                command.Parameters.AddWithValue("@Cpf", Cpf);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Observacoes", Observacoes);

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Os dados do fornecedor foram salvos.", "Cadastro de fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar as informações do fornecedor: " + ex.Message, "Falha no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void ExcluirFornecedor(int idFornecedor)
        {
            try
            {
                connection.Open();
                SqlCeCommand comando = connection.CreateCommand();
                comando.CommandText = "DELETE FROM Fornecedor WHERE Id = @Id";
                comando.Parameters.AddWithValue("@Id", idFornecedor);
                comando.ExecuteNonQuery();
                MessageBox.Show("Fornecedor removido", "Remover fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover fornecedor: " + ex.Message, "Remover fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}


    

