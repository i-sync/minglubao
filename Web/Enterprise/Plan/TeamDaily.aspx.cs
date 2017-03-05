using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise.Plan;
using MLMGC.BLL.Enterprise.Config;
using MLMGC.DataEntity.Enterprise.Plan;
using MLMGC.DataEntity.Enterprise.Config;

namespace Web.Enterprise.Plan
{
    public partial class TeamDaily : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                databind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
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


            E_TeamPlan data = new E_TeamPlan();
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;
            data.TeamID = TeamID;
            data.YearMonty = dtTime;

            int planNew = 0, planContact = 0, planTrade = 0, realNew = 0, realContact = 0, realTrade = 0;
            float planMoney = 0f, realMoney = 0f;
            //获取团队计划
            E_TeamPlan dataPlan = new T_TeamPlan().GetModel(data);
            //planNew =Convert.ToInt32( row["PlanNew"] ?? 0);
            //planContact = Convert.ToInt32(row["PlanContact"] ?? 0);
            if (dataPlan != null)
            {
                planTrade = dataPlan.TradedAmount / DateTime.DaysInMonth(dtTime.Year, dtTime.Month);
                planMoney = dataPlan.TradedMoney / DateTime.DaysInMonth(dtTime.Year, dtTime.Month);
            }
            //ltPlanNew.Text = planNew.ToString();
            //ltPlanExchange.Text = planContact.ToString();
            ltPlanTrade.Text = planTrade.ToString();
            ltPlanMoney.Text = planMoney.ToString("f2");

            //获取总监下业务个人计划列表
            DataTable dtDetail = new T_TeamPlan().GetTeamPlan(data);
            rpList.DataSource = dtDetail;
            rpList.DataBind();
            if (dtDetail != null)
            {
                foreach (DataRow r in dtDetail.Rows)
                {
                    planNew += Convert.ToInt32(r["NewAmount"] == DBNull.Value ? 0 : r["NewAmount"]);
                    planContact += Convert.ToInt32(r["ContactAmount"] == DBNull.Value ? 0 : r["ContactAmount"]);
                }
                ltPlanNew.Text = planNew.ToString();
                ltPlanExchange.Text = planContact.ToString();
            }

            //获取实际数据
            DataTable dt = new T_TeamPlan().GetTeamReal(data);            
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];                
                realNew = Convert.ToInt32(row["RealNew"] ==DBNull.Value? 0:row["RealNew"]);
                realContact = Convert.ToInt32(row["RealContact"]==DBNull.Value ? 0:row["RealContact"]);
                realTrade = Convert.ToInt32(row["RealTrade"] ==DBNull.Value? 0:row["RealTrade"]);
                realMoney = Convert.ToSingle(row["RealMoney"] == DBNull.Value ? 0f : row["RealMoney"]);
            }

            ltRealNew.Text = realNew.ToString();
            ltRealExchange.Text = realContact.ToString();
            ltRealTrade.Text = realTrade.ToString();
            ltRealMoney.Text = realMoney.ToString("f2");

            //---------设置显示月计划及百分比
            ltPercentNew.Text = GetPercent(realNew, planNew);
            ltPercentExchange.Text = GetPercent(realContact, planContact);
            ltPercentTrade.Text = GetPercent(realTrade, planTrade);
            ltPercentMoney.Text = GetPercent(realMoney, planMoney);

            //获取最低指标
            E_Standard dataStandard = new T_Standard().GetModel(new E_Standard() { EnterpriseID = EnterpriceID });
            //---------最低指标
            if (dataStandard != null)//领导是否调制最低指标
            {
                //指标
                ltStandardNew.Text = dataStandard.NewAmount.ToString();
                ltStandardExchange.Text = dataStandard.CommAmount.ToString();
                ltStandardTrade.Text = (dataStandard.TradedAmount/DateTime.DaysInMonth(dtTime.Year,dtTime.Month)).ToString();
                ltStandardMoney.Text = (dataStandard.TradedMoney / DateTime.DaysInMonth(dtTime.Year, dtTime.Month)).ToString("f2");
                //差值
                int num = dataStandard.NewAmount - realNew;
                ltDifferNew.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                num = dataStandard.CommAmount - realContact;
                ltDifferExchange.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                num = dataStandard.TradedAmount / DateTime.DaysInMonth(dtTime.Year, dtTime.Month) - realTrade;
                ltDifferTrade.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                float money = dataStandard.TradedMoney/DateTime.DaysInMonth(dtTime.Year, dtTime.Month) - realMoney;
                ltDifferMoney.Text = (money > 0 ? "-" : "+") + Math.Abs(money).ToString("f2");
            }
            else
            {
                //指标
                ltStandardNew.Text = "0";
                ltStandardExchange.Text = "0";
                ltStandardTrade.Text = "0";
                ltStandardMoney.Text = "0.00";
                //差值
                ltDifferNew.Text = "0";
                ltDifferExchange.Text = "0";
                ltDifferTrade.Text = "0";
                ltDifferMoney.Text = "0.00";
            }
        }

        protected string GetPercent(float num1, float num2)
        {
            if (num1 > 0 && num2 > 0)
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