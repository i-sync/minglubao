using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Info
{
    public partial class StatusLog :MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定状态日志列表
        /// </summary>
        protected void databind()
        {
            rpList.DataSource = new T_ClientInfo().GetStatusList(new E_ClientInfo() { EnterpriseID = EnterpriceID, ClientInfoID = Requests.GetQueryInt("ciid", 0) });
            rpList.DataBind();
        }

        /// <summary>
        /// 显示名录操作状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-07</remarks>
        protected string OperateType(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return "";
            int i = Convert.ToInt32(obj);
            EnumOperateType type = (EnumOperateType)i;
            return type.ToString();
        }
    }
}