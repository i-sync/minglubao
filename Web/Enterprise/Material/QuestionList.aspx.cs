using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.BLL.Enterprise.Material;
using MLMGC.DataEntity;

namespace Web.Enterprise.Material
{
    public partial class QuestionList : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = MLMGC.COMP.Requests.GetString("type").ToLower();
            pageIndex = MLMGC.COMP.Requests.GetQueryInt("page", 1);
            if (type == "delete")
            {
                int questionid = MLMGC.COMP.Requests.GetQueryInt("questionid", 0);
                Delete(questionid);
            }
            if (!IsPostBack)
            {
                databind(string .Empty);
            }            
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind(string questionName)
        {
            E_Question data = new E_Question();
            data.EnterpriseID = EnterpriceID;
            data.QuestionName = questionName;
            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_Question().GetList(data);
            rpList.DataBind();
            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="questionID"></param>
        protected void Delete(int questionID)
        {
            E_Question data = new E_Question();
            data.QuestionID = questionID;
            data.EnterpriseID = EnterpriceID;
            bool flag = new T_Question().Delete(data);
            if (flag)
            {
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "删除问题", IP = MLMGC.COMP.Requests.GetRealIP() });
                //MLMGC.COMP.Jscript.AlertAndRedirect(this, "删除成功", "MaterialList.aspx");
                MLMGC.COMP.Jscript.ShowMsg("删除成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("删除失败", this);
            }
        }

        /// <summary>
        /// 检索按钮点击处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string questionName = txtQuestionName.Text;
                        
            databind(questionName);
        }

        /// <summary>
        /// 获取问题类型
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public string GetQuestionType(object questionType)
        {
            return MLMGC.COMP.EnumUtil.GetName<EnumQuestionType>(Convert.ToInt32(questionType));
        }
    }
}