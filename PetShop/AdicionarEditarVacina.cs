﻿using PetShop.Entities;
using PetShop.Entities.Enums;
using PetShop.Entities.Exceptions;
using PetShop.ToolBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PetShop
{
    public partial class AdicionarEditarVacina : Form
    {
        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);
        private readonly TipoOperacao Operacao;
        private Vacina _Vacina { get; set; }
        private Dictionary<Control, string> CamposObrigatorios;
        private int EstoqueAtual;
        private int EstoqueAnterior;
        private Button BtnLockEstoque;

        public AdicionarEditarVacina(TipoOperacao operacao)
        {
            InitializeComponent();
            Operacao = operacao;
        }

        public AdicionarEditarVacina(TipoOperacao operacao, int idVacina) : this(operacao)
        {
            try
            {
                _Vacina = new Vacina(idVacina);
            }
            catch (Exception ex)
            {
                ErrorLogger.CreateErrorLog(ex);
                Load += (s, e) => Close();
                return;
            }
        }

        private void AdicionarEditarVacina_Load(object sender, EventArgs e)
        {
            CamposObrigatorios = new Dictionary<Control, string>()
            {
                { CombBoxImunologia, "Selecione o tipo de Imunologia" },
                { txtConteudoML, "Digite o conteúdo da vacina" },
                { txtDoses, "Digite a quantidade de doses da vacina"} ,
                { txtFabricante, "Digite o nome do fabricante" },
                { txtQuantidadeEstoque, "Insira a quantidade atual no estoque" },
                { txtValorProduto, "Insira o valor de venda da Vacina" }
            };
            CombBoxImunologia.DataSource = Vacina.ListarImunologia();
            CombBoxImunologia.DisplayMember = "Imunologia";
            txtDataModificacao.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            if (Operacao == TipoOperacao.Adicionar)
            {
                Text = "Adicionar vacina";
                CombBoxImunologia.SelectedIndex = -1;
                toolTip.SetToolTip(btnSalvar, "Preencha todos os campos obrigatórios");
            }
            else
            {

                Text = "Editar vacina";
                CombBoxImunologia.Text = _Vacina.Imunologia;
                txtConteudoML.Text = _Vacina.ConteudoML.ToString();
                txtDoses.Text = _Vacina.Doses.ToString();
                txtLote.Text = _Vacina.Lote;
                txtFabricante.Text = _Vacina.Fabricante;
                DateDataValidade.Value = _Vacina.DataValidade;
                txtQuantidadeEstoque.Text = _Vacina.Quantidade.ToString();
                txtValorCusto.Text = _Vacina.ValorMercado.ToString("C2", CultureInfo.CurrentCulture);
                txtValorProduto.Text = _Vacina.ValorProduto.ToString("C2", CultureInfo.CurrentCulture);
                BtnLockEstoque = new Button();
                BtnLockEstoque.Size = new Size(25, txtQuantidadeEstoque.Height);
                BtnLockEstoque.Dock = DockStyle.Right;
                BtnLockEstoque.Cursor = Cursors.Default;
                BtnLockEstoque.Image = Properties.Resources.lock16x16;
                BtnLockEstoque.ImageAlign = ContentAlignment.MiddleCenter;
                BtnLockEstoque.FlatStyle = FlatStyle.Flat;
                BtnLockEstoque.ForeColor = Color.White;
                BtnLockEstoque.BackColor = Color.Transparent;
                BtnLockEstoque.FlatAppearance.BorderSize = 0;
                txtQuantidadeEstoque.Controls.Add(BtnLockEstoque);
                txtQuantidadeEstoque.BackColor = Color.FromKnownColor(KnownColor.Window);
                BtnLockEstoque.Click += new EventHandler(BtnLockEstoque_Click);
                EstoqueAnterior = int.TryParse(txtQuantidadeEstoque.Text, out int estoqueAnteriorResult) ? estoqueAnteriorResult : default;
                EstoqueAtual = int.TryParse(txtQuantidadeEstoque.Text, out int estoqueAtualResult) ? estoqueAtualResult : default;
                txtQuantidadeEstoque.ReadOnly = true;
            }
        }

        private void BtnLockEstoque_Click(object sender, EventArgs e)
        {
            if (txtQuantidadeEstoque.ReadOnly)
            {
                txtQuantidadeEstoque.ReadOnly = false;
                BtnLockEstoque.Image = Properties.Resources.unlock16x16;
                BtnLockEstoque.GotFocus -= new EventHandler(txtEstoqueAtual_GotFocus);
            }
            else
            {
                txtQuantidadeEstoque.ReadOnly = true;
                BtnLockEstoque.Image = Properties.Resources.lock16x16;
                txtQuantidadeEstoque.GotFocus += new EventHandler(txtEstoqueAtual_GotFocus);
            }
        }

        private void txtEstoqueAtual_GotFocus(object sender, EventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtConteudoML_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDoses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantidadeEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AdicionarEditarVacina_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = PesquisaControlePosicaoMouse.EncontrarControleNoCursor(this);
            if (control != null && !control.Enabled)
            {
                if (!toolTip.Active)
                {
                    toolTip.Active = true;
                    toolTip.Show(toolTip.GetToolTip(control), control, control.Width / 2, control.Height / 2);
                }
            }
            else
            {
                if (toolTip.Active)
                {
                    toolTip.Active = false;
                }
            }
        }

        private void CombBoxImunologia_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void txtConteudoML_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void txtDoses_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void txtLote_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void txtFabricante_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void txtQuantidadeEstoque_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Operacao == TipoOperacao.Adicionar)
            {
                _Vacina = new Vacina(CombBoxImunologia.Text, int.Parse(txtDoses.Text), int.Parse(txtConteudoML.Text), txtLote.Text, txtFabricante.Text, DateDataValidade.Value, int.Parse(txtQuantidadeEstoque.Text), decimal.TryParse(txtValorCusto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out decimal valorCustoResult) ? valorCustoResult : default, decimal.Parse(txtValorProduto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat), DateTime.Now);
                _Vacina.AdicionarEditarVacina(Operacao);
                _Vacina.InserirAbastecimentoVacina(_Vacina.Quantidade);
            }
            else
            {
                _Vacina.Imunologia = CombBoxImunologia.Text;
                _Vacina.ConteudoML = int.Parse(txtConteudoML.Text);
                _Vacina.Doses = int.Parse(txtDoses.Text);
                _Vacina.Lote = txtLote.Text;
                _Vacina.Fabricante = txtFabricante.Text;
                _Vacina.DataValidade = DateDataValidade.Value;
                _Vacina.Quantidade = int.Parse(txtQuantidadeEstoque.Text);
                _Vacina.ValorMercado = decimal.TryParse(txtValorCusto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out decimal resultValorMercado) ? resultValorMercado : default;
                _Vacina.ValorProduto = decimal.TryParse(txtValorProduto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out decimal resultValorProduto) ? resultValorProduto : default;
                _Vacina.DataModificacao = DateTime.Now;
                _Vacina.AdicionarEditarVacina(Operacao);
                if (EstoqueAnterior != EstoqueAtual)
                {
                    _Vacina.InserirAbastecimentoVacina(EstoqueAtual - EstoqueAnterior);
                }
            }
            if (Application.OpenForms.OfType<PesquisarVacinas>().Count() == 1)
            {
                Application.OpenForms.OfType<PesquisarVacinas>().First().AtualizarLista();
            }
            Close();
        }

        private void txtValorCusto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValorProduto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValorCusto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                if (!Regex.IsMatch((sender as TextBox).Text, @"^[0-9]{,5}\.[0-9]{2}$"))
                {
                    (sender as TextBox).Text = Math.Round(double.Parse((sender as TextBox).Text), 2).ToString("C2", CultureInfo.CurrentCulture);
                }
            }
        }

        private void txtValorProduto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                if (!Regex.IsMatch((sender as TextBox).Text, @"^[0-9]{,5}\.[0-9]{2}$"))
                {
                    (sender as TextBox).Text = Math.Round(double.Parse((sender as TextBox).Text), 2).ToString("C2", CultureInfo.CurrentCulture);
                }
            }
        }

        private void txtValorProduto_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Text = decimal.TryParse((sender as TextBox).Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out decimal result) ? result.ToString() : default;
        }

        private void txtValorCusto_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Text = decimal.TryParse((sender as TextBox).Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out decimal result) ? result.ToString() : default;
        }

        private void txtValorCusto_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void txtValorProduto_TextChanged(object sender, EventArgs e)
        {
            VerificarCamposObrigatorios.ChecarCampos(btnSalvar, CamposObrigatorios, toolTip);
        }

        private void txtQuantidadeEstoque_Validated(object sender, EventArgs e)
        {
            EstoqueAtual = int.TryParse(txtQuantidadeEstoque.Text, out int EstoqueAtualResult) ? EstoqueAtualResult : default;
        }
    }
}