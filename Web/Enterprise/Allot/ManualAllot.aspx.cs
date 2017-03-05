using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Allot
{
    public partial class ManualAllot : MLMGC.Security.EnterprisePage
    {
        protected bool SettingFlag=false, TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        { 
            //获取该人员下面的直接下属
            rpList.DataSource = new T_Team().GetDirectMember(new E_Team { EnterpriseID = EnterpriceID, TeamID = TeamID });
            rpList.DataBind();

            //属性配置
            E_Property dataProperty = new T_Property().Get(new E_Property { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            //获取配置信息
            DataSet ds = new T_Allot().Select(new E_Allot() { EnterpriseID = EnterpriceID, TeamID = TeamID });
            if (ds == null || ds.Tables.Count != 5)
            {
                return;
            }
            SettingFlag = true;
        }
    }
}