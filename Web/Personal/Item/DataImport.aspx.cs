using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.COMP;
using System.Data;

namespace Web.Personal.Item
{
    public partial class DataImport : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断用户是否加入了项目，或者该企业项目是否开通
            IsJoin();

            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void databind()
        {
            //源
            EnumUtil.BindList<EnumClientStatus>(rbPISStatus);
            //删除共享状态
            rbPISStatus.Items.RemoveAt(0);
            rbPISStatus.Items.RemoveAt(rbPISStatus.Items.Count - 2);
            rbPISStatus.SelectedIndex = 0;
            
            //目标
            rbPITStatus.Items.Add(new ListItem(EnumClientStatus.潜在客户.ToString (),((int)EnumClientStatus.潜在客户).ToString()));
            rbPITStatus.SelectedIndex = 0;
            
            //---------------------------------------------------------
            //源
            EnumUtil.BindList<EnumClientStatus>(rbIPSStatus);
            //删除共享状态
            rbIPSStatus.Items.RemoveAt(0);
            rbIPSStatus.Items.RemoveAt(rbIPSStatus.Items.Count - 2);
            rbIPSStatus.SelectedIndex = 0;
            
            //目标
            rbIPTStatus.Items.Add(new ListItem(EnumClientStatus.潜在客户.ToString(), ((int)EnumClientStatus.潜在客户).ToString()));
            rbIPTStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// 个人名录－－》项目名录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPISwitch_Click(object sender, EventArgs e)
        {
            //获取导入数量
            int num;
            if(!int.TryParse(txtTotalCount.Text.Trim(),out num))
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
            data.EnterpriseID = EnterpriseID;
            data.UserID = UserID;
            data.PersonalID = PersonalID;
            data.SetStatus = Convert.ToInt32(rbPISStatus.SelectedValue);
            data.SetTarStatus = Convert.ToInt32(rbPITStatus.SelectedValue);
            data.TotalCount = num;
            data.IsExchange = cbPIExchange.Checked ? 1 : 0;

            DataTable dt = new T_ItemClientInfo().ImportData_PI(data);
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
        /// 项目名录－－》个人名录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIPSwitch_Click(object sender, EventArgs e)
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
            data.EnterpriseID = EnterpriseID;
            data.UserID = UserID;
            data.PersonalID = PersonalID;
            data.SetStatus = Convert.ToInt32(rbIPSStatus.SelectedValue);
            data.SetTarStatus = Convert.ToInt32(rbIPTStatus.SelectedValue);
            data.TotalCount = num;
            data.IsExchange = cbIPExchange.Checked ? 1 : 0;

            DataTable dt = new T_ItemClientInfo().ImportData_IP(data);
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