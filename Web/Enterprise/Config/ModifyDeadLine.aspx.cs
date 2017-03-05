using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Config
{
    public partial class ModifyDeadLine : MLMGC.Security.EnterprisePage
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
            //------绑定失败理由------
            ddlNotTraded.DataSource = new T_NotTraded().GetList(new E_NotTraded() { EnterpriseID = EnterpriceID });
            ddlNotTraded.DataTextField = "NotTradedName";
            ddlNotTraded.DataValueField = "NotTradedID";
            ddlNotTraded.DataBind();
            //读取期限数据
            E_TeamModel data = new E_TeamModel();
            data.EnterpriseID = EnterpriceID;
            data = new T_TeamModel().GetTeamScale(data);
            if (data != null)
            {
                txtLatenDay.Text = data.LatenDay.ToString();
                txtLRemindDay.Text = data.LRemindDay.ToString();
                txtWishDay.Text = data.WishDay.ToString();
                txtWRemindDay.Text = data.WRemindDay.ToString();
                ddlNotTraded.SelectedValue = data.NotTradedID.ToString();
            }
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int lday, lrday, wday, wrday;
            if (!int.TryParse(txtLatenDay.Text, out lday) || !int.TryParse(txtLRemindDay.Text, out lrday) || !int.TryParse(txtWishDay.Text, out wday) || !int.TryParse(txtWRemindDay.Text, out wrday))
            {
                Jscript.ShowMsg("请输入正确的数字", this);
                return;
            }
            if (lday > 999 || wday > 999)
            {
                Jscript.ShowMsg("设置天数最大为999，请重新设置", this);
                return;
            }
            //数据合法性
            if (lrday > 99 || wrday > 99)
            {
                Jscript.ShowMsg("提醒天数最大为99，请重新设置", this);
                return;
            }
            if ((lrday>0 && lday>0 && lrday >= lday) || (wrday>=wday && wrday>0 && wday>0))
            {
                Jscript.ShowMsg("提醒天数不能大于等于设置天数，请重新设置", this);
                return;
            }
            if (lrday < 0 || lday < 0 || wrday < 0 || wday < 0)
            {
                Jscript.ShowMsg("设置值不能为负数，请重新设置", this);
                return;
            }

            E_TeamModel data = new E_TeamModel();
            data.EnterpriseID = EnterpriceID;
            data.LatenDay = lday;
            data.LRemindDay = lrday;
            data.WishDay = wday;
            data.WRemindDay = wrday;
            data.NotTradedID = Convert.ToInt32(ddlNotTraded.SelectedValue);
            bool flag = new T_TeamModel().UpdateDeadLine(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "共享设置", IP = MLMGC.COMP.Requests.GetRealIP() });
            Jscript.ShowMsg(flag ? "修改成功" : "修改失败", this);
        }
    }
}