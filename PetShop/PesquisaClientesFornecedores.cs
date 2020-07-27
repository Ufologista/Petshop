﻿using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Windows.Forms;
using PetShop.Entities;
using PetShop.Entities.Enums;

namespace PetShop
{

    public partial class PesquisaClientesFornecedores : Form
    {
        private readonly TipoPesquisa _TipoPesquisa;
        public PesquisaClientesFornecedores(TipoPesquisa tipoPesquisa)
        {
            InitializeComponent();
            _TipoPesquisa = tipoPesquisa;
        }

        public void AtualizarLista()
        {
            if (_TipoPesquisa == TipoPesquisa.Cliente)
            {
                dataGridViewListaClientesFornecedores.DataSource = Cliente.ListarClientes();
            }
            else
            {
                dataGridViewListaClientesFornecedores.DataSource = Fornecedor.ListarFornecedores();
            }
        }

        public void BuscarLista()
        {
            (dataGridViewListaClientesFornecedores.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nome LIKE '%" + textBoxPesquisarPeloNome.Text + "%'");
        }

        private void btnAdicionarClienteFornecedor_Click(object sender, EventArgs e)
        {
            if (_TipoPesquisa == TipoPesquisa.Cliente)
            {
                AdicionarEditarCliente AdicionarCliente = new AdicionarEditarCliente(TipoOperacao.Adicionar, this);
                AdicionarCliente.ShowDialog();
            }
            else
            {
                AdicionarEditarFornecedor AdicionarFornecedor = new AdicionarEditarFornecedor(TipoOperacao.Adicionar, this);
                AdicionarFornecedor.ShowDialog();
            }
        }
        private void btnExcluirClienteFornecedor_Click(object sender, EventArgs e)
        {

            if (dataGridViewListaClientesFornecedores.SelectedRows.Count != 0)
            {
                if (_TipoPesquisa == TipoPesquisa.Cliente)
                {
                    DialogResult confirmar_delete = MessageBox.Show("Tem certeza que deseja remover este cliente?", "Remover Cliente", MessageBoxButtons.YesNo);
                    if (confirmar_delete == DialogResult.Yes)
                    {
                        Cliente.ExcluirCliente((int)dataGridViewListaClientesFornecedores.SelectedRows[0].Cells[0].Value);
                        AtualizarLista();
                    }
                }
                else
                {
                    DialogResult confirmar_delete = MessageBox.Show("Tem certeza que deseja remover este Fornecedor?", "Remover Fornecedor", MessageBoxButtons.YesNo);
                    if (confirmar_delete == DialogResult.Yes)
                    {
                        Fornecedor.ExcluirFornecedor((int)dataGridViewListaClientesFornecedores.SelectedRows[0].Cells[0].Value);
                        AtualizarLista();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um item para ser removido.", "Item não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEditarClienteFornecedor_Click(object sender, EventArgs e)
        {
            if (dataGridViewListaClientesFornecedores.SelectedRows.Count != 0)
            {
                if (_TipoPesquisa == TipoPesquisa.Cliente)
                {
                    AdicionarEditarCliente EditarCliente = new AdicionarEditarCliente(TipoOperacao.Editar, this, (int)dataGridViewListaClientesFornecedores.SelectedRows[0].Cells[0].Value);
                    EditarCliente.ShowDialog();
                }
                else
                {
                    AdicionarEditarFornecedor EditarFornecedor = new AdicionarEditarFornecedor(TipoOperacao.Editar, this, (int)dataGridViewListaClientesFornecedores.SelectedRows[0].Cells[0].Value);
                    EditarFornecedor.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Selecione um item para ser editado.", "Item não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PesquisaClientesFornecedores_Load(object sender, EventArgs e)
        {
            if (_TipoPesquisa == TipoPesquisa.Cliente)
            {
                Text = "Pesquisa de Clientes";
                Icon = Properties.Resources.usuarios_icon;
                dataGridViewListaClientesFornecedores.DataSource = Cliente.ListarClientes();
            }
            else
            {
                Text = "Pesquisa de Fornecedores";
                Icon = Properties.Resources.fornecedor_icon;
                dataGridViewListaClientesFornecedores.DataSource = Fornecedor.ListarFornecedores();
            }
        }

        private void BtnPesquisarNomeClienteFornecedor_Click(object sender, EventArgs e)
        {
            BuscarLista();
        }

        private void DataGridViewListaClientesFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewListaClientesFornecedores.SelectedRows.Count != 0)
            {
                if (_TipoPesquisa == TipoPesquisa.Cliente)
                {
                    AdicionarEditarCliente EditarCliente = new AdicionarEditarCliente(TipoOperacao.Editar, this, (int)dataGridViewListaClientesFornecedores.SelectedRows[0].Cells[0].Value);
                    EditarCliente.ShowDialog();
                }
                else
                {
                    AdicionarEditarFornecedor EditarFornecedor = new AdicionarEditarFornecedor(TipoOperacao.Editar, this, (int)dataGridViewListaClientesFornecedores.SelectedRows[0].Cells[0].Value);
                    EditarFornecedor.ShowDialog();
                }
            }
        }

        private void textBoxPesquisarPeloNome_TextChanged(object sender, EventArgs e)
        {
            BuscarLista();
        }
    }
}