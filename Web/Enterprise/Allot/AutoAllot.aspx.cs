using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using System.Data;

namespace Web.Enterprise.Allot
{
    public partial class AutoAllot : MLMGC.Security.EnterprisePage
    {
        protected bool SettingFlag=false,TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            //获取待分配名录数量
            E_ClientInfo data=new E_ClientInfo();
            data.EnterpriseID=EnterpriceID;
            data.TeamID=TeamID;
            data.Mode=EnumClientMode.团队;
            data.Status=EnumClientStatus.待分配名录;
            int count = new T_ClientInfo().WaitCount(data);
            ltSumAmount.Text = count.ToString();
            txtAllotAmount.Attributes.Add("maxNum", count.ToString());
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
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

            //----------读取自行分配配置信息---------------
            E_Allot config = new T_Allot().GetModelConfig(new E_Allot() { EnterpriseID = EnterpriceID, TeamID = TeamID });
            if (config != null)
            {
                rblEnabledState.SelectedValue = config.Available.ToString();
                txtAllotAmount.Text = config.AllotAmount.ToString();
                txtDay.Text = config.Cycle.ToString();
                if (config.AllotTime != null && config.AllotTime.IndexOf(":") > -1)
                {
                    txtHour.Text = config.AllotTime.Substring(0, 2);
                    txtMinute.Text = config.AllotTime.Substring(3, 2);
                }
                lbCurExecDate.Text = config.LastDate == null ? "----" :string.Format("{0:yyyy-MM-dd HH:mm:ss}", config.LastDate);
                lbNextDate.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", config.NextDate);

                //排序方式 
                if (config.AllotSort == "asc")
                    rdOrderbyAsc.Checked = true;
                else
                    rdOrderbyDesc.Checked = true;

                //分配类型
                switch (config.Mode)
                { 
                    case EnumMode.平均分配:
                        cbTypeAvg.Checked = true;
                        break;
                    case EnumMode.补差分配:
                        if(SettingFlag)
                            cbTypeMakeup.Checked = true;
                        break;
                    case EnumMode.行业分配:
                        if(SettingFlag && TradeFlag)
                            cbTypeTrade.Checked = true;
                        break;
                    case EnumMode.地区分配:
                        if (SettingFlag && AreaFlag)
                            cbTypeArea.Checked = true;
                        break;
                    case EnumMode.来源分配:
                        if (SettingFlag && SourceFlag)
                            cbTypeSource.Checked = true;
                        break;
                }
            }
        }

        /// <summary>
        /// 点击保存按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        { 
            //获取界面数据
            string amount = txtAllotAmount.Text;
            string cycle = txtDay.Text;
            string hour = txtHour.Text.Trim();
            string minute = txtMinute.Text.Trim();
            if (string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(cycle) || Convert.ToInt32(amount) <= 0 || Convert.ToInt32(cycle) > 200 && Convert.ToInt32(cycle) <= 0 || Convert.ToInt32(hour) > 23 && Convert.ToInt32(hour) < 0 || Convert.ToInt32(minute) > 59 && Convert.ToInt32(minute) < 0)
            {
                MLMGC.COMP.Jscript.ShowMsg("输入有误，请重新输入", this);
                return;
            }
            E_Allot data = new E_Allot();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.Available = Convert.ToInt32(rblEnabledState.SelectedValue);
            data.AllotAmount = Convert.ToInt32(amount);
            data.AllotSort = rdOrderbyAsc.Checked ? "asc" : "desc";
            data.SetMode = cbTypeAvg.Checked ? 2 : (cbTypeMakeup.Checked ? 3 : (cbTypeTrade.Checked ? 4 : (cbTypeArea.Checked ? 5 : 6)));
            data.Cycle = Convert.ToInt32(cycle);
            data.AllotTime = string.Format("{0}:{1}", hour.Length == 1 ? string.Format("0{0}", hour) : hour, minute.Length == 1 ? string.Format("0{0}", minute) : minute);

            bool flag = new T_Allot().UpdateAutoConfig(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改自动分配设置", IP = MLMGC.COMP.Requests.GetRealIP() });
            if (flag)
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "保存成功", "AutoAllot.aspx");
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("保存失败", this);
            }
        }
    }
}