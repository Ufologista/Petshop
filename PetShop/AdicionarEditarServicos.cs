﻿using PetShop.Entities;
using PetShop.Entities.Enums;
using PetShop.Entities.Exceptions;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PetShop
{
    public partial class AdicionarEditarServicos : Form
    {
        private static TipoOperacao Operacao { get; set; }
        private Servico _Servico { get; set; }

        public AdicionarEditarServicos(TipoOperacao operacao)
        {
            InitializeComponent();
            Operacao = operacao;
        }

        public AdicionarEditarServicos(TipoOperacao operacao, int idServico) : this(operacao)
        {
            try
            {
                _Servico = new Servico(idServico);
            }
            catch (Exception ex)
            {
                ErrorLogger.CreateErrorLog(ex);
                Load += (s, e) => Close();
                return;
            }
        }

        private void AdicionarEditarServicos_Load(object sender, EventArgs e)
        {
            if (Operacao == TipoOperacao.Adicionar)
            {
                Text = "Adicionar Serviço";
                btnSalvar.Enabled = false;
            }
            else
            {
                Text = "Editar Serviço";
                txtNomeServico.Text = _Servico.NomeServico;
                txtValor.Text = _Servico.Valor.ToString("C2", CultureInfo.CurrentCulture);
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)

            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.IndexOf('.') < (sender as TextBox).SelectionStart && (sender as TextBox).Text.Split('.').Length > 1 && (sender as TextBox).Text.Split('.')[1].Length == 2)

            {
                e.Handled = true;
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                if (!Regex.IsMatch((sender as TextBox).Text, @"^[0-9]{,5}\.[0-9]{2}$"))
                {
                    (sender as TextBox).Text = Math.Round(double.Parse((sender as TextBox).Text), 2).ToString("C2", CultureInfo.CurrentCulture);
                }
            }
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Text = decimal.Parse((sender as TextBox).Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat).ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Operacao == TipoOperacao.Adicionar)
            {
                _Servico = new Servico(txtNomeServico.Text, decimal.Parse(txtValor.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat));
                _Servico.AdicionarEditarServico(Operacao);
            }
            else
            {
                _Servico.NomeServico = txtNomeServico.Text;
                _Servico.Valor = decimal.Parse(txtValor.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                _Servico.AdicionarEditarServico(Operacao);
            }

            if (Application.OpenForms.OfType<ListaProcedimentos>().Count() == 1)
            {
                Application.OpenForms.OfType<ListaProcedimentos>().First().AtualizarLista();
            }
            if (Application.OpenForms.OfType<PesquisarServicos>().Count() == 1)
            {
                Application.OpenForms.OfType<PesquisarServicos>().First().AtualizarLista();
            }
            Close();
        }

        private void txtNomeServico_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeServico.Text))
            {
                btnSalvar.Enabled = false;
            }
            else
            {
                btnSalvar.Enabled = true;
            }
        }
    }
}
