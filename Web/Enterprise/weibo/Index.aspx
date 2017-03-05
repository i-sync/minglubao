<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Enterprise.weibo.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业微博</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
</head>
<body>
    <div class="weibo_wap">
        <div class="weibo">
            <div class="weibotop">
                <div class="img">
                    <asp:Image runat="server" ID="imgAvatar" /></div>
                <div class="user">
                    <span>
                        <asp:Literal runat="server" ID="ltName" /></span><br />
                    <asp:Literal runat="server" ID="ltMobile" /></div>
                <div class="item">
                    <a href="my.aspx">我的留言</a></div>
                <div class="item cur">
                    <a href="index.aspx">留言大厅</a></div>
            </div>
            <div class="weibomain">
                <div class="fabobg">
                    <div class="fabu">
                        <textarea tabindex="1" class="weibo_content txt" id="txtWeiboContent"></textarea>
                        <div class="send_succpic">
                            &nbsp;</div>
                        <table>
                            <tr>
                                <td class="weibo_kind" id="weibo_kind">
                                    <a title="表情" action-type="face" class="face" href="javascript:void(0);" tabindex="3">
                                        表情</a> <a title="图片" action-type="image" class="img" href="javascript:void(0);" tabindex="3"
                                            style="display: none;">图片</a> &nbsp;
                                </td>
                                <td style="text-align: right; width: 190px;" id="contenttextnum">
                                    &nbsp;
                                </td>
                                <td style="width: 50px; text-align: right;">
                                    <div class="btn">
                                        <a title="发布微博" class="disable" href="javascript:void(0);" tabindex="2" id="btnPublish">
                                        </a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="weibolist" id="divweibolist">
                    <asp:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                            <dl class="feed_list" weiboid="<%#Eval("WeiboID") %>">
                                <dt class="face"><a title="wongbenson">
                                    <img width="50" height="50" src="<%#MLMGC.COMP.Config.GetEnterpriseAvatarUrl(Eval("Avatar").ToString()) %>"
                                        alt="" title="<%#Eval("TrueName")%>" /></a> </dt>
                                <dd class="content">
                                    <p>
                                        <a href="javascript:void(0);" title="<%#Eval("TrueName")%>">
                                            <%#Eval("TrueName")%></a> ：<em><%#Eval("Detail")%></em></p>
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
        <i class="clear"></i>
    </div>
    <script type="text/javascript">
        var CONFIG = {
            URL: 'weibo.ashx',
            weiboid: null
        };
        var CONSTANT = {
            timeSecond: 10000,
            NORMAL_DEFAULT_VALUE: "说点什么吧...",
            INPUT_TEXT_NUM_1: 140
        };
        var timer = null;
        var Weibo = {
            createitem: function (data) {
                CONFIG.weiboid = parseInt(data.weiboid);
                return '<dl class="feed_list"><dt class="face"><a title="wongbenson"><img width="50" height="50" src="' + data.img + '" title="' + data.username + '"></a> </dt>'
                                + '<dd class="content">'
                                + '    <p><a href="javascript:void(0);" title="' + data.username + '">' + data.username + '</a> ：<em>' + data.weibo + '</em></p>'
                                + '      <p><a title=' + data.date + ' class="date">' + data.showdate + '</a></p>'
                                + '</dd><dd class="clear"></dd></dl>';
            },
            showTop: function (data) {
                ///显示一条微博
                var item = this.createitem(data);
                $(item).prependTo("#divweibolist");
            },
            timerlist: function () {
                var _this = this;
                $.ajax({
                    type: "GET",
                    url: URLPlusRandom(CONFIG.URL),
                    data: { key: "newlist", weiboid: CONFIG.weiboid },
                    success: function (data) {
                        try {
                            if (data!=null && data.list.length > 0) {
                                var str = "";
                                for (var i = 0; i < data.list.length; i++) {
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
            $("#btnPublish").click(function () {
                $(this).blur();
                if ($(this).hasClass("disable")) {
                    return false;
                }
                var txtWeibo = $("#txtWeiboContent");
                var weibo = $(txtWeibo).val();
                if ($.IsNullOrEmpty(weibo)) {
                    return false;
                }
                $(txtWeibo).val("");
                $.ajax({
                    type: "POST",
                    url: URLPlusRandom(CONFIG.URL + "?key=add"),
                    data: { weibo: weibo },
                    success: function (data) {
                        if (data == "succ") {
                            try {
                                $(".send_succpic").show();
                                setTimeout(function () { $(".send_succpic").hide() }, 1400);
                                Weibo.timerlist();
                            }
                            catch (e) {
                                reload();
                            }
                        } else {
                            alert("操作失败啦...");
                        }
                    },
                    error: function (data) {
                        $(txtWeibo).val(weibo);
                        alert("连接服务器失败");
                    },
                    dataType: "text"
                });
            });
            CONFIG.weiboid = parseInt($("#divweibolist dl:first-child").attr("weiboid"), 10);
            timer = setTimeout(Weibo.timerlist, CONSTANT.timeSecond);
        });
    </script>
    <script src="/JS/Weibo.js" type="text/javascript"></script>
</body>
</html>
