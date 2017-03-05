using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using System.Data;
using System.Text;

namespace Web.Enterprise.Allot
{
    public partial class Setting : MLMGC.Security.EnterprisePage
    {
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            if (TradeFlag)
            {//绑定行业
                rpTradeList.DataSource = new T_Trade().GetShowList(new E_Trade() { EnterpriseID = EnterpriceID,CodeIsValue=false });
                rpTradeList.DataBind();
            }
            if (AreaFlag)
            {//绑定地区
                rpAreaList.DataSource = new T_Area().GetShowList(new E_Area() { EnterpriseID = EnterpriceID,CodeIsValue=false });
                rpAreaList.DataBind();
            }
            if (SourceFlag)
            {//绑定来源
                rpSource.DataSource = new T_Source().GetList(new E_Source() { EnterpriseID = EnterpriceID,CodeIsValue=false });
                rpSource.DataBind();
            }

            //----------------绑定对象列表
            rpList.DataSource = new T_Team().GetDirectMember(new E_Team() { EnterpriseID=EnterpriceID,TeamID=TeamID });
            rpList.DataBind();
            //绑定配置信息
            DataSet ds = new T_Allot().Select(new E_Allot() { EnterpriseID=EnterpriceID,TeamID=TeamID });
            if (ds == null || ds.Tables.Count != 5)
            {
                return;
            }
            List<string> listObj = new List<string>();
            List<string> listTrade = new List<string>();
            List<string> listArea = new List<string>();
            List<string> listSource = new List<string>();
            
            //遍历对象
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                listObj.Add(dr["objID"].ToString());
                List<string> aryTrade = new List<string>();
                List<string> aryArea = new List<string>();
                List<string> arySource = new List<string>();
                //行业
                foreach (DataRow drTrade in ds.Tables[2].Select("gid="+dr["gid"]))
                {
                    aryTrade.Add(drTrade["TradeID"].ToString());
                }
                //地区
                foreach (DataRow drArea in ds.Tables[3].Select("gid=" + dr["gid"]))
                {
                    aryArea.Add(drArea["AreaID"].ToString());
                }
                //来源
                foreach (DataRow drSource in ds.Tables[4].Select("gid=" + dr["gid"]))
                {
                    arySource.Add(drSource["SourceID"].ToString());
                }
                listTrade.Add(string.Join(",",aryTrade));
                listArea.Add(string.Join(",", aryArea));
                listSource.Add(string.Join(",", arySource));
            }

            txtCILimit.Text = ds.Tables[0].Rows[0][0].ToString();
            hdObj.Value = string.Join("|", listObj);
            hdTrade.Value = string.Join("|", listTrade);
            hdArea.Value = string.Join("|", listArea);
            hdSource.Value = string.Join("|", listSource);
        }
    }
}