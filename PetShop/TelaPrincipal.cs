﻿using PetShop.Entities;
using PetShop.Entities.Enums;
using PetShop.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;


namespace PetShop
{
    public partial class TelaPrincipal : Form
    {
        private List<DataRow> ListaAgendamentos { get; set; }
        private DateTime DataAtual { get; set; }
        private Dictionary<int, TimeSpan> DeployedNotificacao { get; set; }

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void Tela_Principal_Load(object sender, EventArgs e)
        {
            ListaAgendamentos = new List<DataRow>();
            DeployedNotificacao = new Dictionary<int, TimeSpan>();
            Focus();
            menu_principal.GripStyle = ToolStripGripStyle.Hidden;
            DataAtual = DateTime.Now.Date;
            AtualizarAgendamentos();
            TimerAgendamentos.Interval = 60 * 1000;
            // Verificação de data em formato completo
            toolStripStatus_data_completa.Text = DataAtual.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            // Verificação de tecla Caps Lock ativa/inativa
            if (IsKeyLocked(Keys.CapsLock))
            {
                toolStripStatus_caps_lock.ForeColor = SystemColors.ActiveCaptionText;
            }
            else
            {
                toolStripStatus_caps_lock.ForeColor = SystemColors.InactiveCaption;
            }
            // Verificação de tecla Num Lock ativa/inativa
            if (IsKeyLocked(Keys.NumLock))
            {
                toolStripStatus_num_lock.ForeColor = SystemColors.ActiveCaptionText;
            }
            else
            {
                toolStripStatus_num_lock.ForeColor = SystemColors.InactiveCaption;
            }
            // Verificação de data em formato numerico
            toolStripStatus_data.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // Exibição nome de usuário do sistema
            toolStripStatus_nome_administrador.Text = Environment.UserName;
        }

        public void AtualizarAgendamentos()
        {
            ListaAgendamentos = Agenda.ListarAgendamentos(DateTime.Now, DateTime.Now).AsEnumerable().ToList();
            List<int> DeleteIndex = new List<int>();
            foreach (KeyValuePair<int, TimeSpan> dic in DeployedNotificacao)
            {
                if (!ListaAgendamentos.Any(value => (int)value["Id"] == dic.Key))
                {
                    DeleteIndex.Add(dic.Key);
                }
                else if (ListaAgendamentos.Any(value => (int)value["Id"] == dic.Key) && (TimeSpan)ListaAgendamentos.Where(v => (int)v["Id"] == dic.Key).Select(v => v["Horario"]).Single() != dic.Value)
                {
                    DeleteIndex.Add(dic.Key);
                }
            }
            foreach (int key in DeleteIndex)
            {
                DeployedNotificacao.Remove(key);
            }
            toolStripStatus_agendamentos_atuais.Text = $"Agendamentos para hoje: {ListaAgendamentos.Where(data => ((DateTime)data["Data"]).Date == DateTime.Now.Date).Select(data => data).Count()}";
        }

        private void btnMenuPesquisaClientes_Click(object sender, EventArgs e)
        {
            PesquisarClientesFornecedores pesquisaClientes = new PesquisarClientesFornecedores(TipoPesquisa.Cliente);
            pesquisaClientes.Show(this);
        }

