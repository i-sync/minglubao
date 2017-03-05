using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise.Config;
using MLMGC.BLL.Enterprise.Config;

namespace Web.Enterprise.Config
{
    public partial class Standard : MLMGC.Security.EnterprisePage
    {
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            E_Standard data = new E_Standard();
            data.EnterpriseID = EnterpriceID;
            data = new T_Standard().GetModel(data);
            if (data == null)
                return;
            txtNewAmount.Text = data.NewAmount.ToString();
            txtCommAmount.Text = data.CommAmount.ToString();
            txtTradedAmount.Text = data.TradedAmount.ToString();
            txtTradedMoney.Text = data.TradedMoney.ToString("f2");
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string newAmount = txtNewAmount.Text ;
            string commAmount =txtCommAmount.Text;
            string tradeAmount= txtTradedAmount.Text;
            string tradeMoney= txtTradedMoney.Text;
            if(newAmount==""||commAmount==""||tradeAmount==""||tradeMoney=="")
            {
                MLMGC.COMP.Jscript.ShowMsg("请认真填写以上内容",this);
                return;
            }
            E_Standard data = new E_Standard();
            data.EnterpriseID = EnterpriceID;
            data.NewAmount = Convert.ToInt32(newAmount);
            data.CommAmount = Convert.ToInt32(commAmount);
            data.TradedAmount = Convert.ToInt32(tradeAmount);
            data.TradedMoney = Convert.ToSingle(tradeMoney);
            bool flag = new T_Standard().Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "最低标准设置", IP = MLMGC.COMP.Requests.GetRealIP() });
            if (flag)
            {
                MLMGC.COMP.Jscript.ShowMsg("操作成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("操作失败", this);
            }
        }
    }
}