using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise.Config;
using MLMGC.BLL.Enterprise.Config;
using MLMGC.DataEntity.Enterprise.Plan;
using MLMGC.BLL.Enterprise.Plan;
using MLMGC.COMP;
using System.Data;

namespace Web.Enterprise.Plan
{
    public partial class UserDaily : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                databind();
            }
        }

        protected void databind()
        {
            DateTime dtTime;
            if (!DateTime.TryParse(txtDate.Text, out dtTime))
            {
                MLMGC.COMP.Jscript.ShowMsg("日期错误", this);
                return;
            }
            if (dtTime > DateTime.Now)
            {
                MLMGC.COMP.Jscript.ShowMsg("不能超过今天", this);
                return;
            }
            phNoPlan.Visible = false;
            //获取指定月计划
            T_UserPlan bll = new T_UserPlan();
            E_UserPlan data = new E_UserPlan()
            {
                EnterpriseID = EnterpriceID,
                EPUserTMRID = EPUserTMRID,
                YearMonty = dtTime
            };
            E_UserPlan dataPlan = bll.GetModel(data);
            //获取最低指标
            E_Standard dataStandard = new T_Standard().GetModel(new E_Standard() { EnterpriseID = EnterpriceID });
            //获取当天数据
            DataTable dt = bll.UserDaily(data);
            int realNewAmount = 0, realExchAmount = 0;
            if (dt != null && dt.Rows.Count == 1)
            {
                realNewAmount = int.Parse(dt.Rows[0]["NewAmount"].ToString());
                realExchAmount = int.Parse(dt.Rows[0]["ExchangeAmount"].ToString());
            }
            ltRealNew.Text =realNewAmount.ToString();
            ltRealExchange.Text = realExchAmount.ToString();
            //---------设置显示月计划及百分比
            if (dataPlan != null)//是否制定该用计划
            {
                //实际数据
                ltPlanNew.Text = dataPlan.NewAmount.ToString();
                ltPlanExchange.Text = dataPlan.ContactAmount.ToString();
                //百分比数据
                ltPercentNew.Text = GetPercent(realNewAmount, data.NewAmount);
                ltPercentExchange.Text = GetPercent(realExchAmount, data.ContactAmount);
            }
            else
            {
                //计划数量
                phNoPlan.Visible = true;
                ltPlanNew.Text = "0";
                ltPlanExchange.Text = "0";
                //百分比
                ltPercentNew.Text = "0";
                ltPercentExchange.Text = "0";
            }
            //---------最低指标
            if (dataStandard != null)//领导是否调制最低指标
            {
                //指标
                ltStandardNew.Text = dataStandard.NewAmount.ToString();
                ltStandardExchange.Text = dataStandard.CommAmount.ToString();
                //差值
                int num = dataStandard.NewAmount - realNewAmount;
                ltDifferNew.Text = (num>0?"-":"+")+Math.Abs(num).ToString();
                num = dataStandard.CommAmount - realExchAmount;
                ltDifferExchange.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
            }
            else
            {
                //指标
                ltStandardNew.Text = "0";
                ltStandardExchange.Text = "0";
                //差值
                ltDifferNew.Text = "0";
                ltDifferExchange.Text = "0";
            }
        }

        protected string GetPercent(float num1, float num2)
        {
            if (num1>0 && num2>0)
            {
                return (num1 / num2 * 100).ToString("F2");
            }
            return "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            databind();
        }
    }
}