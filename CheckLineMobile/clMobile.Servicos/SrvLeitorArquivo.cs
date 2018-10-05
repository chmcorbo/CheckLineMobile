using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace clMobile.Servicos
{
    public class SrvLeitorArquivo
    {
        private StreamReader _arquivoTexo;
        public SrvLeitorArquivo(String pCaminho)
        {
            _arquivoTexo = new StreamReader(pCaminho);
        }
        public List<String> Ler()
        {
            List<String> _linhas = new List<string>();
            String _linha = String.Empty;

            while (!_arquivoTexo.EndOfStream)
            {
                _linha = _arquivoTexo.ReadLine();
                _linhas.Add(_linha);
            }

            return _linhas;
        }
    }
}
