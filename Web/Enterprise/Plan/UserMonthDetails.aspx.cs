using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using System.Data;
using MLMGC.DataEntity.Enterprise.Plan;
using MLMGC.BLL.Enterprise.Plan;
using MLMGC.DataEntity.Enterprise.Config;
using MLMGC.BLL.Enterprise.Config;

namespace Web.Enterprise.Plan
{
    public partial class UserMonthDetails :MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime yearmonth = Convert.ToDateTime(Requests.GetQueryString("planid")+"/01");
                ltYearMonth.Text = yearmonth.ToString("yyyy年MM月", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                databind(yearmonth);
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind(DateTime yearmonth)
        {
            E_UserPlan data = new E_UserPlan();
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;
            data.YearMonty = yearmonth;

            //获取该月的天数
            int dayNum = DateTime.DaysInMonth(yearmonth.Year, yearmonth.Month);
            
            DataTable dt = new T_UserPlan().UserMonthDetail(data);
            int planNew = 0, realNew = 0, planContact = 0, realContact = 0, planTrade = 0, realTrade = 0;
            float planMoney = 0f, realMoney = 0f;
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                planNew = Convert .ToInt32(row["NewAmount"]);
                ltPlanNew.Text = (planNew*dayNum).ToString();
                planContact = Convert.ToInt32(row["ContactAmount"]);
                ltPlanContact.Text =(planContact*dayNum) .ToString();
                planTrade = Convert.ToInt32(row["TradedAmount"]);
                ltPlanTrade.Text = planTrade.ToString();
                planMoney = Convert.ToSingle(row["TradedMoney"]);
                ltPlanMoney.Text = planMoney.ToString("f2");

                realNew  = Convert.ToInt32(row["RealNewAmount"]);
                ltRealNew.Text =realNew .ToString();
                realContact = Convert.ToInt32(row["RealExchAmount"]);
                ltRealContact.Text = realContact.ToString();
                realTrade = Convert.ToInt32(row["RealTradedAmount"]);
                ltRealTrade.Text = realTrade.ToString();
                realMoney = Convert.ToSingle(row["RealTradedMoney"]);
                ltRealMoney.Text =realMoney .ToString("f2");

                //---------设置显示月计划及百分比
                ltPercentNew.Text = GetPercent(realNew, planNew*dayNum);
                ltPercentContact.Text = GetPercent(realContact, planContact*dayNum);
                ltPercentTrade.Text = GetPercent(realTrade, planTrade);
                ltPercentMoney.Text = GetPercent(realMoney, planMoney);
            }

            //获取最低指标
            E_Standard dataStandard = new T_Standard().GetModel(new E_Standard() { EnterpriseID = EnterpriceID });
            //---------最低指标
            if (dataStandard != null)//领导是否调制最低指标
            {
                //指标
                ltStandardNew.Text = dataStandard.NewAmount.ToString();
                ltStandardContact.Text = dataStandard.CommAmount.ToString();
                ltStandardTrade.Text = dataStandard.TradedAmount.ToString();
                ltStandardMoney.Text = dataStandard.TradedMoney.ToString("f2");
                //差值
                int num = dataStandard.NewAmount - realNew;
                ltDifferNew.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                num = dataStandard.CommAmount - realContact;
                ltDifferContact.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                num = dataStandard.TradedAmount - realTrade;
                ltDifferTrade.Text = (num > 0 ? "-" : "+") + Math.Abs(num).ToString();
                float money = dataStandard.TradedMoney - realMoney;
                ltDifferMoney.Text = (money > 0 ? "-" : "+") + Math.Abs(money).ToString("f2");
            }
            else
            {
                //指标
                ltStandardNew.Text = "0";
                ltStandardContact.Text = "0";
                ltStandardTrade.Text = "0";
                ltStandardMoney.Text = "0.00";
                //差值
                ltDifferNew.Text = "0";
                ltDifferContact.Text = "0";
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