using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clMobile.DAL;

namespace clMobile.Servicos
{
    public class SrvLocalizadorTerminais
    {
        private IIndicadorProgresso _indicadorProgresso;
        private DALMobile _dalMobile;

        public SrvLocalizadorTerminais(IIndicadorProgresso pIndicadorProgresso)
        {
            _indicadorProgresso = pIndicadorProgresso;
            _dalMobile = new DALMobile();
        }

        public List<String> Execute(List<String> pTerminais)
        {
            List<String> _lstLinhas = new List<string>();

            Int32 _linhaAtual;
            Int32 _totalLinhas = pTerminais.Count;
            String _progresso = String.Empty;

            _indicadorProgresso.Atualizar("Iniciando o processamento... ");
            _dalMobile.InicioProcesso();
            for (_linhaAtual=0; _linhaAtual <= _totalLinhas-1; _linhaAtual++)
            {
                String _linhaProcessada = String.Empty;

                _progresso = String.Format("Consultando terminal {0} de {1} ",(_linhaAtual+1).ToString(),_totalLinhas.ToString());
                _indicadorProgresso.Atualizar(_progresso);

                Dictionary<String,String> dc = _dalMobile.ConsultarStatus(pTerminais[_linhaAtual]);
                
                if (dc.Count>0)
                {

                    String value = dc["Cliente"];

                    _linhaProcessada = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
                        dc["Cliente"], dc["Conta"], dc["Unidade_Org"], dc["MSISDN"],
                        dc["SIM_CARD"], dc["Tecnologia"], dc["Status"], dc["Data_de_Status"],
                        dc["Motivo_da_acao"], dc["Razao_Social"], dc["CNPJ"]);
                }
                else
                {
                    _linhaProcessada = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", 
                        "", "", "", pTerminais[_linhaAtual], "", "", "", "", "", "", "", "");
                }
                _lstLinhas.Add(_linhaProcessada);
            }
            _dalMobile.FimProcesso();
            return _lstLinhas;
        }
    }
}
