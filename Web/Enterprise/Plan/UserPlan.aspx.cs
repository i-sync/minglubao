using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise.Plan;
using MLMGC.BLL.Enterprise.Plan;

namespace Web.Enterprise.Plan
{
    public partial class UserPlan : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblYearMonth.Text = DateTime.Now.ToString("yyyy-MM");
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
            E_UserPlan data = new E_UserPlan();
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;
            data.YearMonty = DateTime.Now;
            data = new T_UserPlan().GetModel(data);
            if (data == null)
                return;
            txtNewAmount.Text = data.NewAmount.ToString();
            txtContactAmount.Text = data.ContactAmount.ToString();
            txtTradedAmount.Text = data.TradedAmount.ToString();
            txtTradedMoney.Text = data.TradedMoney.ToString("F2");
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblYearMonth.Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请选择年月", this);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtNewAmount .Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入每日新增名录数", this);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtTradedMoney.Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入每日沟通名录数", this);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtTradedAmount.Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入交易数量", this);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtTradedMoney.Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入交易金额", this);
                return;
            }

            E_UserPlan data = new E_UserPlan();
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;
            data.NewAmount = Convert.ToInt32(txtNewAmount.Text);
            data.ContactAmount = Convert.ToInt32(txtContactAmount.Text);
            data.YearMonty = Convert.ToDateTime(lblYearMonth.Text);
            data.TradedAmount = Convert.ToInt32(txtTradedAmount.Text);
            data.TradedMoney = Convert.ToSingle(txtTradedMoney.Text);

            bool flag = new T_UserPlan().Update(data);
            if (flag)
            {
                //添加操作日志
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "管理计划", IP = MLMGC.COMP.Requests.GetRealIP() });
                MLMGC.COMP.Jscript.ShowMsg("操作成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("操作失败", this);
            }
        }
    }
}