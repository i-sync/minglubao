<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Personal.Weibo.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人微博</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/poptip.js" type="text/javascript"></script>
</head>
<body>
    <div class="personservice" style="width:1248px;">
        <div class="service">
            <div class="minglu">
                <a href="javascript:alert('功能未开放');">找名录</a></div>
            <div class="tuandiu">
                <a href="javascript:alert('功能未开放');">找团队</a></div>
            <div class="xiangmu">
                <a href="/personal/item/itemlist.aspx">找项目</a></div>
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
    <div class="personmain" style="width:1098px;float:left;">
        <div class="weibo_wap">
            <div class="weibo">
                <div class="weibotop">
                    <div class="img">
                        <asp:Image runat="server" ID="imgAvatar" /></div>
                    <div class="user">
                        <span>
                            <asp:Literal runat="server" ID="ltName" /></span><br />
                        <asp:Literal runat="server" ID="ltMobile" /></div>
                    <div class="item" type="personal"><a href="javascript:void(0);">我的广播</a></div>
                    <div class="item cur" type="public"><a href="javascript:void(0);">广播大厅</a></div>
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
                    <div id = "divResult">
                        <div style=" margin:10px;">网速有点不给力，我正在努力加载...</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="gonggao" style="width:340px;">
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
    
    <script type="text/javascript">
        var CONFIG = {
            URL: 'Weibo.ashx',
            weiboid: 0,
            type:'public'
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
                return '<dl class="feed_list" weiboid="' + data.weiboid + '"><dt class="face"><a title="wongbenson"><img width="50" height="50" src="' + data.img + '" title="' + data.username + '"></a> </dt>'
                                + '<dd class="content">'
                                + '    <p><a href="javascript:void(0);" title="' + data.username + '">' + data.username + '</a> ：<em>' + data.weibo + '</em></p>'
                                + '      <p class="info"><a title=' + data.date + ' class="date">' + data.showdate + '</a></p>'
                                + '</dd><dd class="clear"></dd></dl>';
            },
            showTop: function (data) {
                ///显示一条微博
                var item = this.createitem(data);
                $(item).prependTo("#list");
            },
            timerlist: function () {
                var _this = this;
                //判断当前是否为广播大厅，若是则刷新
                if (CONFIG.type == "public") {
                    $.ajax({
                        type: "GET",
                        url: URLPlusRandom(CONFIG.URL),
                        data: { key: "newlist", weiboid: CONFIG.weiboid },
                        success: function (data) {
                            try {
                                //alert(data.list.length);
                                if (data != null && data.list.length > 0) {
                                    var str = "";
                                    for (var i = 0; i < data.list.length; i++) {
                                        //$("#list .feed_list:last").remove();
                                        str = str + Weibo.createitem(data.list[i]);
                                    }
                                    $(str).prependTo("#list");
                                }
                            } catch (e) {
                                alert("获取数据失败");
                            }
                            timer = setTimeout(Weibo.timerlist, CONSTANT.timeSecond);
                        },
                        error: function (data) {
                            alert("连接服务器失败！");
                        },
                        dataType: "json"
                    });
                }
                else {
                    timer = setTimeout(Weibo.timerlist, CONSTANT.timeSecond);
                }
            }
        };

        //加载微博列表
        function WeiboList(url) {
            var url = URLPlusRandom(url + "#list");
            $("#divResult").load(url, function () {
                var id = parseInt($("#list").find("dl").eq(0).attr("weiboid"));                
                if (parseInt(CONFIG.weiboid) < id) {
                    CONFIG.weiboid = id;
                }
            });
        }

        $(function () {

            WeiboList("List.aspx?type=public");
            //重写分页
            $("#divResult .page-number a.js-link").live("click", function () {
                if($(this).parent().hasClass('pgCurrent')===false){
                    WeiboList("List.aspx?type=" + CONFIG.type+'&weiboid='+CONFIG.weiboid+'&page='+$(this).text()+'&t='+Math.random());
                }
                return false;
            });


            //切换广播大厅/我的广播
            $(".item").click(function () {
                $(this).parent().find("div").removeClass("cur");
                $(this).addClass("cur");
                CONFIG.type = $(this).attr("type");
                WeiboList("List.aspx?type=" + CONFIG.type);
            });

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
                        try {
                            if (data == "succ") {
                                $("#txtWeiboContent").val("");
                                $(".send_succpic").show();
                                setTimeout(function () { $(".send_succpic").hide() }, 1400);
                                //Weibo.timerlist();
                                WeiboList("List.aspx?type=" + CONFIG.type);
                            } else {
                                alert("发布失败啦。。。");
                            }
                        } catch (e) {
                            reload();
                        }
                    },
                    error: function (data) {
                        $(txtWeibo).val(weibo);
                        alert("连接服务器失败！");
                    },
                    dataType: "text"
                });
            });
            //CONFIG.weiboid = parseInt($("#list dl:first-child").attr("weiboid"), 10);
            timer = setTimeout(Weibo.timerlist, CONSTANT.timeSecond);

            ///删除微博
            $(".del").live("click", function () {
                var weiboid = $(this).parents("dl").attr("weiboid");
                //alert(weiboid);
                $.get("Weibo.ashx", "key=delete&weiboid=" + weiboid, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "删除成功", false);
                        WeiboList("List.aspx?type=personal");
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "删除失败", false);
                    }
                }, "text");
            });
        });
    </script>
    <script src="/JS/Weibo.js" type="text/javascript"></script>
</body>
</html>
