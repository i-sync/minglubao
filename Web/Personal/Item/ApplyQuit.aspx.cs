using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.COMP;

namespace Web.Personal.Item
{
    public partial class ApplyQuit : MLMGC.Security.PersonalPage
    {
        protected int itemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            itemid = Requests.GetQueryInt("itemid", 0);
            if (itemid == 0)
            {
                return;
            }
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            //判断用户是否已经申请过退出,若申请过,不允许再申请
            bool flag = new T_ItemApply().Exists(new E_ItemApply() {ItemID = itemid,UserID = UserID,ApplyType = EnumApplyType.申请退出 });
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "你已经提交了退出申请,请耐心等待!", "itemlist.aspx");
            }
        }

        /// <summary>
        /// 提交退出申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string reason = txtReason.Text.Trim();
            if (string.IsNullOrEmpty(reason))
            {
                Jscript.ShowMsg("请输入退出理由!", this);
                return;
            }

            E_ItemApply data = new E_ItemApply();
            data.ItemID = itemid;
            data.UserID = UserID;
            data.ApplyType = EnumApplyType.申请退出;
            data.Reason = reason;

            bool flag = new T_ItemApply().Add(data);
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "申请成功", "itemlist.aspx");
            }
            else
            {
                Jscript.ShowMsg("申请失败", this);
            }
        }
    }
}