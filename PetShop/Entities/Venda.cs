﻿using PetShop.Entities.Exceptions;
using System;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PetShop.Entities
{
    public class Venda
    {
        private static SqlCeConnection Connection;
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public int? ClienteId { get; set; }
        public string Pagamento { get; set; }
        public decimal Desconto { get; set; }
        public string TipoCartao { get; set; }

        public Venda(DateTime dataVenda, int? clienteId, string pagamento, decimal desconto, string tipoCartao)
        {
            DataVenda = dataVenda;
            ClienteId = clienteId;
            Pagamento = pagamento;
            Desconto = desconto;
            TipoCartao = tipoCartao;
        }
        
        public Venda(int id)
        {
            BuscarVenda(id);
        }

        private void BuscarVenda(int id)
        {
            using (Connection = new SqlCeConnection(Properties.Settings.Default.PetShopDbConnectionString))
            {
                try
                {
                    Connection.Open();
                    SqlCeCommand command = Connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Vendas WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlCeDataReader reader = command.ExecuteResultSet(ResultSetOptions.Scrollable))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Id = (int)reader["Id"];
                                DataVenda = (DateTime)reader["DataVenda"];
                                ClienteId = (int)reader["ClienteId"];
                                Pagamento = (string)reader["Pagamento"];
                                Desconto = (decimal)reader["Desconto"];
                                TipoCartao = (string)reader["TipoCartao"];
                            }
                        }
                        else
                        {
                            throw new SqlCeResultException();
                        }
                    }
                }
                catch (SqlCeResultException e)
                {
                    MessageBox.Show($"Erro no banco de dados ao buscar por Venda: {e.Message}", "Falha nos dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e;
                }
                catch (SqlCeException e)
                {
                    MessageBox.Show($"Erro no banco de dados ao buscar por Venda: {e.Message}", "Falha nos dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Falha na aplicação ao buscar por Venda: {e.Message}", "Erro no programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e;
                }
            }
        }

        public void AdicionarVenda()
        {
            using (Connection = new SqlCeConnection(Properties.Settings.Default.PetShopDbConnectionString))
            {
                try
                {
                    Connection.Open();
                    SqlCeCommand command = Connection.CreateCommand();
                    command.CommandText = "INSERT INTO Vendas (DataVenda, ClienteId, Pagamento, Desconto, TipoCartao) VALUES (@DataVenda, @ClienteId, @Pagamento, @Desconto, @TipoCartao)";
                    command.Parameters.AddWithValue("@DataVenda", DataVenda);
                    if (ClienteId != null)
                    {
                        command.Parameters.AddWithValue("@ClienteId", ClienteId);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ClienteId", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@Pagamento", Pagamento);
                    command.Parameters.AddWithValue("@Desconto", Desconto);
                    command.Parameters.AddWithValue("@TipoCartao", TipoCartao);
                    if (!(command.ExecuteNonQuery() > 0))
                    {
                        throw new SqlCeQueryException();
                    }
                    command.CommandText = "SELECT @@IDENTITY";
                    Id = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (SqlCeException e)
                {
                    MessageBox.Show($"Erro no banco de dados: {e.Message}", "Erro ao salvar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Ocorreu um erro na aplicação: {e.Message}", "Erro na aplicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                    throw e;
                }
            }
        }

        public static int? SelecionarProximoIdVenda()
        {
            int? ProximoId = null;
            using (Connection = new SqlCeConnection(Properties.Settings.Default.PetShopDbConnectionString))
            {
                try
                {
                    Connection.Open();
                    SqlCeCommand command = Connection.CreateCommand();
                    command.CommandText = "SELECT IDENT_CURRENT('Vendas') as Id";
                    ProximoId = (int)command.ExecuteScalar();
                }
                catch (SqlCeException e)
                {
                    MessageBox.Show($"Erro no banco de dados ao selecionar próximo número de venda: {e.Message}", "Erro ao retornar numero da venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Erro na aplicação ao selecionar próximo número de venda: {e.Message}", "Erro ao retornar numero da venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                }
            }
            if (ProximoId != null)
            {
                return ProximoId + 1;
            }
            else
            {
                return null;
            }
        }
    }
}
