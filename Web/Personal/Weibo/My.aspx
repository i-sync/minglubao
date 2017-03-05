<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="Web.Personal.Weibo.My" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人微博</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/poptip.js" type="text/javascript"></script>
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="personservice">
        <div class="service">
            <div class="minglu">
                <a href="javascript:alert('功能未开放');">找名录</a></div>
            <div class="tuandiu">
                <a href="javascript:alert('功能未开放');">找团队</a></div>
            <div class="xiangmu">
                <a href="javascript:alert('功能未开放');">找项目</a></div>
            <div class="ziliao">
                <a href="javascript:alert('功能未开放');">找资料</a></div>
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
        <div class="weibo_wap">
            <div class="weibo">
                <div class="weibotop">
                    <div class="img">
                        <asp:Image runat="server" ID="imgAvatar" /></div>
                    <div class="user">
                        <span>
                            <asp:Literal runat="server" ID="ltName" /></span><br />
                        <asp:Literal runat="server" ID="ltMobile" /></div>
                    <div class="item cur"><a href="my.aspx">我的广播</a></div>
                    <div class="item">
                        <a href="index.aspx">大厅</a></div>
                </div>
                <div class="weibomain">
                    <div style="width:572px;margin:9px;">
                    </div>
                    <div class="weibolist" id="divweibolist">
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <dl class="feed_list" weiboid="<%#Eval("WeiboID") %>">
                                    <dt class="face"><a title="wongbenson">
                                        <img width="50" height="50" src="<%#MLMGC.COMP.Config.GetPersonalAvatarUrl(Eval("Avatar").ToString()) %>"
                                            alt="" title="<%#Eval("RealName")%>" /></a> </dt>
                                    <dd class="content">
                                        <p>
                                            <a href="javascript:void(0);" title="<%#Eval("RealName")%>">
                                                <%#Eval("RealName")%></a> ：<em><%#Eval("Detail")%></em></p>
                                        <p class="info">
                                            <span><a href="javascript:void(0)" class="del">删除</a></span>
                                            <a title="<%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>" class="date">
                                                <%# Web.Enterprise.weibo.WEIBOHelper.ShowTime(Eval("AddDate"))%></a>
                                        </p>
                                    </dd>
                                
                                    <i class="clear"></i>
                                </dl>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div style="line-height: 40px; height: 40px; vertical-align: middle; height: 40px;">
                        <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                            PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                            TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;" AlwaysShow="true"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1" PrevPageText="上一页"
                            ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                            LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                    </div>
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
    <!--临时表情-->
    <div class="weibo_layer" style="z-index:9999;position:absolute; top:190px; left:36px; display:none;">
        <div class="bg">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr><td>
                <div class="content">
                    <a title="关闭" node-type="close" href="javascript:void(0);" class="weibo_close"></a>
                </div>
                </td></tr>
            </table>
        </div>
    </div>
    <script type ="text/javascript">
        $(function () {
            $(".del").click(function () {
                var weiboid = $(this).parents("dl").attr("weiboid");
                $.get("Weibo.ashx", "key=delete&weiboid=" + weiboid, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "删除失败", false);
                    }
                }, "text");
            });
        });
    </script>    
</body>
</html>
