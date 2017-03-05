using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise
{
    public partial class TeamMap : MLMGC.Security.EnterprisePage
    {
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            ds = new T_TeamModel().GetEnterpriseMap(new E_TeamModel()
            {
                EnterpriseID = EnterpriceID
            });
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count ==0 ) { return; }

            IEnumerable<System.Data.DataRow> queryItem =
                from item in ds.Tables[0].AsEnumerable()
                where item.Field<int>("TMRPID") == 0 || item.Field<int>("PID") == 0
                select item;

            rpList.DataSource = queryItem.CopyToDataTable<DataRow>();
            rpList.DataBind();
        }

        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (ds == null || ds.Tables.Count < 2) { return; }
            int teamid = 0, teamtype = 0;
            teamid = Convert.ToInt32((e.Item.DataItem as DataRowView)["TeamID"]);
            teamtype = Convert.ToInt32((e.Item.DataItem as DataRowView)["TeamType"]);
            PlaceHolder ph = e.Item.FindControl("ph") as PlaceHolder;
            ph.Controls.Add(CreateRepeater(teamid, teamtype));
        }

        /// <summary>
        /// 创建Repeater
        /// </summary>
        /// <param name="TeamID">当前 TeamID</param>
        /// <param name="TeamType">TeamType</param>
        protected Repeater CreateRepeater(int TeamID, int TeamType)
        {
            if (TeamID == 0 || TeamType == 3) { return null; }
            Repeater rp = new Repeater();

            if (TeamType == 1)//有子团队
            {
                IEnumerable<System.Data.DataRow> queryItem =
                   from item in ds.Tables[0].AsEnumerable()
                   where item.Field<int>("PID") == TeamID
                   orderby item.Field<int>("TeamID")
                   select item;
                rp.AlternatingItemTemplate = rp.ItemTemplate = new MyTemplate(ListItemType.Item);
                rp.FooterTemplate = new MyTemplate(ListItemType.Footer);
                rp.ItemDataBound += Child_ItemDataBound;
                if (queryItem.Count() > 0)
                {
                    rp.DataSource = queryItem.CopyToDataTable<DataRow>();
                    rp.DataBind();
                }
            }
            else
            {
                rp.AlternatingItemTemplate = rp.ItemTemplate = new MyTemplate(ListItemType.Item, false);
                IEnumerable<System.Data.DataRow> queryItemUser =
                   from item in ds.Tables[1].AsEnumerable()
                   where item.Field<int>("TeamID") == TeamID
                   select item;
                if (queryItemUser.Count() > 0)
                {
                    rp.DataSource = queryItemUser.CopyToDataTable<DataRow>();
                    rp.DataBind();
                }
            }
            return rp;
        }
        /// <summary>
        /// 子项绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Child_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer || e.Item.ItemType == ListItemType.Header)
            {
                return;
            }
            int teamid = 0, teamtype = 0;
            teamid = Convert.ToInt32((e.Item.DataItem as DataRowView)["TeamID"]);
            teamtype = Convert.ToInt32((e.Item.DataItem as DataRowView)["TeamType"]);
            PlaceHolder ph = e.Item.FindControl("ph") as PlaceHolder;
            if (ph != null)
            {
                ph.Controls.Add(CreateRepeater(teamid, teamtype));
            }
        }
    }
    /// <summary>
    /// 自定义模板项
    /// </summary>
    public class MyTemplate : System.Web.UI.ITemplate
    {
        System.Web.UI.WebControls.ListItemType templateType;
        bool repeaterIsTeam;
        public MyTemplate(System.Web.UI.WebControls.ListItemType type, bool isteam = true)
        {
            templateType = type;
            repeaterIsTeam = isteam;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            PlaceHolder ph = new PlaceHolder();
            switch (templateType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    if (repeaterIsTeam)//团队
                    {
                        Panel p = new Panel();
                        p.CssClass = "fl";
                        Panel pItem = new Panel();
                        pItem.CssClass = "team";
                        Label item1 = new Label();
                        item1.ID = "item1";
                        item1.CssClass = "teamitem";
                        pItem.Controls.Add(item1);

                        PlaceHolder childph = new PlaceHolder();
                        childph.ID = "ph";

                        p.Controls.Add(pItem);
                        p.Controls.Add(childph);

                        ph.Controls.Add(p);
                    }
                    else//成员
                    {
                        Panel p = new Panel();
                        p.ID = "user";
                        p.CssClass = "user";
                        Label item1 = new Label();
                        item1.ID = "item1";
                        item1.CssClass = "teamuser";
                        p.Controls.Add(item1);
                        ph.Controls.Add(p);
                    }
                    ph.DataBinding += new EventHandler(Item_DataBinding);
                    break;
                case ListItemType.Footer:
                    Panel plClear = new Panel();
                    plClear.CssClass = "clear";
                    ph.Controls.Add(plClear);
                    break;
            }
            container.Controls.Add(ph);
        }
        static void Item_DataBinding(object sender, System.EventArgs e)
        {
            PlaceHolder ph = (PlaceHolder)sender;
            RepeaterItem ri = (RepeaterItem)ph.NamingContainer;
            Label lb = (Label)ph.FindControl("item1");
            lb.Text = DataBinder.Eval(ri.DataItem, "Name").ToString();
            lb.ToolTip = DataBinder.Eval(ri.DataItem, "ToolTip").ToString();
            DataRowView drv = (DataRowView)ri.DataItem;
            if (drv.Row.ItemArray.Length == 8)//团队
            {
                lb.Attributes.Add("tid", drv["TMRPID"].ToString());
                lb.Text += string.Format("({0})", DataBinder.Eval(ri.DataItem, "LeaderName").ToString());
            }
        }
    }
}