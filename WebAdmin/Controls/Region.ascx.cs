using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using MLMGC.DataEntity;
using MLMGC.BLL;
using MLMGC.COMP;
using MLMGC.DBUtility;

namespace WebAdmin.Controls
{
    public partial class Region : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                databind();
            //}
        }

        //声明对象
        private List<E_Region> list;
        private DataTable dt;
        protected StringBuilder strArray;

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void databind()
        {
            //获取数据源
            dt = new MLMGC.BLL.T_Region().GetList(); 
            if (dt == null || dt.Rows.Count == 0)
                return;

            //初始化对象
            list = new List<E_Region>();
            E_Region region = null;

            //-----------------------分析绑定数据-------------------------
            //判断是否传值
            int regionid,pid =0;
            if (!int.TryParse(hfValue.Value,out regionid))
            {
                Jscript.ShowMsg("参数错误", this);
                return;
            }
            //查找父节点编号
            DataRow[] rows = dt.Select(" regionid=" + regionid);
            if (rows.Length == 1)
            {
                pid = Convert.ToInt32(rows[0]["parentid"]);
            }

            //获取所有父节点，绑定显示
            foreach (DataRow row in dt.Select(" parentid=0"))
            {
                region = new E_Region();
                region.RegionID = Convert.ToInt32(row["RegionID"]);
                region.RegionName = row["RegionName"].ToString();
                AddChild(region,regionid);
                if (region.RegionID == pid)   //如果当前节点编号==pid ,则选中该节点
                {
                    region.Selected = " selected=\"selected\"";

                    //绑定子级
                    rpSecond.DataSource = region.List;
                    rpSecond.DataBind();
                }
                list.Add(region);
            }
            rpList.DataSource = list;
            rpList.DataBind();



            //-------------------------拼装json字符串----------------------------
            strArray = new StringBuilder("[");
            foreach (DataRow row in dt.Rows)
            {
                strArray.Append("{id:\""+row["RegionID"]+"\",name:\""+row["RegionName"]+"\",pid:\""+row["ParentID"]+"\"},");
            }
            strArray.Remove(strArray.Length - 1, 1);
            strArray.Append("]");
            hfData.Value = strArray.ToString();
            //-------------------------------------------------------------------
                        
        }

        /// <summary>
        /// 添加子节点（绑定下级）
        /// </summary>
        /// <param name="region"></param>
        public void AddChild(E_Region region,int regionid)
        {
            region.List = new List<E_Region>();
            E_Region r = null;
            foreach (DataRow row in dt.Select(" parentid=" + region.RegionID))
            {
                r = new E_Region();
                r.RegionID = Convert.ToInt32(row["RegionID"]);
                r.RegionName = row["RegionName"].ToString();
                if (r.RegionID == regionid)   //如果当前节点编号==regionid ,则选中该节点
                {
                    r.Selected = " selected=\"selected\"";
                }
                region.List.Add(r);
            }
        }

        /// <summary>
        /// 地区编号
        /// </summary>
        public int RegionID
        {
            get { return Convert.ToInt32(hfValue.Value); }
            set { hfValue.Value = value.ToString(); }
        }
    }
}