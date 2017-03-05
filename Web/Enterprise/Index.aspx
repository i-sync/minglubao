<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Enterprise.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业管理首页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/poptip.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../JS/YindaoTip.js" type="text/javascript"></script>
    <link href="../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tips
        {
            display: none;
            position: absolute;
            top: 100px;
            left: 10px;
            width: 638px;
            line-height: 180%;
            z-index: 1000;
        }
        .tips div a
        {
            color: Red;
        }
        .tips .content
        {
            background: url(../images/tips/bg.png);
            height: 183px;
            margin: 0;
            display: block;
        }
    </style>
</head>
<body style="overflow: hidden;" scroll="no">
    <div id="wrap">
        <form id="form1" runat="server">
        <!-------头部---------->
        <div class="header">
            <div class="fl">
                <img src="../../images/logo.jpg" alt="LOGO" />
            </div>
            <div class="header_center fl">
                <ul class="nav">
                    <asp:Repeater ID="rpFirstMenu" runat="server">
                        <ItemTemplate>
                            <li menuid="<%#Eval("menuid") %>"><a href="<%#Eval("Url") %>">
                                <%#Eval("MenuName") %></a> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="header_right fr">
                <div class="header_right_shang">
                    <p class="xiaotubiao">
                        <img src="../../images/wenhao.jpg" />&nbsp;<a href="../Ann/Index.aspx" target="_blank">名录宝公告</a>
                        <span class="fankui">
                            <img src="../../images/fankui.jpg" />&nbsp;<a href="Feedback.aspx" target="main">反馈</a>
                        </span><span class="fankui">
                            <img src="../../images/lianxi.jpg" />&nbsp;<a href="javascript:void(0);">联系名录宝</a>
                        </span>
                    </p>
                </div>
                <div class="header_right_xia">
                    <input id="txtKeyword" type="text" name="" style="height: 17px; width: 193px; border: 1px solid #6B97B4" />&nbsp;<input
                        type="button" value="搜索" name="" id="btnSearch" />
                </div>
            </div>
        </div>
        <!--主体-->
        <div id="divCenter" style="width: 100%; height: 100%;">
            <div class="menu fl" style="border-right: 1px solid #ccc; height: 100%; overflow: hidden;">
                <div class="list_xiugaimima">
                    <div class="guanliyuan fl">
                        <asp:Image ID="imgAvatar" runat="server" Width="30" Height="30" />
                    </div>
                    <div class="guanliyuan_denglu fl">
                        <div class="guanliyuan_denglushang">
                            <asp:Literal runat="server" ID="ltRole" Visible="false" />
                            <asp:Literal runat="server" ID="ltTrueName" />
                        </div>
                        <div class="guanliyuan_dengluxia">
                            <a href="UpdatePassword.aspx" target="main">[修改密码]</a>&nbsp;<a href="Logout.aspx"
                                target="_self">[注销]</a>
                        </div>
                    </div>
                </div>
                <div class="menulist">
                    <asp:Repeater runat="server" ID="rpSecondMenu" OnItemDataBound="rpSecondMenu_ItemDataBound">
                        <ItemTemplate>
                            <div class="item" pid="<%#Eval("pid") %>">
                                <div class="title" expand="<%#Eval("Expand") %>">
                                    <a href="<%#Eval("Url") %>" target="main">
                                        <%#Eval("MenuName") %></a></div>
                                <div>
                                    <ul>
                                        <asp:Repeater ID="rpThirdMenu" runat="server">
                                            <ItemTemplate>
                                                <li><a href="<%#Eval("Url") %>?t=<%=new Random().Next()%>" target="main">
                                                    <%#Eval("MenuName") %></a> </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="neirongbufen fl" style="width: 1000px; *width: 1000px; overflow: hidden;"
                id="divMain">
                <div class="gongsimingcheng">
                    <div class="fl">
                        <span class="fuzeren">公司名称：<asp:Literal ID="epName" Text="" runat="server"></asp:Literal></span>
                        <span class="fuzeren">项目名称：<asp:Literal ID="epItemName" Text="" runat="server"></asp:Literal></span>
                        <span class="fuzeren">负责人：<asp:Literal ID="epLinkman" Text="" runat="server"></asp:Literal></span>
                        <span class="fuzeren">公司电话：<asp:Literal ID="epTel" Text="" runat="server"></asp:Literal></span>
                    </div>
                    <div class="fr" id="curRole" style="color: red;">
                        身份切换：<asp:Label ID="lblRole" runat="server"></asp:Label>
                    </div>
                    <div id="roleInfo">
                        <div class="cur">
                            <span class="rolename">
                                <asp:Literal ID="ltCurRole" Text="总监" runat="server"></asp:Literal></span> <span
                                    class="rolename">
                                    <asp:Literal ID="ltCurTeam" Text="项目总监" runat="server"></asp:Literal></span>
                        </div>
                        <asp:Repeater ID="rpRole" runat="server">
                            <ItemTemplate>
                                <div class="item" epuid="<%#Eval("EPUserTMRID")%>" teamid="<%#Eval("TeamID") %>"
                                    roleid="<%#Eval("roleid") %>">
                                    <span class="rolename">
                                        <%#Eval("RoleName") %></span> <span class="rolename">
                                            <%#Eval("TeamName") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <iframe src="main.aspx" frameborder="0" id="main" scrolling="yes" runat="server"
                    name="main" style="width: 100%; height: 100%; border-bottom: 1px solid #ccc;
                    margin: 0; padding: 0; overflow: visible;"></iframe>
            </div>
        </div>
        </form>
    </div>
    <!--预约客户提示 start-->
    <div id="divlogKuang">
    </div>
    <div class="dialogBox" id="dialogBox2011">
        <div class="dialogBox-hd">
            <h3 class="dialogBox-hd-title">
                预约客户提醒</h3>
            <span class="dialogBox-hd-ext"></span>
        </div>
        <div class="dialogBox-bd">
            <div class="dialogBox-simpleText">
                <p>
                    预约客户：<a href="#" target="main">红手网络</a></p>
                <p>
                    提醒时间：<span class="date"></span>，提前：<span class="minute"></span>分钟</p>
            </div>
        </div>
    </div>
    <!--弹出层提示开始-->
    <div id="divTip" class="tips">
        <img src="../images/tips/top2.png" style="width: 400px; height: 17px;" />
        <div class="content">
            <div style="text-align: right; vertical-align: middle; height: 44px;">
                <div class="fr" style="margin: 10px 14px 0 0;">
                    <img class="close" src="../images/tips/delete.png" style="width: 17px; cursor: pointer;"
                        alt="关闭" />
                </div>
                <div class="fr" style="margin: 10px 10px 0 0;">
                    <span id="spanIndex">0</span>/<span id="spanTotal">0</span>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div id="divContent" style="width: 450px; height: 110px; margin-left: 155px; color: Black;
                display: block; font-size: 14px;">
            </div>
            <div style="text-align: right; margin: 5px 30px 0 0;">
                <a class="close" href="javascript:void(0);">我知道了，开始使用</a> &nbsp;&nbsp;&nbsp;&nbsp;
                <a id="aNext" href="javascript:void(0);">下一条</a>
            </div>
        </div>
    </div>
    <!--弹出层提示结束-->
    <!--预约客户提示 end-->
    <script type="text/javascript">
        function funResize() {
            var h = document.documentElement.clientHeight - 60;
            var w = $("#divCenter").width() - 154;
            $("#divCenter").height(h);
            $("#divMain").height(h).width(w);
            $("#main").height(h - 24);
        }
        var timer=null;
       

        $(function () {               

            $(window).resize(function () {
                funResize();
            });
            funResize();
            //----------菜单----------
            $(".nav li").click(function () {//一级菜单
                var c = $(this).attr("class");
               
                $("#main").attr("src",URLPlusRandom($("#main").attr("src")));
                if (c == "cur") { return false; }
                var menuid = $(this).attr("menuid");
                $(this).siblings(".cur").removeClass("cur");
                $(this).addClass("cur");
                //切换菜单
                $(".curitem[pid]").each(function () {
                    if ($(this).attr("pid") == menuid) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                });
            });
            //默认显示 首页
            $(".nav li").triggerHandler("click");
            $(".title").click(function () {
                var pObj = $(this).parent();
                if ($(pObj).is("div")) {
                    if ($(pObj).attr("class") == "item") {
                        $(pObj).attr("class", "curitem");
                    }
                    else {
                        $(pObj).attr("class", "item");
                    }
                }
            });
            $("a").click(function () {
                if ($(this).attr("class") == "current") {
                    return true;
                }
                $(".curent").removeClass("curent");
                $(this).addClass("curent");
            });
            //打开默认菜单
            $(".title[Expand='1']").each(function(){
                $(this).triggerHandler("click");
            });

            //-----------选择角色-----------
            $("#curRole").click(function () {
                $(document.body).bind("click", function () {
                    $("#roleInfo").hide();
                    $(document.body).unbind("click");
                    return false;
                });
                $("#roleInfo").show();
                return false;
            });

            //切换角色
            $("#roleInfo .item").click(function () {
                var teamid = $(this).attr("teamid");
                var epuid = $(this).attr("epuid");
                var roleid = $(this).attr("roleid");
                if (teamid != undefined && epuid != undefined && roleid != undefined) {
                    $(window).unbind("beforeunload").unbind("unload");
                    location = "selectrole.aspx?teamid=" + teamid + "&epuid=" + epuid+"&roleid="+roleid;
                }
                return false;
            });
            //-----------检索------------------
            $("#txtKeyword").keydown(function (e) {
                if (e.keyCode == 13) {
                    $("#btnSearch").trigger("click");
                    return false;
                }
            }).blur(function(){
                var v=$.trim($(this).val());
                if(v.length==0){
                    $(this).val("请输入关键词").addClass("colorhui");
                }
            }).focus(function(){
                if($(this).val()==="请输入关键词"){
                    $(this).val("").removeClass("colorhui");
                }
            });
            $("#btnSearch").click(function () {
                //检索名录
                var key = $.trim($("#txtKeyword").val());
                if (key == ""||key=="请输入关键词")
                    return false;
                window.open("Search.aspx?keyword=" + escape(key), "main");
            });<%if (ShowReservationTip) {%>
            //----------------预约客户提醒消息-------------------
            //--定时取最新数据
            $("#divlogKuang .dialogBox-hd-ext,#divlogKuang a").live("click", function () {
                var obj = $(this).parents(".dialogBox");
                $(obj).slideUp(function () {
                    $(obj).remove();
                });
            });
            setTimeout(Reservation, 6000);<%} %>
            //--------------关闭窗口--------------
            $(window).bind("beforeunload",function () {return "本页面要求您确认您要离开 - 您输入的数据可能不会被保存";});
            $(window).bind("unload",function(){
                    clearInterval(timer);
                    timer=null;
                    $.get("Logout.aspx", function () { });
            });
            timer=setInterval(function(){$.post(URLPlusRandom("handler/user.ashx"),"key=active",function(){})},60000);
//            <%if(ShowTip){ %>
//            //引导弹出层提示信息 
//            YindaoTip.Init($("#divTip"),<%=kid %>);
//           <%} %>
        });
        <%if (ShowReservationTip) {%>
        function Reservation() {
            var nid = $("#divlogKuang").data("nid");
            nid = (nid == undefined) ? "" : nid;
            var data = "act=reservation&ids="+nid+"&t=" + Math.random();
            $.get("handler/ep.ashx", data, function (data) {
                if (data.length < 1) {
                    setTimeout(Reservation, 60000);
                    return false;
                }
                var aryIds = Array();
                for (var i = 0; i < data.length; i++) {
                    aryIds.push(data[i].nid);
                    var dialogBox2011 = $("#dialogBox2011").clone();
                    $(dialogBox2011).find("a").attr("href", "clientinfo/track.aspx?s=reservation&ciid=" + data[i].id);
                    $(dialogBox2011).find("a").html(data[i].name);
                    $(dialogBox2011).find(".date").html(data[i].date);
                    $(dialogBox2011).find(".minute").html(data[i].minute);
                    $(dialogBox2011).removeAttr("id").prependTo("#divlogKuang");
                    $(dialogBox2011).slideDown();
                }
                var nid = $("#divlogKuang").data("nid");
                if (nid == undefined) {
                    nid = aryIds;
                }
                else {
                    nid = nid + "," + aryIds;
                }
                $("#divlogKuang").data("nid", nid);
                setTimeout(Reservation, 60000);
            }, "json");
        }<%} %>
    </script>
</body>
</html>
