using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clMobile.Model
{
    public class LineStatus
    {
        public String Cliente { get; set; }
        public String Conta { get; set; }
        public String Unidade_Org { get; set; }
        public String MSISDN { get; set; }
        public String SIM_Card { get; set; }
        public String Tecnologia { get; set; }
        public String Status { get; set; }
        public DateTime Data_de_Status { get; set; }
        public String Motivo_Acao { get; set; }
        public String Razao_Social { get; set; }
        public String CNPJ { get; set; }
    }
}
