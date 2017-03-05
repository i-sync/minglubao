using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.WenKu;
using MLMGC.BLL.WenKu;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.COMP;

namespace Web.WenKu
{
    public partial class List : MLMGC.Security.PersonalPage
    {
        protected int pageIndex = 1, pageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
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
            //获取个人信息，判断他的信息是否完善，如果不完善，跳转到个人资料页面进行填写。
            E_Personal dataPersonal = new E_Personal();
            dataPersonal.UserID = UserID;
            dataPersonal.PersonalID = PersonalID;
            dataPersonal = new T_Personal().GetModel(dataPersonal);
            if (dataPersonal == null)
            {
                Response.Redirect("../main.aspx");
            }
            //判断资料是否完善
            if (!new T_Personal().IsPerfect(dataPersonal))
            {
                Jscript.AlertAndRedirect(this, "个人信息不完善", "/personal/modify.aspx");
                return;
            }

            //绑定文件类型
            EnumUtil.BindList<EnumFileType>(rdType);
            rdType.Items.RemoveAt(rdType.Items.Count - 1);//去掉最后一个其它
            //文库项目分类
            DataTable dt = new T_WenKuClass().GetList();
            //绑定目录分类
            ddlCategory.Items.Add(new ListItem("全部", "-1"));
            if (dt == null)
                return;
            foreach (DataRow row in dt.Rows)
            {
                ddlCategory.Items.Add(new ListItem(row["WenKuClassName"].ToString(), row["WenKuClassID"].ToString()));
            }
            ddlCategory.Items.Add(new ListItem("其它", "0"));


            //获取文库列表
            E_WenKu data = new E_WenKu ();
            //data.UserID = UserID;
            data.WenKuClassID = Requests.GetQueryInt("cid",-1);
            ddlCategory.SelectedValue = data.WenKuClassID.ToString();

            data.Keywords = Requests.GetQueryString("keywords");
            txtName.Text = data.Keywords;
            data.SetFileType = Requests.GetQueryInt("filetype",0);
            rdType.SelectedValue =((int)data.FileType).ToString ();
            data.SetStatusFlag = (int)EnumStatusFlag.审核通过且上线;

            data.Page = new MLMGC.DataEntity.E_Page ();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_WenKu().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 点击检索按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format("{0}?keywords={1}&cid={2}&filetype={3}", Request.Url.AbsolutePath, txtName.Text.Trim(), ddlCategory.SelectedValue, rdType.SelectedValue);
            Response.Redirect(url);
        }
    }
}
