using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise.Plan;
using MLMGC.BLL.Enterprise.Config;
using MLMGC.DataEntity.Enterprise.Plan;
using MLMGC.DataEntity.Enterprise.Config;

namespace Web.Enterprise.Plan
{
    public partial class TeamMonth : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            DateTime dtNow = DateTime.Now;
            ltStartDate.Text = new DateTime(dtNow.Year, dtNow.Month, 1).ToString("yyyy-MM-dd");
            ltEndDate.Text = new DateTime(dtNow.Year, dtNow.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            E_TeamPlan data = new E_TeamPlan();
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;
            data.TeamID = TeamID;
            data.YearMonty = dtNow;

            int planNew = 0, planContact = 0, planTrade = 0, realNew = 0, realContact = 0, realTrade = 0;
            float planMoney = 0f, realMoney = 0f;
            //获取团队计划
            E_TeamPlan dataPlan = new T_TeamPlan().GetModel(data);
            //planNew =Convert.ToInt32( row["PlanNew"] ?? 0);
            //planContact = Convert.ToInt32(row["PlanContact"] ?? 0);
            if (dataPlan != null)
            {
                planTrade = dataPlan.TradedAmount;
                planMoney = dataPlan.TradedMoney;
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
                planNew = planNew * DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
                planContact = planContact * DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
                ltPlanNew.Text = planNew.ToString ();
                ltPlanExchange.Text = planContact.ToString();
            }

            //获取实际数据
            DataTable dt = new T_TeamPlan().GetTeamRealMonth(data);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                realNew = Convert.ToInt32(row["RealNew"] ?? 0);
                realContact = Convert.ToInt32(row["RealContact"] ?? 0);
                realTrade = Convert.ToInt32(row["RealTrade"] ?? 0);
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
                ltStandardNew.Text = (dataStandard.NewAmount * DateTime.DaysInMonth(dtNow.Year, dtNow.Month)).ToString();
                ltStandardExchange.Text = (dataStandard.CommAmount * DateTime.DaysInMonth(dtNow.Year, dtNow.Month)).ToString();
                ltStandardTrade.Text = dataStandard.TradedAmount .ToString();
                ltStandardMoney.Text = dataStandard.TradedMoney .ToString("f2");
                //差值
                int num = (dataStandard.NewAmount * DateTime.DaysInMonth(dtNow.Year, dtNow.Month)) - realNew;
                ltDifferNew.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                num = (dataStandard.CommAmount * DateTime.DaysInMonth(dtNow.Year, dtNow.Month)) - realContact;
                ltDifferExchange.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                num = dataStandard.TradedAmount - realTrade;
                ltDifferTrade.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                float money = dataStandard.TradedMoney  - realMoney;
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
    }
}