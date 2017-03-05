<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Web.Personal.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人个首页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script type="text/javascript" >
        var CONFIG = {
            URL: 'Weibo/Weibo.ashx',
            weiboid: null
        };
        var CONSTANT = {
            timeSecond: 10000
        };
        var timer = null;
        var Weibo = {
            createitem: function (data) {
                CONFIG.weiboid = parseInt(data.weiboid);
                return '<dl class="feed_list"><dt class="face"><a title="wongbenson"><img width="50" height="50" src="' + data.img + '" title="' + data.username + '"></a> </dt>'
                                + '<dd class="content">'
                                + '    <p><a href="javascript:void(0);" title="' + data.username + '">' + data.username + '</a> ：<em>' + data.weibo + '</em></p>'
                                + '      <p class="info"><a title=' + data.date + ' class="date">' + data.showdate + '</a></p>'
                                + '</dd><dd class="clear"></dd></dl>';
            },
            showTop: function (data) {
                //把最后一条删除
                $("#divweibolist .feed_list:last").remove();
                ///显示一条微博
                var item = this.createitem(data);
                $(item).prependTo("#divweibolist");
            },
            timerlist: function () {
                var _this = this;
                
                $.ajax({
                    type: "GET",
                    url: URLPlusRandom(CONFIG.URL),
                    data: { key: "toplist", weiboid: CONFIG.weiboid },
                    success: function (data) {
                        try {
                            if (data!=null && data.list.length > 0) {
                                var str = "";
                                for (var i = 0; i < data.list.length; i++) {
                                    //查询出来几条最新的，就从后面删除几条
                                    //把最后一条删除
                                    $("#divweibolist .feed_list:last").remove();
                                    str = str + Weibo.createitem(data.list[i]);
                                }
                                $(str).prependTo("#divweibolist");
                            }
                            timer = setTimeout(Weibo.timerlist, CONSTANT.timeSecond);
                        }
                        catch (e) {
                            alert("获取数据失败");
                        }
                    },
                    error: function (data) {
                        alert("连接服务器失败！");
                    },
                    dataType: "json"
                });
            }
        };

        $(function () {
            CONFIG.weiboid = parseInt($("#divweibolist dl:first-child").attr("weiboid"), 10);
            timer = setTimeout(Weibo.timerlist, CONSTANT.timeSecond);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="personservice">
        <div class="service">
            <div class="minglu">
                <a href="javascript:alert('功能未开放');">找名录</a></div>
            <div class="tuandiu">
                <a href="javascript:alert('功能未开放');">找团队</a></div>
            <div class="xiangmu">
                <a href="javascript:alert('功能未开放');">找项目</a></div>
            <div class="ziliao">
                <a href="/WenKu/List.aspx">找资料</a></div>
            <i class="clear"></i>
        </div>
        <div class="dateweater">
            <div class="date">
                <%=DateTime.Now.Year %>年<%=DateTime.Now.Month %>月<%=DateTime.Now.Day %>日&nbsp;&nbsp;星期<%="日,一,二,三,四,五,六".Split(',')[Convert.ToInt32(DateTime.Now.DayOfWeek)]%></div>
            <div class="weater">
                <iframe src="http://m.weather.com.cn/m/pn4/weather.htm" width="160" height="20" marginwidth="0"
                    marginheight="0" hspace="0" vspace="0" frameborder="0" scrolling="no"></iframe>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="personmain">
        <div class="weibo">
            <div class="weibotop">
                <div class="img">
                    <asp:Image runat="server" ID="imgAvatar" /></div>
                <div class="user">
                    <span><asp:Literal runat="server" ID="ltName" /></span><br />
                    <asp:Literal runat="server" ID="ltMobile" /></div>
                <div class="item"><a href="weibo/my.aspx">我的广播</a></div>
                <div class="item">
                    <a href="weibo/index.aspx">大厅</a></div>
            </div>
            <div class="weibomain">
                <div style="padding-top: 10px;padding-left:20px;" id="divweibolist">
                    <asp:Repeater runat="server" ID="rpListWeibo">
                        <ItemTemplate>
                            <dl class="feed_list" weiboid="<%#Eval("WeiboID") %>">
                                <dt class="face"><a title="wongbenson">
                                    <img width="50" height="50" src="<%#MLMGC.COMP.Config.GetPersonalAvatarUrl(Eval("Avatar").ToString()) %>"
                                        alt="" title="<%#Eval("RealName")%>" /></a> </dt>
                                <dd class="content">
                                    <p>
                                        <a href="javascript:void(0);" title="<%#Eval("RealName")%>">
                                            <%#Eval("RealName")%></a> ：<em><%#Eval("Detail")%></em></p>
                                    <p>
                                        <a title="<%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>" class="date">
                                            <%# Web.Enterprise.weibo.WEIBOHelper.ShowTime(Eval("AddDate"))%></a>
                                    </p>
                                </dd>
                                <dd class="clear">
                                </dd>
                            </dl>
                        </ItemTemplate>
                    </asp:Repeater>
                   
                </div>
            </div>
        </div>
        <div class="gonggao">
            <div class="bg">
                名录宝公告</div>
            <div class="gglist">
                <dl>
                    <asp:Repeater ID="rpListAnn" runat="server">
                        <ItemTemplate>
                            <dd>
                                <div class="biaoti">
                                    <a href="/ann/info.aspx?id=<%#Eval("AnnouncementID") %>" class="info" target="ann">
                                        <%#Eval("AnnTitle") %>
                                    </a>
                                </div>
                                <div class="riqi">
                                    <%#Eval("AddDate","{0:yyyy-MM-dd}") %>
                                </div>
                                <i class="clear"></i>
                            </dd>
                        </ItemTemplate>
                    </asp:Repeater>
                </dl>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
</body>
</html>
