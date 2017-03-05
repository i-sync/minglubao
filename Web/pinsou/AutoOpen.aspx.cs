using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;

namespace Web.pinsou
{
    public partial class AutoOpen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取品搜用户数据
            long userid = Requests.GetQueryLong("userid", 0);
            string username = Requests.GetQueryString("username");

            E_PinsouUser data = new E_PinsouUser();
            data.Pinsou_UserID = userid;
            data.UserName = username;
            //去品搜数据库验证用户编号和用户名是否正确
            DataTable dt = new T_User().Pinsou_Verification(data);
            //判断用户编号和用户名是否正确
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                string email = row["Email"].ToString();
                //再判断邮箱是否存在
                if (string.IsNullOrEmpty(email))
                {
                    Jscript.ShowMsg("邮箱不存在，无法注册！", this);
                    return;
                }
                //验证通过后，继续注册
                data.Pinsou_UserID = Convert.ToInt32(row["userid"]);
                data.Email = email;
                data.Password = EncryptString.EncryptPassword(row["password"].ToString());
                data.Mobile = row["mobile"].ToString();
                data.Fax = row["fax"].ToString();
                int result = new T_User().Pinsou_AutoRegister(data);
                if (result == -1)//邮箱已存在
                {
                    Jscript.ShowMsg("邮箱不存在，无法注册！", this);
                    return;
                }
                else if (result == 0)   //注册失败
                {
                    Jscript.ShowMsg("注册失败！", this);
                    return;
                }
                else   //注册成功直接跳转
                {
                    E_PersonalUser dataPU = new E_PersonalUser();
                    dataPU.UserID = data.mlb_UserID;
                    dataPU.PersonalID = data.PersonalID;
                    dataPU.UserName = data.Email;
                    dataPU.Password = data.Password;
                    new MLMGC.Security.PersonalPage().Login(dataPU);

                    Jscript.AlertAndRedirect(this, "注册成功", "../Personal/Default.aspx");
                }
            }
            else
            {
                Jscript.ShowMsg("用户编号和用户名错误！", this);
                return;
            }
        }
    }
}