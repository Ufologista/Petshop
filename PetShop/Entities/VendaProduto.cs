﻿using PetShop.Entities.Exceptions;
using System;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.Data;

namespace PetShop.Entities
{
    public class VendaProduto
    {
        private static SqlCeConnection Connection;
        public int VendaId  { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public VendaProduto(int vendaId, int produtoId, int quantidade)
        {
            VendaId = vendaId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public void SalvarVendaProduto()
        {
            using (Connection = new SqlCeConnection(Properties.Settings.Default.PetShopDbConnectionString))
            {
                try
                {
                    Connection.Open();
                    SqlCeCommand command = Connection.CreateCommand();
                    command.CommandText = "INSERT INTO Vendas_Produtos (VendasId, ProdutosId, Quantidade) VALUES (@VendasId, @ProdutosId, @Quantidade)";
                    command.Parameters.AddWithValue("@VendasId", VendaId);
                    command.Parameters.AddWithValue("@ProdutosId", ProdutoId);
                    command.Parameters.AddWithValue("@Quantidade", Quantidade);
                    if (!(command.ExecuteNonQuery() > 0))
                    {
                        throw new SqlCeQueryException();
                    }
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE Produtos SET EstoqueAtual = EstoqueAtual - @Quantidade WHERE Id = @ProdutoId";
                    command.Parameters.AddWithValue("@Quantidade", Quantidade);
                    command.Parameters.AddWithValue("@ProdutoId", ProdutoId);
                    if (!(command.ExecuteNonQuery() > 0))
                    {
                        throw new SqlCeQueryException();
                    }
                }
                catch (SqlCeException e)
                {
                    MessageBox.Show($"Erro no banco de dados ao salvar venda de produto: {e.Message}", "Erro ao salvar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                    throw e;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Erro na aplicação ao salvar venda de produto: {e.Message}", "Erro ao salvar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                    throw e;
                }
            }
        }

        public static DataTable BuscarProdutosVenda(int vendaId)
        {
            DataTable produtosVenda = new DataTable();
            using (Connection = new SqlCeConnection(Properties.Settings.Default.PetShopDbConnectionString))
            {
                try
                {
                    Connection.Open();
                    SqlCeCommand command = Connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Vendas_Produtos WHERE VendasId = @VendasId";
                    command.Parameters.AddWithValue("@VendasId", vendaId);
                    command.ExecuteNonQuery();
                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command))
                    {
                        adapter.Fill(produtosVenda);
                    }
                }
                catch (SqlCeException e)
                {
                    MessageBox.Show($"Erro no banco de dados ao procurar produtos de venda: {e.Message}", "Erro ao buscar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Erro na aplicação ao buscar produtos de venda: {e.Message}", "Erro ao buscar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorLogger.CreateErrorLog(e);
                }
            }
            return produtosVenda;
        }
    }
}
