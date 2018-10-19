namespace wfaCheckLineMobile
{
    partial class FrmPrincipal
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
            this.btnAbrirDe = new System.Windows.Forms.Button();
            this.sfdSalvarArquivo = new System.Windows.Forms.SaveFileDialog();
            this.ofdAbrirArquivoDe = new System.Windows.Forms.OpenFileDialog();
            this.lstTerminais = new System.Windows.Forms.ListBox();
            this.txtArquivoOrigem = new System.Windows.Forms.TextBox();
            this.txtSalvarEm = new System.Windows.Forms.TextBox();
            this.btnSalvarEm = new System.Windows.Forms.Button();
            this.lbQuantidadeLinhas = new System.Windows.Forms.Label();
            this.lbIndicadorProcesso = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAbrirDe
            // 
            this.btnAbrirDe.Location = new System.Drawing.Point(634, 28);
            this.btnAbrirDe.Name = "btnAbrirDe";
            this.btnAbrirDe.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirDe.TabIndex = 0;
            this.btnAbrirDe.Text = "Abrir arquivo";
            this.btnAbrirDe.UseVisualStyleBackColor = true;
            this.btnAbrirDe.Click += new System.EventHandler(this.btnAbrirDe_Click);
            // 
            // sfdSalvarArquivo
            // 
            this.sfdSalvarArquivo.Filter = "Arquivo CSV|*.csv";
            // 
            // ofdAbrirArquivoDe
            // 
            this.ofdAbrirArquivoDe.Filter = "Arquivo texto|*.txt";
            this.ofdAbrirArquivoDe.Title = "Selecione um arquivo com terminais";
            // 
            // lstTerminais
            // 
            this.lstTerminais.FormattingEnabled = true;
            this.lstTerminais.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3"});
            this.lstTerminais.Location = new System.Drawing.Point(13, 88);
            this.lstTerminais.Name = "lstTerminais";
            this.lstTerminais.Size = new System.Drawing.Size(260, 407);
            this.lstTerminais.TabIndex = 1;
            // 
            // txtArquivoOrigem
            // 
            this.txtArquivoOrigem.Enabled = false;
            this.txtArquivoOrigem.Location = new System.Drawing.Point(13, 28);
            this.txtArquivoOrigem.Name = "txtArquivoOrigem";
            this.txtArquivoOrigem.Size = new System.Drawing.Size(615, 20);
            this.txtArquivoOrigem.TabIndex = 2;
            // 
            // txtSalvarEm
            // 
            this.txtSalvarEm.Enabled = false;
            this.txtSalvarEm.Location = new System.Drawing.Point(13, 62);
            this.txtSalvarEm.Name = "txtSalvarEm";
            this.txtSalvarEm.Size = new System.Drawing.Size(616, 20);
            this.txtSalvarEm.TabIndex = 3;
            // 
            // btnSalvarEm
            // 
            this.btnSalvarEm.Location = new System.Drawing.Point(634, 59);
            this.btnSalvarEm.Name = "btnSalvarEm";
            this.btnSalvarEm.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarEm.TabIndex = 4;
            this.btnSalvarEm.Text = "Salvar em...";
            this.btnSalvarEm.UseVisualStyleBackColor = true;
            this.btnSalvarEm.Click += new System.EventHandler(this.btnSalvarEm_Click);
            // 
            // lbQuantidadeLinhas
            // 
            this.lbQuantidadeLinhas.AutoSize = true;
            this.lbQuantidadeLinhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantidadeLinhas.Location = new System.Drawing.Point(279, 471);
            this.lbQuantidadeLinhas.Name = "lbQuantidadeLinhas";
            this.lbQuantidadeLinhas.Size = new System.Drawing.Size(178, 24);
            this.lbQuantidadeLinhas.TabIndex = 5;
            this.lbQuantidadeLinhas.Text = "lbQuantidadeLinhas";
            this.lbQuantidadeLinhas.Visible = false;
            // 
            // lbIndicadorProcesso
            // 
            this.lbIndicadorProcesso.AutoSize = true;
            this.lbIndicadorProcesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIndicadorProcesso.ForeColor = System.Drawing.Color.Red;
            this.lbIndicadorProcesso.Location = new System.Drawing.Point(279, 85);
            this.lbIndicadorProcesso.Name = "lbIndicadorProcesso";
            this.lbIndicadorProcesso.Size = new System.Drawing.Size(206, 24);
            this.lbIndicadorProcesso.TabIndex = 5;
            this.lbIndicadorProcesso.Text = "Indicador de Progresso";
            this.lbIndicadorProcesso.Visible = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(715, 57);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(715, 28);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(75, 23);
            this.btnProcessar.TabIndex = 7;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 497);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lbIndicadorProcesso);
            this.Controls.Add(this.lbQuantidadeLinhas);
            this.Controls.Add(this.btnSalvarEm);
            this.Controls.Add(this.txtSalvarEm);
            this.Controls.Add(this.txtArquivoOrigem);
            this.Controls.Add(this.lstTerminais);
            this.Controls.Add(this.btnAbrirDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Status do terminais - V1.0.1";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirDe;
        private System.Windows.Forms.SaveFileDialog sfdSalvarArquivo;
        private System.Windows.Forms.OpenFileDialog ofdAbrirArquivoDe;
        private System.Windows.Forms.ListBox lstTerminais;
        private System.Windows.Forms.TextBox txtArquivoOrigem;
        private System.Windows.Forms.TextBox txtSalvarEm;
        private System.Windows.Forms.Button btnSalvarEm;
        private System.Windows.Forms.Label lbQuantidadeLinhas;
        private System.Windows.Forms.Label lbIndicadorProcesso;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnProcessar;
    }
}

