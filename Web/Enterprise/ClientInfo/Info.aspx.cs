using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using System.Collections.Generic;
using MLMGC.BLL.Enterprise.Material;

namespace Web.Enterprise.ClientInfo
{
    public partial class Info : MLMGC.Security.EnterprisePage
    {
        protected DataTable dtItem;
        protected bool IsShowExchange = true; //是否显示沟通记录，
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定页面数据
        /// </summary>
        protected void databind()
        {
            int ciid = Requests.GetQueryInt("ciid", 0);
            //-----------------绑定基本信息------------------------------
            E_ClientInfo data = new T_ClientInfo().GetModel(new E_ClientInfo() { EnterpriseID = EnterpriceID, ClientInfoID = ciid, EPUserTMRID = 0 });
            if (data == null)
            {
                Jscript.AlertAndRedirect(this, "信息不存在", "ClientInfoSearch.aspx");
                return;
            }
            ltClientName.Text = data.ClientName;
            ltAddress.Text = data.Address;
            ltZipCode.Text = data.ZipCode;
            ltLinkman.Text = data.Linkman;
            ltPosition.Text = data.Position;
            ltEmail.Text = data.Email;
            ltTel.Text = data.Tel;
            ltMobile.Text = data.Mobile;
            hlWebsite.NavigateUrl = data.Website.IndexOf("http://")==-1?"http://"+data.Website:data.Website;
            hlWebsite.Text = data.Website;
            ltFax.Text = data.Fax;
            ltRemark.Text = data.Remark;
            //-----------------绑定名录属性------------------------------
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;
            Property1.AreaID = data.AreaID;
            //-----------------绑定状态------------------------------
            ltStatus.Text = data.Status.ToString();
            //hdStatus.Value = ((int)data.Status).ToString();
            ////----------------绑定沟通记录---------------------
            //rpExchangeList.DataSource = new T_Exchange().GetList(new E_Exchange() { EnterpriseID = EnterpriceID, ClientItemID = ciid });
            //rpExchangeList.DataBind();
            //----------------调查问卷----------------
            DataSet ds = new T_Question().List(new MLMGC.DataEntity.Enterprise.Material.E_Question() { EnterpriseID = EnterpriceID, ClientInfoID = ciid });
            if (ds != null && ds.Tables.Count == 2)
            {
                dtItem = ds.Tables[1];
                rpList.DataSource = ds.Tables[0];
                rpList.DataBind();
            }

            //----------------获取当前用户角色信息----------------
            int roleid = new T_User().GetEPRoleID(new E_EnterpriseUser() {EnterpriseID=EnterpriceID, EPUserTMRID = EPUserTMRID });
            btnMyGet.Visible = (roleid == (int)EnumRole.销售人员);
            IsShowExchange = !(roleid == (int)EnumRole.销售人员);//销售人员不能查看沟通记录
        }

        /// <summary>
        /// repeater嵌套绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int qid = Convert.ToInt32((e.Item.DataItem as DataRowView)["QuestionID"]);
            Repeater rpList = e.Item.FindControl("rpItem") as Repeater;
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
        ///判断该问题的选项类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string SetType(object obj)
        {
            return Convert.ToInt32(obj) == 1 ? "radio" : "checkbox";
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
    }
}