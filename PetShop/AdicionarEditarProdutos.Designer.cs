﻿
namespace PetShop
{
    partial class AdicionarEditarProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.quantidadeProduto = new System.Windows.Forms.TextBox();
            this.dataCadastroProduto = new System.Windows.Forms.DateTimePicker();
            this.categoriaProduto = new System.Windows.Forms.ComboBox();
            this.labelCategoriaProduto = new System.Windows.Forms.Label();
            this.marcaProduto = new System.Windows.Forms.ComboBox();
            this.labelMarcaProduto = new System.Windows.Forms.Label();
            this.labelDataCadastroProduto = new System.Windows.Forms.Label();
            this.localizacaoProduto = new System.Windows.Forms.TextBox();
            this.labelLocalizacaoProduto = new System.Windows.Forms.Label();
            this.referenciaProduto = new System.Windows.Forms.TextBox();
            this.labelReferenciaProduto = new System.Windows.Forms.Label();
            this.nomeProduto = new System.Windows.Forms.TextBox();
            this.labelCodigoBarras = new System.Windows.Forms.Label();
            this.labelNomeProduto = new System.Windows.Forms.Label();
            this.tipoUnidadeProduto = new System.Windows.Forms.ComboBox();
            this.labelTipoUnidade = new System.Windows.Forms.Label();
            this.codigoBarrasProduto = new System.Windows.Forms.TextBox();
            this.codigoProduto = new System.Windows.Forms.TextBox();
            this.labelCodigoProduto = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataValidadeProduto = new System.Windows.Forms.DateTimePicker();
            this.labelDataValidade = new System.Windows.Forms.Label();
            this.estoqueAtualProduto = new System.Windows.Forms.TextBox();
            this.labelEstoqueAtual = new System.Windows.Forms.Label();
            this.estoqueMinimoProduto = new System.Windows.Forms.TextBox();
            this.labelEstoqueMinimo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.precoProduto = new System.Windows.Forms.TextBox();
            this.valorCustoProduto = new System.Windows.Forms.TextBox();
            this.labelPrecoProduto = new System.Windows.Forms.Label();
            this.margemAvistaProduto = new System.Windows.Forms.TextBox();
            this.labelMargemAvista = new System.Windows.Forms.Label();
            this.labelValorCusto = new System.Windows.Forms.Label();
            this.observacoesProduto = new System.Windows.Forms.RichTextBox();
            this.labelObservacoes = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BtnAdicionarEditarFornecedor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.quantidadeProduto);
            this.groupBox1.Controls.Add(this.dataCadastroProduto);
            this.groupBox1.Controls.Add(this.categoriaProduto);
            this.groupBox1.Controls.Add(this.labelCategoriaProduto);
            this.groupBox1.Controls.Add(this.marcaProduto);
            this.groupBox1.Controls.Add(this.labelMarcaProduto);
            this.groupBox1.Controls.Add(this.labelDataCadastroProduto);
            this.groupBox1.Controls.Add(this.localizacaoProduto);
            this.groupBox1.Controls.Add(this.labelLocalizacaoProduto);
            this.groupBox1.Controls.Add(this.referenciaProduto);
            this.groupBox1.Controls.Add(this.labelReferenciaProduto);
            this.groupBox1.Controls.Add(this.nomeProduto);
            this.groupBox1.Controls.Add(this.labelCodigoBarras);
            this.groupBox1.Controls.Add(this.labelNomeProduto);
            this.groupBox1.Controls.Add(this.tipoUnidadeProduto);
            this.groupBox1.Controls.Add(this.labelTipoUnidade);
            this.groupBox1.Controls.Add(this.codigoBarrasProduto);
            this.groupBox1.Controls.Add(this.codigoProduto);
            this.groupBox1.Controls.Add(this.labelCodigoProduto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 248);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(543, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Quantidade*";
            // 
            // quantidadeProduto
            // 
            this.quantidadeProduto.BackColor = System.Drawing.SystemColors.Window;
            this.quantidadeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantidadeProduto.Location = new System.Drawing.Point(546, 42);
            this.quantidadeProduto.MaxLength = 500;
            this.quantidadeProduto.Name = "quantidadeProduto";
            this.quantidadeProduto.Size = new System.Drawing.Size(92, 22);
            this.quantidadeProduto.TabIndex = 31;
            this.quantidadeProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuantidadeProduto_KeyPress);
            // 
            // dataCadastroProduto
            // 
            this.dataCadastroProduto.CustomFormat = "dd/MM/yyyy";
            this.dataCadastroProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCadastroProduto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataCadastroProduto.Location = new System.Drawing.Point(487, 154);
            this.dataCadastroProduto.Name = "dataCadastroProduto";
            this.dataCadastroProduto.Size = new System.Drawing.Size(151, 22);
            this.dataCadastroProduto.TabIndex = 20;
            // 
            // categoriaProduto
            // 
            this.categoriaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaProduto.FormattingEnabled = true;
            this.categoriaProduto.Location = new System.Drawing.Point(369, 207);
            this.categoriaProduto.Name = "categoriaProduto";
            this.categoriaProduto.Size = new System.Drawing.Size(269, 24);
            this.categoriaProduto.TabIndex = 30;
            // 
            // labelCategoriaProduto
            // 
            this.labelCategoriaProduto.AutoSize = true;
            this.labelCategoriaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategoriaProduto.Location = new System.Drawing.Point(366, 186);
            this.labelCategoriaProduto.Name = "labelCategoriaProduto";
            this.labelCategoriaProduto.Size = new System.Drawing.Size(210, 18);
            this.labelCategoriaProduto.TabIndex = 29;
            this.labelCategoriaProduto.Text = "Grupo / Categoria do Produto*";
            // 
            // marcaProduto
            // 
            this.marcaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marcaProduto.FormattingEnabled = true;
            this.marcaProduto.Location = new System.Drawing.Point(20, 207);
            this.marcaProduto.Name = "marcaProduto";
            this.marcaProduto.Size = new System.Drawing.Size(291, 24);
            this.marcaProduto.TabIndex = 28;
            // 
            // labelMarcaProduto
            // 
            this.labelMarcaProduto.AutoSize = true;
            this.labelMarcaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarcaProduto.Location = new System.Drawing.Point(17, 186);
            this.labelMarcaProduto.Name = "labelMarcaProduto";
            this.labelMarcaProduto.Size = new System.Drawing.Size(128, 18);
            this.labelMarcaProduto.TabIndex = 27;
            this.labelMarcaProduto.Text = "Marca do Produto";
            // 
            // labelDataCadastroProduto
            // 
            this.labelDataCadastroProduto.AutoSize = true;
            this.labelDataCadastroProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataCadastroProduto.Location = new System.Drawing.Point(484, 133);
            this.labelDataCadastroProduto.Name = "labelDataCadastroProduto";
            this.labelDataCadastroProduto.Size = new System.Drawing.Size(130, 18);
            this.labelDataCadastroProduto.TabIndex = 25;
            this.labelDataCadastroProduto.Text = "Data de Cadastro*";
            // 
            // localizacaoProduto
            // 
            this.localizacaoProduto.BackColor = System.Drawing.SystemColors.Window;
            this.localizacaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localizacaoProduto.Location = new System.Drawing.Point(280, 154);
            this.localizacaoProduto.MaxLength = 500;
            this.localizacaoProduto.Name = "localizacaoProduto";
            this.localizacaoProduto.Size = new System.Drawing.Size(169, 22);
            this.localizacaoProduto.TabIndex = 24;
            // 
            // labelLocalizacaoProduto
            // 
            this.labelLocalizacaoProduto.AutoSize = true;
            this.labelLocalizacaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocalizacaoProduto.Location = new System.Drawing.Point(277, 133);
            this.labelLocalizacaoProduto.Name = "labelLocalizacaoProduto";
            this.labelLocalizacaoProduto.Size = new System.Drawing.Size(88, 18);
            this.labelLocalizacaoProduto.TabIndex = 23;
            this.labelLocalizacaoProduto.Text = "Localização";
            // 
            // referenciaProduto
            // 
            this.referenciaProduto.BackColor = System.Drawing.SystemColors.Window;
            this.referenciaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenciaProduto.Location = new System.Drawing.Point(20, 154);
            this.referenciaProduto.MaxLength = 500;
            this.referenciaProduto.Name = "referenciaProduto";
            this.referenciaProduto.Size = new System.Drawing.Size(217, 22);
            this.referenciaProduto.TabIndex = 22;
            // 
            // labelReferenciaProduto
            // 
            this.labelReferenciaProduto.AutoSize = true;
            this.labelReferenciaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReferenciaProduto.Location = new System.Drawing.Point(17, 133);
            this.labelReferenciaProduto.Name = "labelReferenciaProduto";
            this.labelReferenciaProduto.Size = new System.Drawing.Size(157, 18);
            this.labelReferenciaProduto.TabIndex = 21;
            this.labelReferenciaProduto.Text = "Referência do Produto";
            // 
            // nomeProduto
            // 
            this.nomeProduto.BackColor = System.Drawing.SystemColors.Info;
            this.nomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeProduto.Location = new System.Drawing.Point(20, 98);
            this.nomeProduto.MaxLength = 500;
            this.nomeProduto.Name = "nomeProduto";
            this.nomeProduto.Size = new System.Drawing.Size(618, 22);
            this.nomeProduto.TabIndex = 20;
            // 
            // labelCodigoBarras
            // 
            this.labelCodigoBarras.AutoSize = true;
            this.labelCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigoBarras.Location = new System.Drawing.Point(157, 21);
            this.labelCodigoBarras.Name = "labelCodigoBarras";
            this.labelCodigoBarras.Size = new System.Drawing.Size(124, 18);
            this.labelCodigoBarras.TabIndex = 3;
            this.labelCodigoBarras.Text = "Código de Barras";
            // 
            // labelNomeProduto
            // 
            this.labelNomeProduto.AutoSize = true;
            this.labelNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeProduto.Location = new System.Drawing.Point(17, 77);
            this.labelNomeProduto.Name = "labelNomeProduto";
            this.labelNomeProduto.Size = new System.Drawing.Size(213, 18);
            this.labelNomeProduto.TabIndex = 19;
            this.labelNomeProduto.Text = "Nome / Descrição do Produto*";
            // 
            // tipoUnidadeProduto
            // 
            this.tipoUnidadeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoUnidadeProduto.FormattingEnabled = true;
            this.tipoUnidadeProduto.Items.AddRange(new object[] {
            "Kg",
            "Mg",
            "g",
            "L",
            "Ml",
            "Granel"});
            this.tipoUnidadeProduto.Location = new System.Drawing.Point(417, 42);
            this.tipoUnidadeProduto.Name = "tipoUnidadeProduto";
            this.tipoUnidadeProduto.Size = new System.Drawing.Size(94, 24);
            this.tipoUnidadeProduto.TabIndex = 18;
            // 
            // labelTipoUnidade
            // 
            this.labelTipoUnidade.AutoSize = true;
            this.labelTipoUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoUnidade.Location = new System.Drawing.Point(414, 21);
            this.labelTipoUnidade.Name = "labelTipoUnidade";
            this.labelTipoUnidade.Size = new System.Drawing.Size(86, 18);
            this.labelTipoUnidade.TabIndex = 17;
            this.labelTipoUnidade.Text = "Tipo de Un*";
            // 
            // codigoBarrasProduto
            // 
            this.codigoBarrasProduto.BackColor = System.Drawing.SystemColors.Info;
            this.codigoBarrasProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoBarrasProduto.Location = new System.Drawing.Point(160, 42);
            this.codigoBarrasProduto.MaxLength = 500;
            this.codigoBarrasProduto.Name = "codigoBarrasProduto";
            this.codigoBarrasProduto.Size = new System.Drawing.Size(229, 22);
            this.codigoBarrasProduto.TabIndex = 16;
            // 
            // codigoProduto
            // 
            this.codigoProduto.BackColor = System.Drawing.SystemColors.Window;
            this.codigoProduto.Enabled = false;
            this.codigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoProduto.Location = new System.Drawing.Point(20, 42);
            this.codigoProduto.MaxLength = 500;
            this.codigoProduto.Name = "codigoProduto";
            this.codigoProduto.Size = new System.Drawing.Size(112, 22);
            this.codigoProduto.TabIndex = 2;
            // 
            // labelCodigoProduto
            // 
            this.labelCodigoProduto.AutoSize = true;
            this.labelCodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigoProduto.Location = new System.Drawing.Point(17, 21);
            this.labelCodigoProduto.Name = "labelCodigoProduto";
            this.labelCodigoProduto.Size = new System.Drawing.Size(56, 18);
            this.labelCodigoProduto.TabIndex = 1;
            this.labelCodigoProduto.Text = "Código";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataValidadeProduto);
            this.groupBox2.Controls.Add(this.labelDataValidade);
            this.groupBox2.Controls.Add(this.estoqueAtualProduto);
            this.groupBox2.Controls.Add(this.labelEstoqueAtual);
            this.groupBox2.Controls.Add(this.estoqueMinimoProduto);
            this.groupBox2.Controls.Add(this.labelEstoqueMinimo);
            this.groupBox2.Location = new System.Drawing.Point(12, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 138);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataValidadeProduto
            // 
            this.dataValidadeProduto.CustomFormat = "dd/MM/yyyy";
            this.dataValidadeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataValidadeProduto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataValidadeProduto.Location = new System.Drawing.Point(147, 98);
            this.dataValidadeProduto.Name = "dataValidadeProduto";
            this.dataValidadeProduto.Size = new System.Drawing.Size(164, 22);
            this.dataValidadeProduto.TabIndex = 31;
            // 
            // labelDataValidade
            // 
            this.labelDataValidade.AutoSize = true;
            this.labelDataValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataValidade.Location = new System.Drawing.Point(17, 99);
            this.labelDataValidade.Name = "labelDataValidade";
            this.labelDataValidade.Size = new System.Drawing.Size(124, 18);
            this.labelDataValidade.TabIndex = 28;
            this.labelDataValidade.Text = "Data de Validade*";
            // 
            // estoqueAtualProduto
            // 
            this.estoqueAtualProduto.BackColor = System.Drawing.SystemColors.Window;
            this.estoqueAtualProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estoqueAtualProduto.Location = new System.Drawing.Point(147, 56);
            this.estoqueAtualProduto.MaxLength = 500;
            this.estoqueAtualProduto.Name = "estoqueAtualProduto";
            this.estoqueAtualProduto.Size = new System.Drawing.Size(164, 22);
            this.estoqueAtualProduto.TabIndex = 27;
            this.estoqueAtualProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EstoqueAtualProduto_KeyPress);
            // 
            // labelEstoqueAtual
            // 
            this.labelEstoqueAtual.AutoSize = true;
            this.labelEstoqueAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstoqueAtual.Location = new System.Drawing.Point(17, 57);
            this.labelEstoqueAtual.Name = "labelEstoqueAtual";
            this.labelEstoqueAtual.Size = new System.Drawing.Size(105, 18);
            this.labelEstoqueAtual.TabIndex = 26;
            this.labelEstoqueAtual.Text = "Estoque Atual*";
            // 
            // estoqueMinimoProduto
            // 
            this.estoqueMinimoProduto.BackColor = System.Drawing.SystemColors.Window;
            this.estoqueMinimoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estoqueMinimoProduto.Location = new System.Drawing.Point(147, 15);
            this.estoqueMinimoProduto.MaxLength = 500;
            this.estoqueMinimoProduto.Name = "estoqueMinimoProduto";
            this.estoqueMinimoProduto.Size = new System.Drawing.Size(164, 22);
            this.estoqueMinimoProduto.TabIndex = 25;
            this.estoqueMinimoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EstoqueMinimoProduto_KeyPress);
            // 
            // labelEstoqueMinimo
            // 
            this.labelEstoqueMinimo.AutoSize = true;
            this.labelEstoqueMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstoqueMinimo.Location = new System.Drawing.Point(17, 16);
            this.labelEstoqueMinimo.Name = "labelEstoqueMinimo";
            this.labelEstoqueMinimo.Size = new System.Drawing.Size(116, 18);
            this.labelEstoqueMinimo.TabIndex = 2;
            this.labelEstoqueMinimo.Text = "Estoque Mínimo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.precoProduto);
            this.groupBox3.Controls.Add(this.valorCustoProduto);
            this.groupBox3.Controls.Add(this.labelPrecoProduto);
            this.groupBox3.Controls.Add(this.margemAvistaProduto);
            this.groupBox3.Controls.Add(this.labelMargemAvista);
            this.groupBox3.Controls.Add(this.labelValorCusto);
            this.groupBox3.Location = new System.Drawing.Point(350, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 138);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // precoProduto
            // 
            this.precoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoProduto.Location = new System.Drawing.Point(169, 98);
            this.precoProduto.Name = "precoProduto";
            this.precoProduto.Size = new System.Drawing.Size(131, 22);
            this.precoProduto.TabIndex = 33;
            this.precoProduto.Enter += new System.EventHandler(this.PrecoProduto_Enter);
            this.precoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrecoProduto_KeyPress);
            this.precoProduto.Leave += new System.EventHandler(this.PrecoProduto_Leave);
            // 
            // valorCustoProduto
            // 
            this.valorCustoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorCustoProduto.Location = new System.Drawing.Point(169, 15);
            this.valorCustoProduto.Name = "valorCustoProduto";
            this.valorCustoProduto.Size = new System.Drawing.Size(131, 22);
            this.valorCustoProduto.TabIndex = 32;
            this.valorCustoProduto.Enter += new System.EventHandler(this.ValorCustoProduto_Enter);
            this.valorCustoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValorCustoProduto_KeyPress);
            this.valorCustoProduto.Leave += new System.EventHandler(this.ValorCustoProduto_Leave);
            // 
            // labelPrecoProduto
            // 
            this.labelPrecoProduto.AutoSize = true;
            this.labelPrecoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecoProduto.Location = new System.Drawing.Point(8, 99);
            this.labelPrecoProduto.Name = "labelPrecoProduto";
            this.labelPrecoProduto.Size = new System.Drawing.Size(132, 18);
            this.labelPrecoProduto.TabIndex = 31;
            this.labelPrecoProduto.Text = "Preço do Produto*";
            // 
            // margemAvistaProduto
            // 
            this.margemAvistaProduto.BackColor = System.Drawing.SystemColors.Window;
            this.margemAvistaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.margemAvistaProduto.Location = new System.Drawing.Point(169, 56);
            this.margemAvistaProduto.MaxLength = 500;
            this.margemAvistaProduto.Name = "margemAvistaProduto";
            this.margemAvistaProduto.Size = new System.Drawing.Size(131, 22);
            this.margemAvistaProduto.TabIndex = 29;
            this.margemAvistaProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MargemAvistaProduto_KeyPress);
            // 
            // labelMargemAvista
            // 
            this.labelMargemAvista.AutoSize = true;
            this.labelMargemAvista.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMargemAvista.Location = new System.Drawing.Point(8, 57);
            this.labelMargemAvista.Name = "labelMargemAvista";
            this.labelMargemAvista.Size = new System.Drawing.Size(138, 18);
            this.labelMargemAvista.TabIndex = 28;
            this.labelMargemAvista.Text = "Margem a Vista (%)";
            // 
            // labelValorCusto
            // 
            this.labelValorCusto.AutoSize = true;
            this.labelValorCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorCusto.Location = new System.Drawing.Point(8, 17);
            this.labelValorCusto.Name = "labelValorCusto";
            this.labelValorCusto.Size = new System.Drawing.Size(106, 18);
            this.labelValorCusto.TabIndex = 27;
            this.labelValorCusto.Text = "Valor de Custo";
            // 
            // observacoesProduto
            // 
            this.observacoesProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.observacoesProduto.Location = new System.Drawing.Point(12, 437);
            this.observacoesProduto.Name = "observacoesProduto";
            this.observacoesProduto.Size = new System.Drawing.Size(663, 184);
            this.observacoesProduto.TabIndex = 3;
            this.observacoesProduto.Text = "";
            // 
            // labelObservacoes
            // 
            this.labelObservacoes.AutoSize = true;
            this.labelObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObservacoes.Location = new System.Drawing.Point(12, 416);
            this.labelObservacoes.Name = "labelObservacoes";
            this.labelObservacoes.Size = new System.Drawing.Size(263, 18);
            this.labelObservacoes.TabIndex = 4;
            this.labelObservacoes.Text = "Informações Adicionais / Observações";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::PetShop.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(12, 636);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(161, 52);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAdicionarEditarFornecedor
            // 
            this.BtnAdicionarEditarFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdicionarEditarFornecedor.AutoSize = true;
            this.BtnAdicionarEditarFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdicionarEditarFornecedor.Image = global::PetShop.Properties.Resources.adicionar;
            this.BtnAdicionarEditarFornecedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdicionarEditarFornecedor.Location = new System.Drawing.Point(625, 636);
            this.BtnAdicionarEditarFornecedor.Name = "BtnAdicionarEditarFornecedor";
            this.BtnAdicionarEditarFornecedor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnAdicionarEditarFornecedor.Size = new System.Drawing.Size(50, 52);
            this.BtnAdicionarEditarFornecedor.TabIndex = 19;
            this.BtnAdicionarEditarFornecedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAdicionarEditarFornecedor.UseVisualStyleBackColor = true;
            this.BtnAdicionarEditarFornecedor.Click += new System.EventHandler(this.BtnAdicionarEditarFornecedor_Click);
            // 
            // AdicionarEditarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 709);
            this.Controls.Add(this.BtnAdicionarEditarFornecedor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelObservacoes);
            this.Controls.Add(this.observacoesProduto);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdicionarEditarProdutos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AdicionarEditarProdutos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCodigoProduto;
        private System.Windows.Forms.Label labelCodigoBarras;
        private System.Windows.Forms.TextBox codigoProduto;
        private System.Windows.Forms.Label labelTipoUnidade;
        private System.Windows.Forms.TextBox codigoBarrasProduto;
        private System.Windows.Forms.ComboBox tipoUnidadeProduto;
        private System.Windows.Forms.Label labelLocalizacaoProduto;
        private System.Windows.Forms.TextBox referenciaProduto;
        private System.Windows.Forms.Label labelReferenciaProduto;
        private System.Windows.Forms.TextBox nomeProduto;
        private System.Windows.Forms.Label labelNomeProduto;
        private System.Windows.Forms.ComboBox categoriaProduto;
        private System.Windows.Forms.Label labelCategoriaProduto;
        private System.Windows.Forms.ComboBox marcaProduto;
        private System.Windows.Forms.Label labelMarcaProduto;
        private System.Windows.Forms.Label labelDataCadastroProduto;
        private System.Windows.Forms.TextBox localizacaoProduto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelDataValidade;
        private System.Windows.Forms.TextBox estoqueAtualProduto;
        private System.Windows.Forms.Label labelEstoqueAtual;
        private System.Windows.Forms.TextBox estoqueMinimoProduto;
        private System.Windows.Forms.Label labelEstoqueMinimo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelPrecoProduto;
        private System.Windows.Forms.TextBox margemAvistaProduto;
        private System.Windows.Forms.Label labelMargemAvista;
        private System.Windows.Forms.Label labelValorCusto;
        private System.Windows.Forms.RichTextBox observacoesProduto;
        private System.Windows.Forms.Label labelObservacoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button BtnAdicionarEditarFornecedor;
        private System.Windows.Forms.DateTimePicker dataCadastroProduto;
        private System.Windows.Forms.DateTimePicker dataValidadeProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox quantidadeProduto;
        private System.Windows.Forms.TextBox precoProduto;
        private System.Windows.Forms.TextBox valorCustoProduto;
    }
}