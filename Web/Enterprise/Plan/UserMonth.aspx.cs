using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise.Plan;
using MLMGC.BLL.Enterprise.Plan;

namespace Web.Enterprise.Plan
{
    public partial class UserMonth :MLMGC.Security.EnterprisePage
    {
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
            E_UserPlan data = new E_UserPlan();
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID ;

            rpList.DataSource = new T_UserPlan().UserMonth(data);
            rpList.DataBind();
        }

        /// <summary>
        /// 计算该月的计划总数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetMonthPlan(object objMonth,object objPlan)
        {
            DateTime date = Convert.ToDateTime(objMonth);
            int dayNum = DateTime.DaysInMonth(date.Year, date.Month);
            int plan = Convert.ToInt32(objPlan);
            return (plan * dayNum).ToString();
        }
    }
}