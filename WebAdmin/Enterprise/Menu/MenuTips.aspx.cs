using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace WebAdmin.Enterprise.Menu
{
    public partial class MenuTips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        public void databind()
        {
            int menuid = Requests.GetQueryInt("menuid", 0);
            string menuname = Requests.GetQueryString("menuname");
            ltMenuName.Text = menuname;
            E_Menu data = new E_Menu();
            data.MenuID = menuid;
            DataTable dt = new T_Menu().GetMenuTipsList(data);
            rpList.DataSource = dt;
            rpList.DataBind();
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int menuid = Requests.GetQueryInt("menuid", 0);
            //获取界面里所有隐藏域集合
            System.Collections.Specialized.NameValueCollection nv = Request.Form;
            string[] TipsIDs = nv.GetValues("hdTipsIDs");
            string[] TipsNameS = nv.GetValues("hdTipsNameS");
            string ids= string.Empty, names= string.Empty;
            if (TipsIDs != null || TipsNameS != null)
            {
                if (TipsIDs.Length != TipsNameS.Length)
                {
                    MLMGC.COMP.Jscript.ShowMsg("参数错误", this);
                    return;
                }
                if (TipsIDs.Length == 0)
                {
                    MLMGC.COMP.Jscript.ShowMsg("请输入选项", this);
                    return;
                }
                
                for (int i = 0; i < TipsIDs.Length; i++)
                {
                    ids += TipsIDs[i] + (i != TipsIDs.Length - 1 ? MLMGC.COMP.Config.Separation : "");
                    names += TipsNameS[i] + (i != TipsIDs.Length - 1 ? MLMGC.COMP.Config.Separation : "");
                }
            }

            E_Menu data = new E_Menu();
            data.MenuID = menuid;
            data.TipsIDs = ids;
            data.TipsNameS = names;

            bool flag = new T_Menu().UpdateMenuTips(data);
            if (flag)
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "操作成功", "MenuList.aspx");
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("操作失败", this);
            }
            
        }
    }
}