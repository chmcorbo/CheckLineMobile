using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using GINT.DB.DAL;

namespace clMobile.DAL
{
    public class DALMobile
    {
        private OracleConnection _connection;
        private OracleCommand _cmd;
        private String _sql;

        public DALMobile()
        {
            _connection = new OracleConnection("Data Source=TAOL1_BCV;Persist Security Info=True;User ID=U93312800;Password=mudarsenha#02;Unicode=True");

        }
        
        public void InicioProcesso()
        {
            _sql = @"select distinct su.customer_id       as cliente,
                                     pc.account_id        as Conta,
                                     ch.arc_father_id     as UNIDADE_ORG,
                                     su.prim_resource_val as Msisdn,
                                     ar.resource_value    as SIM_CARD,
                                     su.subscriber_type   as Tecnologia,
                                     su.sub_status        as Status,
                                     su.sub_status_date   as DATA_DE_STATUS,
                                     st.act_rsn_desc      as MOTIVO_DA_ACAO,
                                     an.name_line1        as RAZAO_SOCIAL,
                                     an.tax_id            as CNPJ
                              from mtaappc.subscriber         su,
                                   mtaappc.csm_act_rsn        st,
                                   mtaappc.charge_distribute  cd,
                                   mtaappc.pay_channel        pc,
                                   mtaappc.address_name       an,
                                   mtaappc.ch_arcs            ch,
                                   mtaappc.agreement_resource ar
                            where su.sub_sts_last_act = st.activity_code
                              and su.sub_sts_rsn_cd = st.act_rsn_cd
                              and cd.agreement_no = su.subscriber_no
                              and cd.target_pcn = csm_paychnl
                              and an.account_id = pc.account_id
                              and su.ch_node_id = arc_child_id
                              and ar.agreement_no = su.subscriber_no
                              and ar.expiration_date is null
                              and ar.resource_type = 'S'
                              and (cd.expiration_date is null or cd.expiration_date >= sysdate)
                              and (ch.arc_valid_to >= sysdate or ch.arc_valid_to is null)
                              and su.prim_resource_val=:pNumeroLinha ";

            _cmd = new OracleCommand(_sql, _connection);
            _cmd.CommandType = CommandType.Text;
            OracleParameter _param = new OracleParameter("pNumeroLinha", OracleType.VarChar);
            _cmd.Parameters.Add(_param);
            _connection.Open();

        }

        public Dictionary<String,String> ConsultarStatus(String pNumeroLinha)
        {
            Dictionary<String, String> _result = new Dictionary<string, string>();

            _cmd.Parameters[0].Value = Convert.ToInt64(pNumeroLinha);
            OracleDataReader dr = _cmd.ExecuteReader();

            if (dr.Read() && dr.HasRows)
            {
                _result.Add("Cliente", dr["Cliente"].ToString());
                _result.Add("Conta", dr["Conta"].ToString());
                _result.Add("Unidade_Org", dr["Unidade_Org"].ToString());
                _result.Add("MSISDN", dr["MSISDN"].ToString());
                _result.Add("SIM_CARD", dr["SIM_CARD"].ToString());
                _result.Add("Tecnologia", dr["Tecnologia"].ToString());
                _result.Add("Status", dr["Status"].ToString());
                _result.Add("Data_de_Status", dr["Data_de_Status"].ToString());
                _result.Add("Motivo_da_acao", dr["Motivo_da_Acao"].ToString());
                _result.Add("Razao_Social", dr["Razao_Social"].ToString());
                _result.Add("CNPJ", dr["CNPJ"].ToString());
            }

            return _result;
        }

        public void FimProcesso()
        {
            _connection.Close();
        }
    }
}
