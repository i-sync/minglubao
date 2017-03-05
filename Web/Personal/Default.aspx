<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Personal.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人管理首页</title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript">
        function funResize() {
            var h = document.documentElement.clientHeight - 60;
            var w = document.documentElement.clientWidth - 154;
            $("#divCenter").height(h);
            $("#divMain").height(h).width(w);
            $("#main").height(h - 24);
        }

        $(function () {
            $(window).resize(function () {
                funResize();
            });
            funResize();
            //点击菜单
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

            //-------检索------
            $("#txtKeyword").keydown(function (e) {
                if (e.keyCode == 13) {
                    $("#btnSearch").trigger("click");
                    return false;
                }
            }).blur(function () {
                var v = $.trim($(this).val());
                if (v.length == 0) {
                    $(this).val("请输入关键词").addClass("colorhui");
                }
            }).focus(function () {
                if ($(this).val() === "请输入关键词") {
                    $(this).val("").removeClass("colorhui");
                }
            });
            $("#btnSearch").click(function () {
                //检索名录
                var key = $.trim($("#txtKeyword").val());
                if (key == "" || key == "请输入关键词")
                    return false;
                window.open("Search.aspx?name=" + escape(key), "main");
            })

            //退出时清空cookie
            $("#logout").click(function () {
                $.cookie("autologin", null, { path: '/' });
            });
        });
    </script>
</head>
<body style="overflow:hidden;">
    <div id="wrap" style=" overflow:hidden;">
        <form id="form1" runat="server">
        <!-------头部---------->
        <div class="header">
            <div class="fl">
                <img src="/images/logo.jpg" alt="LOGO" />
            </div>
            <div class="header_center fl">
                <ul class="nav">
                    <li class="cur"><a href="Weibo/Index.aspx" target="main">首页</a></li>
                    <li style="display:none;"><a href="javascript:void(0);">数据管理</a></li>
                </ul>
            </div>
            <div class="header_right fr">
                <div class="header_right_shang">
                    <p class="xiaotubiao">
                        <img src="/images/wenhao.jpg" />&nbsp;<a href="/ann/index.aspx" target="_blank">名录宝公告</a>
                        <span class="fankui">
                            <img src="/images/fankui.jpg" />&nbsp;<a href="Feedback.aspx" target="main">反馈</a>
                        </span><span class="fankui">
                            <img src="/images/lianxi.jpg" />&nbsp;<a href="javascript:void(0);">联系名录宝</a>
                        </span>
                    </p>
                </div>
                <div class="header_right_xia">
                    <input id="txtKeyword" type="text" name="" class="colorhui" style="height: 17px; width: 193px; border: 1px solid #6B97B4" />&nbsp;<input
                        id="btnSearch" type="button" value="搜索" name="" />
                </div>
            </div>
        </div>
        <!--主体-->
        <div id="divCenter" style="width: 100%; height: 100%;">
            <div class="menu fl" style="border-right: 1px solid #ccc; height: 100%; overflow: hidden;">
                <div class="list_xiugaimima">
                    <div class="guanliyuan fl">
                        <asp:Image ID="imgAvatar" style="width:30px;height:30px;" runat="server" />
                    </div>
                    <div class="guanliyuan_denglu fl">
                        <div class="guanliyuan_denglushang" style=" overflow:hidden; width:100px;">
                            <asp:Literal runat="server" ID="ltName" Text="123" />
                        </div>
                        <div class="guanliyuan_dengluxia">
                            <a href="UpdatePassword.aspx" target="main">[修改密码]</a>&nbsp;<a href="Logout.aspx" id="logout"
                                target="_self">[退出]</a>
                        </div>
                    </div>
                </div>
                <div class="menulist">
                    <div class="curitem" type="data">
                        <div class="title">
                            <a href="#">期初设置</a></div>
                        <div>
                            <ul>
                                <li><a href="Config/Property.aspx" target="main">分类设置</a></li>
                                <li><a href="Config/MailConfig.aspx" target="main">邮箱设置</a></li>
                                <li><a href="Material/TalkList.aspx" target="main">话术设置</a></li>
                                <li><a href="Config/StateWish.aspx" target="main">意向进展</a></li>
                                <li><a href="Config/StateNotTraded.aspx" target="main">失败原因</a></li>
                                <li><a href="Config/StateScrap.aspx" target="main">报废理由</a></li>
                                <li><a href="Modify.aspx" target="main">修改资料</a></li>
                                <li><a href="Avatar/Avatar.aspx" target="main">设置头像</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="curitem" type="index">
                        <div class="title">
                            <a href="javascript:void(0);">名录管理</a></div>
                        <div>
                            <ul>
                                <li><a href="clientInfoAdd.aspx" target="main">名录录入</a></li>
                                <li><a href="data/ImportingStep1.aspx" target="main">名录导入</a></li>
                                <li><a href="latence.aspx" target="main">潜在客户</a></li>
                                <li><a href="wish.aspx" target="main">意向客户</a></li>
                                <li><a href="traded.aspx" target="main">成交客户</a></li>
                                <li><a href="nottraded.aspx" target="main">失败客户</a></li>
                                <li><a href="scrap.aspx" target="main">报废客户</a></li>
                                <li><a href="search.aspx" target="main">名录查询</a></li>
                                <li><a href="data/export.aspx" target="main">名录导出</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="curitem" type="index">
                        <div class="title">
                            <a href="javascript:void(0);">找资料</a></div>
                        <div>
                            <ul id="ulMaterial">
                                <li><a href="/WenKu/List.aspx" target="main">资料检索</a></li>
                                <li><a href="WenKu/Add.aspx" target="main">上传资料</a></li>
                                <li><a href="WenKu/List.aspx" target="main">我的资料</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="neirongbufen fl" style="position:absolute; left:154px; right:0;" id="divMain">
                <div class="gongsimingcheng">
                    帐号：<asp:Literal runat="server" ID="ltLoginName" /><span class="fuzeren">手机号码：<asp:Literal runat="server" ID="ltMobile" /> </span>
                </div>
                <iframe src="Weibo/Index.aspx" frameborder="0" scrolling="auto" id="main" name="main" style="width: 100%;
                    height: 100%;margin: 0; padding: 0;"></iframe>
            </div>
        </div>
        </form>
    </div>
</body>
</html>
