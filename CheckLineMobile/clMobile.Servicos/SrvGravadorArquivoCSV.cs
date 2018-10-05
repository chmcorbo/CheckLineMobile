using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace clMobile.Servicos
{
    public class SrvGravadorArquivoCSV
    {
        private StreamWriter _arquivo;

        private const String _cabecalho = "cliente;conta;unidade_org;msisdn;sim_card;tecnologia;status;data_de_status;motivo_da_acao;razao_social;cnpj";
       
        public String NomeArquivo;
       

        public SrvGravadorArquivoCSV(String pNomeArquivo)
        {
            NomeArquivo = pNomeArquivo;
            _arquivo = new StreamWriter(NomeArquivo, false);
        }

        public void Salvar(List<String> pLinhas)
        {
            _arquivo.WriteLine(_cabecalho);

            foreach (String linha in pLinhas)
            {
                _arquivo.WriteLine(linha);
            }
            _arquivo.Flush();
            _arquivo.Close();
        }
    }
}
