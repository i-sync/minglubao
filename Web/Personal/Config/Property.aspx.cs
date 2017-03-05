using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal.Config;

namespace Web.Personal.Config
{
    public partial class Property : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            E_Property data = new T_Property().Get(new E_Property() { PersonalID =PersonalID});
            if (data != null)
            {
                cbTrade.Checked = (data.TradeFlag == EnumPropertyEnabled.启用);
                cbArea.Checked = (data.AreaFlag == EnumPropertyEnabled.启用);
                cbSource.Checked = (data.SourceFlag == EnumPropertyEnabled.启用);
                if (!cbTrade.Checked)//设置行业按钮
                {
                    btnTrade.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    btnTrade.Attributes.Remove("disabled");
                }
                if (!cbArea.Checked)//设置来源按钮
                {
                    btnArea.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    btnArea.Attributes.Remove("disabled");
                }
                if (!cbSource.Checked)//设置来源按钮
                {
                    btnSource.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    btnSource.Attributes.Remove("disabled");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            E_Property data = new E_Property();
            data.PersonalID = PersonalID;
            data.TradeFlag = cbTrade.Checked ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            data.AreaFlag = cbArea.Checked ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            data.SourceFlag = cbSource.Checked ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            bool b = new T_Property().Set(data);
            MLMGC.COMP.Jscript.ShowMsg("保存" + (b ? "成功" : "失败"), this);
            databind();
        }
    }
}