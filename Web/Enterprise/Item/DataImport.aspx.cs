using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;

namespace Web.Enterprise.Item
{
    public partial class DataImport : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否有权限操作
            isPermission();

            if (!IsPostBack)
            { databind(); }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void databind()
        {
            //源
            EnumUtil.BindList<EnumClientStatus>(rbEISStatus);
            rbEISStatus.SelectedIndex = 0;

            //目标           
            rbEITStatus.Items.Add(new ListItem(EnumClientStatus.共享.ToString(), ((int)EnumClientStatus.共享).ToString()));
            rbEITStatus.SelectedIndex = 0;

            //---------------------------------------------------------
            //源
            EnumUtil.BindList<EnumClientStatus>(rbIESStatus);
            rbIESStatus.Items.RemoveAt(0);
            rbIESStatus.SelectedIndex = 0;

            //目标
            rbIETStatus.Items.Add(new ListItem(EnumClientStatus.待分配名录.ToString(), ((int)EnumClientStatus.待分配名录).ToString()));
            rbIETStatus.Items.Add(new ListItem(EnumClientStatus.共享.ToString(), ((int)EnumClientStatus.共享).ToString()));
            rbIETStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// 企业名录－－》项目名录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEISwitch_Click(object sender, EventArgs e)
        {
            //获取导入数量
            int num;
            if (!int.TryParse(txtTotalCount.Text.Trim(), out num))
            {
                Jscript.ShowMsg("请输入正确的整数", this);
                return;
            }
            if (num < 0 || num > 2000)
            {
                Jscript.ShowMsg("请输入1-2000的整数", this);
                return;
            }
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.SetStatus = Convert.ToInt32(rbEISStatus.SelectedValue);
            data.SetTarStatus = Convert.ToInt32(rbEITStatus.SelectedValue);
            data.TotalCount = num;
            data.IsExchange = cbEIExchange.Checked ? 1 : 0;

            DataTable dt = new T_ItemClientInfo().ImportData_EI(data);
            string result = string.Empty;
            if (dt.Rows[0]["Flag"].ToString().Equals("1"))
            {
                result = string.Format("<span style=\"color:Green;\"> 本次结果：<br/>总数：{0}<span style=\"margin:10px\"> </span>重复：{1}<span style=\"margin:10px\"> </span>导入：{2}</span>", dt.Rows[0]["Total"], dt.Rows[0]["Repeat"], dt.Rows[0]["Num"]);
            }
            else
            {
                result = "<span style=\"color:Red;\">导入失败</span>";
            }
            lblResult.Text = result;
        }

        /// <summary>
        /// 项目名录－－》企业名录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIESwitch_Click(object sender, EventArgs e)
        {
            //获取导入数量
            int num;
            if (!int.TryParse(txtTotalCount.Text.Trim(), out num))
            {
                Jscript.ShowMsg("请输入正确的整数", this);
                return;
            }
            if (num < 0 || num > 2000)
            {
                Jscript.ShowMsg("请输入1-2000的整数", this);
                return;
            }
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.UserID = UserID;
            data.EPUserMTRID = EPUserTMRID;
            data.TeamID = TeamID;
            data.SetStatus = Convert.ToInt32(rbIESStatus.SelectedValue);
            data.SetTarStatus = Convert.ToInt32(rbIETStatus.SelectedValue);
            data.TotalCount = num ;
            data.IsExchange = cbIEExchange.Checked ? 1 : 0;

            DataTable dt = new T_ItemClientInfo().ImportData_IE(data);
            string result = string.Empty;
            if (dt.Rows[0]["Flag"].ToString().Equals("1"))
            {
                result = string.Format("<span style=\"color:Green;\"> 本次结果：<br/>总数：{0}<span style=\"margin:10px\"> </span>重复：{1}<span style=\"margin:10px\"> </span>导入：{2}</span>", dt.Rows[0]["Total"], dt.Rows[0]["Repeat"], dt.Rows[0]["Num"]);
            }
            else
            {
                result = "<span style=\"color:Red;\">导入失败</span>";
            }
            lblResult.Text = result;
        }
    }
}