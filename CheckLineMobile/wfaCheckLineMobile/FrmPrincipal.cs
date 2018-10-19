using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using clMobile.Servicos;

namespace wfaCheckLineMobile
{
    public partial class FrmPrincipal : Form,IIndicadorProgresso
    {
        private List<String> _terminais;


        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private void AtualizarIndicacaoProgresso(String pMensagem)
        {
            if (!lbIndicadorProcesso.Visible)
                lbIndicadorProcesso.Visible = true;

            lbIndicadorProcesso.Text = pMensagem;

            this.Update();
        }

        private void AtualizarQuantidadeLinhas(Int32 pQtdeLinhas)
        {
            if (!lbQuantidadeLinhas.Visible)
                lbQuantidadeLinhas.Visible = true;

            lbQuantidadeLinhas.Text = pQtdeLinhas.ToString() + " terminal(is) lido(s)";
            this.Update();
        }

        private void btnAbrirDe_Click(object sender, EventArgs e)
        {
            if (ofdAbrirArquivoDe.ShowDialog(this)==DialogResult.OK)
            {
                txtArquivoOrigem.Text = ofdAbrirArquivoDe.FileName;
                SrvLeitorArquivo _leitorArquivo = new SrvLeitorArquivo(txtArquivoOrigem.Text);

                AtualizarIndicacaoProgresso("Lendo o arquivo texto");
                _terminais = _leitorArquivo.Ler();

                lstTerminais.Items.Clear();

                for (int x = 0; x <= _terminais.Count - 1; x++)
                {
                    lstTerminais.Items.Add(_terminais[x]);
                }

                AtualizarIndicacaoProgresso("Leitura concluída");
                AtualizarQuantidadeLinhas(lstTerminais.Items.Count);
            }
        }

        private void btnSalvarEm_Click(object sender, EventArgs e)
        {
            sfdSalvarArquivo.InitialDirectory = Application.ExecutablePath;
            if (sfdSalvarArquivo.ShowDialog(this)==DialogResult.OK)
            {
                txtSalvarEm.Text = sfdSalvarArquivo.FileName;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProcessarTerminais()
        {
            SrvLocalizadorTerminais _srvLocalizadorTerminais = new SrvLocalizadorTerminais(this);
            SrvGravadorArquivoCSV _srvGravadorArquivoCSV = new SrvGravadorArquivoCSV(txtSalvarEm.Text);

            List<String> _linhas = _srvLocalizadorTerminais.Execute(_terminais);

            AtualizarIndicacaoProgresso("Gerando o arquivo...");
            _srvGravadorArquivoCSV.Salvar(_linhas);

            AtualizarIndicacaoProgresso("Concluído...");

            MessageBox.Show("Processamento concluído");
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (txtArquivoOrigem.Text==String.Empty)
            {
                MessageBox.Show("Nome do arquivo do arquivo de entrada não informado.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSalvarEm.Text == String.Empty)
            {
                MessageBox.Show("Nome do arquivo do arquivo de saída não informado.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lstTerminais.Items.Count==0)
            {
                MessageBox.Show("Nenhum terminal carregado.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Task tarefa = new Task(() => ProcessarTerminais());
                tarefa.Start();
                // ProcessarTerminais();
            }
        }

        public void Atualizar(string pMensagem)
        {
            AtualizarIndicacaoProgresso(pMensagem);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lstTerminais.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