        private void Tela_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se tecla Caps Lock está ativa
            if ((e.KeyCode & Keys.KeyCode) == Keys.CapsLock)
            {
                if (IsKeyLocked(Keys.CapsLock))
                {
                    toolStripStatus_caps_lock.ForeColor = SystemColors.ActiveCaptionText;
                }
                else
                {
                    toolStripStatus_caps_lock.ForeColor = SystemColors.InactiveCaption;
                }
            }
            // Verifica se tecla Num Lock está ativa
            if ((e.KeyCode & Keys.KeyCode) == Keys.NumLock)
            {
                if (Console.NumberLock)
                {
                    toolStripStatus_num_lock.ForeColor = SystemColors.ActiveCaptionText;
                }
                else
                {
                    toolStripStatus_num_lock.ForeColor = SystemColors.InactiveCaption;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }
        // Display de horário atual
        private void Horario_atual_Tick(object sender, EventArgs e)
        {
            toolStripStatus_horario.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnMenuFornecedores_Click(object sender, EventArgs e)
        {
            using (PesquisarClientesFornecedores pesquisaFornecedores = new PesquisarClientesFornecedores(TipoPesquisa.Fornecedor))
            {
                pesquisaFornecedores.ShowDialog();
            }
        }

        private void Botao_produtos_Click(object sender, EventArgs e)
        {
            PesquisarProdutos pesquisaProdutos = new PesquisarProdutos();
            pesquisaProdutos.Show(this);
        }

        private void BtnAnimais_Click(object sender, EventArgs e)
        {
            using (PesquisarAnimais pesquisaAnimais = new PesquisarAnimais())
            {
                pesquisaAnimais.ShowDialog();
            }
        }

        private void Botao_agenda_Click(object sender, EventArgs e)
        {
            PesquisarAgendamento agenda = new PesquisarAgendamento();
            agenda.Show(this);
        }

        private void TimerAgendamentos_Tick(object sender, EventArgs e)
        {
            try
            {


                foreach (DataRow data in ListaAgendamentos)
                {
                    if (!DeployedNotificacao.ContainsKey((int)data["Id"]))
                    {
                        string dateString = $"{data["Data"]:dd/MM/yyyy} {data["Horario"]}";
                        TimeSpan tempoRestante = DateTime.Parse(dateString) - DateTime.Now;
                        if (tempoRestante.TotalMinutes <= 5 && tempoRestante.TotalMinutes > 0)
                        {
                            FormNotificacao notificacao = new FormNotificacao();
                            notificacao.ShowAlert(data["NomeServico"].ToString(), TipoNotificacao.Agendamento, $"Novo agendamento às {((TimeSpan)data["Horario"]).ToString(@"hh\:mm")}:");


                            DeployedNotificacao.Add((int)data["Id"], (TimeSpan)data["Horario"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void timerDataAtual_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Date != DataAtual.Date)
            {
                DataAtual = DateTime.Now.Date;
                toolStripStatus_data_completa.Text = DataAtual.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            }
        }

        private void toolStripStatus_agendamentos_atuais_Click(object sender, EventArgs e)
        {
            PesquisarAgendamento agendamentos = new PesquisarAgendamento();
            agendamentos.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using (PesquisarCodigoBarras pesquisarCodigoBarras = new PesquisarCodigoBarras())
            {
                pesquisarCodigoBarras.ShowDialog();
            }
        }

        private void btnVacinas_Click(object sender, EventArgs e)
        {
            using (PesquisarVacinas pesquisarVacinas = new PesquisarVacinas())
            {
                pesquisarVacinas.ShowDialog();
            }
        }

        private void btnVacinacao_Click(object sender, EventArgs e)
        {
            using (PesquisarVacinacoes vacinacoes = new PesquisarVacinacoes())
            {
                vacinacoes.ShowDialog();
            }
        }
        [HandleProcessCorruptedStateExceptions]
        private void btnVenda_Click(object sender, EventArgs e)
        {
            using (LancarVenda venda = new LancarVenda())
            {
                try
                {
                    venda.ShowDialog();
                }
                catch (AccessViolationException except)
                {
                    MessageBox.Show($"Ocorreu um erro na tela de vendas: {except.Message}");
                    ErrorLogger.CreateErrorLog(except);
                }
            }
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            using (PesquisarServicos pesquisarServicos = new PesquisarServicos())
            {
                pesquisarServicos.ShowDialog();
            }
        }

        private void btnRelatorioVendas_Click(object sender, EventArgs e)
        {
            using (RelatorioVendas relatorioVendas = new RelatorioVendas())
            {
                relatorioVendas.ShowDialog();
            }
        }

        private void btnRelatorioProdutos_Click(object sender, EventArgs e)
        {
            using (RelatorioProdutos relatorioProdutos = new RelatorioProdutos())
            {
                relatorioProdutos.ShowDialog();
            }
        }

        private void btnRelatorioVacinas_Click(object sender, EventArgs e)
        {
            using (RelatorioVacinas relatorioVacinas = new RelatorioVacinas())
            {
                relatorioVacinas.ShowDialog();
            }
        }

        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            Opcoes opcoes = new Opcoes();
            opcoes.Show(this);
        }

        private void timerBackup_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.DbBackUpLocation) && Properties.Settings.Default.DbBackUpPeriod > new TimeSpan(0))
            {
                try
                {
                    if (!File.Exists($@"{Properties.Settings.Default.DbBackUpLocation}\PetShopDb.sdf"))
                    {
                        File.Copy($@"{AppDomain.CurrentDomain.BaseDirectory}Data\PetShopDb.sdf", $@"{Properties.Settings.Default.DbBackUpLocation}\PetShopDb.sdf");
                    }
                    if (File.GetLastWriteTime(Properties.Settings.Default.DbBackUpLocation).Add(Properties.Settings.Default.DbBackUpPeriod) < DateTime.Now)
                    {
                        File.Copy($@"{AppDomain.CurrentDomain.BaseDirectory}Data\PetShopDb.sdf", $@"{Properties.Settings.Default.DbBackUpLocation}\PetShopDb.sdf", true);
                        File.SetLastWriteTime($@"{Properties.Settings.Default.DbBackUpLocation}\PetShopDb.sdf", DateTime.Now);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao realizar o backup do banco de dados: {ex.Message}", "Erro no backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Properties.Settings.Default.DbBackUpLocation = null;
                    Properties.Settings.Default.DbBackUpPeriod = new TimeSpan(0);
                    ErrorLogger.CreateErrorLog(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao realizar o backup do banco de dados: {ex.Message}", "Erro no backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Properties.Settings.Default.DbBackUpLocation = null;
                    Properties.Settings.Default.DbBackUpPeriod = new TimeSpan(0);
                    ErrorLogger.CreateErrorLog(ex);
                }
            }
        }
    }
}
