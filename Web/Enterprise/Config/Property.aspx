<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Property.aspx.cs" Inherits="Web.Enterprise.Config.Property" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录属性配置</title>
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var URL_CONFIG = {
            Post_URL: "/enterprise/ephandler.ashx"
        };
        var arySrc = new Array();
        function setTab(i, checked) {
            if (checked) {
                $("#lookbar .baritem").eq(i).show();
            }
            else {
                $("#lookbar .baritem").eq(i).hide();
            }
            var curi = $("#lookbar .baritem").index($("#lookbar .cur"));
            if (checked && i == curi) { return; }
            if (checked) {
                $($("#lookbar .baritem").get(i)).triggerHandler("click");
                return;
            }
            if ($(":checked").length > 0) {
                var i = $(":checkbox").index($(":checked").get(0));
                $($("#lookbar .baritem").get(i)).triggerHandler("click");
            }
            else {
                $("#lookbar .cur").removeClass("cur").addClass("item");
                $("#ifrset").attr("src", "about:blank");
            }
        };

        //异步提交属性设置
        function setProperty() {
            var trade = $("#cbTrade")[0].checked;
            var area = $("#cbArea")[0].checked;
            var source = $("#cbSource")[0].checked;
            var data = "key=501&trade=" + trade + "&area=" + area + "&source=" + source + "&t=" + Math.random();
            var result;
            $("#Tips").show();
            $.ajax({
                type: "GET",
                url: URL_CONFIG.Post_URL,
                async: false,
                data: data,
                success: function (data) {
                    if (data == "1") {
                        result = true;
                        $("#Tips").html("<span class='succ'>修改成功</span>");
                    }
                    else {
                        result = false;
                        $("#Tips").html("<span class='error'>修改失败</span>");
                    }
                },
                dataType: "text"
            });
            setTimeout(function () { $("#Tips").hide() }, 2000);
            return result;
        }

        $(function () {
            arySrc.length = 0;
            //标识是不是初始化
            var isLoad = true;
            $("#cbTrade").click(function () {
                var v = true;
                if (!isLoad) {
                    v = setProperty();
                }
                if ($(this).is(":checked") && v) {
                    arySrc[0] = "PropertyTrade.aspx";
                    setTab(0, true);
                } else {
                    arySrc[0] = null;
                    setTab(0, false);
                }

            });
            $("#cbArea").click(function () {
                var v = true;
                if (!isLoad) {
                    v = setProperty();
                }
                if ($(this).is(":checked") && v) {
                    arySrc[1] = "PropertyArea.aspx";
                    setTab(1, true);
                } else {
                    arySrc[1] = null;
                    setTab(1, false);
                }

            });
            $("#cbSource").click(function () {
                var v = true;
                if (!isLoad) {
                    v = setProperty();
                }
                if ($(this).is(":checked") && v) {
                    arySrc[2] = "PropertySource.aspx";
                    setTab(2, true);
                } else {
                    arySrc[2] = null;
                    setTab(2, false);
                }
            });
            //----初始化数组---

            $(":checkbox").each(function () { $(this).triggerHandler("click"); });
            isLoad = false;
            //设置Iframe 高
            //            $("#ifrset").load(function () {
            //                var h = $("#ifrset").contents().find("body").outerHeight(true) + 30;
            //                if (h < 450) { h = 450; }
            //                $("#ifrset").attr("height", h).height(h);
            //                $("#divTab").height(h);
            //            });
            //获取上级iframe高
            var h = $(parent.document).find("#main").height() - 140;
            if (h > 0) {
                $("#divTab").height(h);
            }

            //选项卡切换
            $("#lookbar .baritem").click(function () {
                if ($(this).attr("class").indexOf("cur") > 0) {
                    return false;
                }
                var i = $("#lookbar .baritem").index(this);
                var src = arySrc[i];
                if (src == null) {
                    return;
                }
                $("#lookbar .cur").removeClass("cur").addClass("item");
                $(this).removeClass("item").addClass("cur");
                $("#ifrset").attr("src", arySrc[i]);
            });
            //设置默认选项卡
            if ($(":checked").length > 0) {
                var i = $(":checkbox").index($(":checked").get(0));
                $($("#lookbar .baritem").get(i)).triggerHandler("click");
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            名录属性配置</h3>
        
    </div>
    <div style="margin: 10px 20px;">
        选择名录所需要的分类:
        <asp:CheckBox runat="server" ID="cbTrade" Text="按行业分类" />
        <asp:CheckBox runat="server" ID="cbArea" Text="按地区分类" />
        <asp:CheckBox runat="server" ID="cbSource" Text="按来源分类" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <div id="Tips" style="display: inline;">
        </div>
    </div>
    <i class="line"></i>
    <div id="lookbar">
        <div class="baritem item">
            设置行业</div>
        <div class="baritem item">
            设置地区</div>
        <div class="baritem item">
            设置来源</div>
    </div>
    <div id="divTab" class="barInfoList" style="height: 400px;">
        <iframe src="about:blank" id="ifrset" name="ifrset" frameborder="0" style="width: 100%; height: 100%">
        </iframe>
    </div>
    </form>    
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=4" type="text/javascript"></script>
</body>
</html>
