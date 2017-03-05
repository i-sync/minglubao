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
    public partial class QuestionEdit : MLMGC.Security.EnterprisePage
    {
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取操作类型
            type = MLMGC.COMP.Requests.GetQueryString("type");
            if (!IsPostBack)
            {
                //初始化问题类型
                MLMGC.COMP.EnumUtil.BindList<EnumQuestionType>(rblQuestionType);
                rblQuestionType.SelectedIndex = 0;

                if (type == "update")
                {
                    int questionID = MLMGC.COMP.Requests.GetQueryInt("questionid", 0);
                    databind(questionID);
                }
            }
        }

        /// <summary>
        /// 如何是修改，则读取数据绑定
        /// </summary>
        /// <param name="questionID"></param>
        protected void databind(int questionID)
        {
            E_Question data = new E_Question();
            data.QuestionID = questionID;
            data.EnterpriseID = EnterpriceID;
            data = new T_Question().GetModel(data);
            if (data != null)
            {
                txtQuestionName.Text = data.QuestionName;
                rblQuestionType.SelectedValue = data.QuestionType.ToString();
                rpList.DataSource = data.QuestionItem;
                rpList.DataBind();
            }

            //加载与该问题相关的名录
            data = new E_Question();
            data.EnterpriseID = EnterpriceID;
            data.QuestionID = questionID;
            DataTable dt = new T_Question().ListSelect(data);
            lblClientNum.Text = dt.Rows.Count.ToString();
            rpClientInfo.DataSource = dt;
            rpClientInfo.DataBind();
        }

        /// <summary>
        /// 点击保存按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //判断标题是否输入
            string questionName = txtQuestionName.Text;
            if (questionName == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入标题", this);
                return;
            }
            //获取界面里所有隐藏域集合
            System.Collections.Specialized.NameValueCollection nv = Request.Form;
            string[] child_ItemIDs = nv.GetValues("hdQuestionItemIDs");
            string[] child_ItemNameS = nv.GetValues("hdQuestionItemNameS");
            if (child_ItemIDs == null || child_ItemNameS == null)
            {
                return;
            }
            if (child_ItemIDs.Length != child_ItemNameS.Length)
            {
                MLMGC.COMP.Jscript.ShowMsg("参数错误", this);
                return;
            }
            if (child_ItemIDs.Length == 0)
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入选项", this);
                return;
            }

            //封装数据
            E_Question data = new E_Question();
            data.EnterpriseID = EnterpriceID;
            data.QuestionName = questionName;
            data.Flag = cbDeleteRelation.Checked ? 1 : 0;
            data.QuestionType = Convert.ToInt32(rblQuestionType.SelectedValue);
            data.QuestionItem = new List<E_QuestionItem>();
            E_QuestionItem item = null;
            for (int i = 0; i < child_ItemIDs.Length; i++)
            {
                item = new E_QuestionItem();
                item.QuestionItemID = Convert.ToInt64(child_ItemIDs[i]);
                item.QuestionItemName = child_ItemNameS[i];
                data.QuestionItem.Add(item);
            }
            //判断是添加还是修改
            if (type == "add")
            {

                bool flag = new T_Question().Add(data);
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "添加问题", IP = MLMGC.COMP.Requests.GetRealIP() });
                if (flag)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "添加成功", "QuestionList.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("添加失败", this);
                }
            }
            else
            {
                //获取项目资料编号
                int questionID = MLMGC.COMP.Requests.GetQueryInt("questionid", 0);
                data.QuestionID = questionID;

                bool flag = new T_Question().Update(data);
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改问题", IP = MLMGC.COMP.Requests.GetRealIP() });
                if (flag)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "修改成功", "QuestionList.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
                }
            }
        }
    }
}