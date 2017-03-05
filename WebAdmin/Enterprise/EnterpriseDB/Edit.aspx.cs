using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace WebAdmin.Enterprise.EnterpriseDB
{
    public partial class Edit : System.Web.UI.Page
    {
        private int dbid;
        private string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbid = Requests.GetQueryInt("dbid", 0);
            type = Requests.GetQueryString("type");
            if (!IsPostBack)
            {
                if (type == "update")
                {
                    databind();
                }
                else
                {
                    NextName();
                }
            }
        }

        /// <summary>
        /// 显示数据库名称
        /// </summary>
        protected void NextName()
        {
            txtDBName.Text = new T_EnterpriseDB().NextName();            
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {
            E_EnterpriseDB data = new E_EnterpriseDB();
            data.EnterpriseDBID = dbid;

            data = new T_EnterpriseDB().GetModel(data);
            if (data == null)
            {
                Jscript.AlertAndRedirect(this, "没有找到对象！", "List.aspx");
                return;
            }
            txtDBName.Text = data.DBName;
            txtMaxNum.Text = data.MaxNum.ToString();
        }
                
        /// <summary>
        /// 点击确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //获取界面数据
            string name = txtDBName.Text.Trim();
            //获取界面数据
            int num;
            if (!int.TryParse(txtMaxNum.Text.Trim(), out num))
            {
                Jscript.ShowMsg("参数错误", this);
                return;
            }

            E_EnterpriseDB data = new E_EnterpriseDB();
            data.DBName = name;
            data.MaxNum = num;

            bool flag = false;
            if (type == "update")
            {
                data.EnterpriseDBID = dbid;
                flag = new T_EnterpriseDB().UpdateMaxNum(data);
            }
            else
            {
                //获取数据库文件存放位置
                data.Path = Config.GetAppSettings("DBFilePath");
                if (string.IsNullOrEmpty(data.Path))
                {
                    Jscript.ShowMsg("配置文件错误，没有找到DBFilePath", this);
                    return;
                }
                flag = new T_EnterpriseDB().Add(data);
            }

            if (flag)
            {
                Jscript.AlertAndRedirect(this, "操作成功", "list.aspx");
            }
            else
            {
                Jscript.ShowMsg("操作失败", this);
            }
        }
    }
}