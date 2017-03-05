<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Web.Enterprise.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理首页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $.Hover(".mainteamlist div");

        });
    </script>
    <style type="text/css">
        .ann p img
        {
            width:30px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <div class="subject">
            <h3>
                &nbsp;
            </h3>
        </div>
        <div class="info">
            <div class="date">
                <%=DateTime.Now.Year %>年<%=DateTime.Now.Month %>月<%=DateTime.Now.Day %>日&nbsp;&nbsp;星期<%="日,一,二,三,四,五,六".Split(',')[Convert.ToInt32(DateTime.Now.DayOfWeek)]%></div>
            <div class="weater">
                <iframe src="http://m.weather.com.cn/m/pn4/weather.htm" width="160" height="20" marginwidth="0"
                    marginheight="0" hspace="0" vspace="0" frameborder="0" scrolling="no"></iframe>
            </div>
        </div>
        <i class="clear"></i>
    </div>
    <div class="dvWelcome">
        <div class="welTitle">
            团队公告
        </div>
        <!--本身及上级最新公告-->
        <div class="annlist">
            <asp:Repeater ID="rpListAnn" runat="server">
                <ItemTemplate>
                    <div class="anninfo">
                        <div class="img">
                            <img src="<%#MLMGC.COMP.Config.GetEnterpriseAvatarUrl(Eval("Avatar").ToString()) %>"
                                alt="头像" />
                        </div>
                        <div class="person">
                            <%#Eval("TrueName") %><br />
                            <%#Eval("AddDate","{0:yyyy-MM-dd}") %><br />
                            <%#Eval("AddDate","{0:HH:mm:ss}") %><br />
                        </div>
                        <div class="anntxt ann">
                            <h3>
                                <%#Eval("AnnTitle") %>
                            </h3>
                            <p>
                                <%#Eval("AnnContent") %>
                            </p>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!--团队成员-->
        <div class="teamTitle">
            <div class="img">
                <img src="/images/guanliyuan.jpg" /></div>
            <div class="tdcy">
                团队成员</div>
            <div class="teaminfo">
                销售团队 共有
                <%=rpList.Items.Count %>
                人</div>
        </div>
        <div class="mainteamlist">
            <asp:Repeater ID="rpList" runat="server">
                <ItemTemplate>
                    <div>
                        <img src="<%#MLMGC.COMP.Config.GetEnterpriseAvatarUrl(Eval("Avatar").ToString()) %>"
                            class="<%#MLMGC.Security.ActiveUser.Instance.IsActiveClass(Eval("userid").ToString()) %>"
                            width="50" height="50" alt="头像" />
                        <span>
                            <%#Eval("TrueName") %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <i class="clear"></i>
        </div>
        <!--留言板-->
        <div class="welTitle">
            留言板 <a href="/enterprise/weibo/index.aspx?20120203001" style="font-size: 12px; font-weight: normal;
                margin: 0 0 0 20px; color: Red;">我要留言&gt;&gt;</a>
        </div>
        <div class="lyb">
            <asp:Repeater runat="server" ID="rpListWeibo">
                <ItemTemplate>
                    <div class="msg">
                        <div class="photo">
                            <img src="<%#MLMGC.COMP.Config.GetEnterpriseAvatarUrl(Eval("Avatar").ToString()) %>" />
                            <p>
                                <%#Eval("TrueName") %></p>
                        </div>
                        <div class="info">
                            <div class="date">
                                <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                                说：</div>
                            <div class="weibo">
                                <%#Eval("Detail")%></div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
    <script src="../JS/Reservation.js" type="text/javascript"></script>

</body>
</html>
