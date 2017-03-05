using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Net.Json;

namespace Web.Handler
{
    public partial class e : System.Web.UI.Page
    {
        NameValueCollection nv;
        protected void Page_Load(object sender, EventArgs e)
        {
            nv = HttpContext.Current.Request.QueryString;
            databind();
        }

        protected void databind()
        {
            switch (nv["type"])
            {
                case "roomlist":
                    RoomList();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 房间列表
        /// </summary>
        protected void RoomList()
        {
            JsonArrayCollection jac = new JsonArrayCollection();
            for (var i = 0; i < 4; i++)
            {
                JsonObjectCollection colDR = new JsonObjectCollection();
                colDR.Add(new JsonStringValue("roomid", "1000" + i));
                colDR.Add(new JsonStringValue("roomname", "团队1000" + i));
                jac.Add(colDR);
            }
            Response.Write(string.Format("{0}({1})", nv["jsoncallback"], "[{\"roomid\": \"10000\",\"roomname\": \"团队10000\"},{\"roomid\": \"10001\",\"roomname\": \"团队10001\"}]"));
        }
    }
}