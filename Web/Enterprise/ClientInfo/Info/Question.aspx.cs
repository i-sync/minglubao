using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using System.Data;
using MLMGC.BLL.Enterprise.Material;
using MLMGC.DataEntity.Enterprise.Material;

namespace Web.Enterprise.Info
{
    public partial class Question :MLMGC.Security.EnterprisePage
    {
        protected DataTable dtItem;
        protected int clientinfoid;
        protected bool flag =true;
        protected bool hide = false;//如果没有调查问卷，则就隐藏提交按钮，默认显示。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Requests.GetQueryString("btn") == "hide")
            {
                flag = false;                
            }
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
            clientinfoid = Requests.GetQueryInt("ciid", 0);
            E_Question data = new E_Question();
            data.EnterpriseID = EnterpriceID;
            data.ClientInfoID = clientinfoid;

            DataSet ds = new T_Question().List(data);
            if(ds!= null && ds.Tables.Count ==2)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    hide = true;
                }
                dtItem = ds.Tables[1];
                rpList.DataSource = ds.Tables[0];
                rpList.DataBind();                
            }
        }

        /// <summary>
        /// 判断当前选项是否选中
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string Check(object obj)
        {
            return Convert.ToInt32(obj) != 0 ? "checked='checked'" : "";
        }
        /// <summary>
        ///判断该问题的选项类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string SetType(object obj)
        {
            return Convert.ToInt32(obj) == 1 ? "radio" : "checkbox";
        }

        /// <summary>
        /// repeater嵌套绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int qid = Convert.ToInt32((e.Item.DataItem as DataRowView)["QuestionID"]);
            Repeater rpList  =e.Item.FindControl("rpItem") as Repeater;
            int type = Convert.ToInt32((e.Item.DataItem as DataRowView)["QuestionType"]);

            //var v = from a in dtItem.Select("QuestionID =" + qid) select new { QuestionID = a["QuestionID"],QuestionItemID = a["QuestionItemID"], QuestionItemName = a["QuestionItemName"], Flag = a["Flag"] };

            IEnumerable<System.Data.DataRow> queryItem =
                from item in dtItem.AsEnumerable()
                where item.Field<int>("QuestionID") == qid
                select item;

            rpList.DataSource = queryItem.CopyToDataTable<DataRow>();
            rpList.DataBind();
        }

        /// <summary>
        /// 标识选项是否为用
        /// </summary>
        /// <returns></returns>
        protected string Enable()
        {
            if (!flag)
                return " disabled ='disabled'";
            return "";
        }
    }
}