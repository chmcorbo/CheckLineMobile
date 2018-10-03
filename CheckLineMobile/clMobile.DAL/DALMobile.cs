using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GINT.DB.DAL;
using clMobile.Model;

namespace clMobile.DAL
{
    public class DALMobile
    {
        private DALBaseEL _dalBaseEL;
        
        public DALMobile()
        {
            _dalBaseEL = new DALBaseEL();
        }

        public LineStatus ConsultarStatus(String pNumeroLinha)
        {
            _dalBaseEL.GetDatabase("TAOL1_BCV");
            LineStatus _lineStatus;
            String _SQL = @"select distinct su.customer_id       as cliente,
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
                              and su.prim_resource_val="+pNumeroLinha;
            try
            {
                _dalBaseEL.OpenConnection();
                IDataReader _dataReader = _dalBaseEL.ExecuteReader(_SQL);
                if (_dataReader.Read())
                {
                    _lineStatus = new LineStatus();
                    _lineStatus.Cliente = _dataReader.GetString(0);
                    _lineStatus.Conta = _dataReader.GetString(1);
                    _lineStatus.Unidade_Org = _dataReader.GetString(2);
                    _lineStatus.MSISDN = _dataReader.GetString(3);
                    _lineStatus.SIM_Card = _dataReader.GetString(4);
                    _lineStatus.Tecnologia = _dataReader.GetString(5);
                    _lineStatus.Status = _dataReader.GetString(6);
                    _lineStatus.Data_de_Status = _dataReader.GetDateTime(7);
                    _lineStatus.Motivo_Acao = _dataReader.GetString(8);
                    _lineStatus.Razao_Social = _dataReader.GetString(9);
                    _lineStatus.CNPJ = _dataReader.GetString(10);
                }
                else
                {
                    _lineStatus = new LineStatus();
                }
            }
            finally
            {
                _dalBaseEL.CloseConnection();
            }

            return _lineStatus;
        }
    }
}
