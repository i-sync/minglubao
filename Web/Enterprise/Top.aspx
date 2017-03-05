<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Web.Enterprise.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />    
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //----------菜单----------
            $(".nav li").click(function () {//一级菜单
                var c = $(this).attr("class");

                //$("#main").attr("src", URLPlusRandom($("#main").attr("src")));

                //if (c == "cur") { return false; }
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


            //-----------检索------------------
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
                window.open("Search.aspx?keyword=" + escape(key), "main");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="header">
            <div class="fl">
                <img src="../../images/logo.jpg" alt="LOGO" />
            </div>
            <div class="header_center fl">
                <ul class="nav">
                    <asp:Repeater ID="rpFirstMenu" runat="server">
                        <ItemTemplate>
                            <li menuid="<%#Eval("menuid") %>"><a href="<%#Eval("Url") %>" target="main">
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
    </div>
    </form>    
</body>
</html>
