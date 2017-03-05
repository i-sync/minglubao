<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamMap.aspx.cs" Inherits="Web.Enterprise.TeamMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业团队结构图</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../JS/hover.js" type="text/javascript"></script>
    <style type="text/css">
        .fl
        {
            float: left;
            font-size:12px;
        }
        .team
        {
            height: 52px;
            padding-top: 0;
            margin: 0;
            float: left;
            width: 100%;
            display: block;
            background-repeat: no-repeat;
        }
        .teamitem
        {
            width: 130px;
            border: 1px solid #cccccc;
            margin: 10px auto 0 auto;
            height: 30px;
            display: block;
            text-align: center;
            line-height: 30px;
            vertical-align: middle;
            cursor: pointer;
            background-color: white;
        }
        .teamitem:hover, .hover
        {
            background: #0a6288;
            color: White;
        }
        .user
        {
            width: 105px;
            margin: 0;
            padding: 0;
            margin: 0;
            height: 30px;
            padding: 10px 0 0 48px;
            background: url(/images/teammap/teammapbg.jpg);
            clear: both;
        }
        .teamuser
        {
            width:90px;
            border: 1px solid #cccccc;
            display: block;
            height: 25px;
            margin: 0;
            text-align: center;
            background: white;
            line-height: 25px;
            cursor: pointer;
        }
        .teamuser:hover, .hover
        {
            background: #0a6288;
            color: White;
        }
        
        /*团队*/
        .teamfirst
        {
            background: url(/images/teammap/teamleaderbgone.jpg) no-repeat;
            background-position: center 10px;
        }
        .teamleaderbgone
        {
            background: url(/images/teammap/teamleaderbgone.jpg) no-repeat;
            background-position: center 0px;
        }
        .teamleaderbgleft
        {
            background: url(/images/teammap/teamleaderbgleft.jpg) no-repeat;
            background-position: center 0;
        }
        .teamleaderbgcenter
        {
            background: url(/images/teammap/teamleaderbgcenter.jpg) no-repeat;
            background-position: center 0;
        }
        .teamleaderbgright
        {
            background: url(/images/teammap/teamleaderbgright.jpg) no-repeat;
            background-position: center 0;
        }
        /*用户*/
        /*总监->用户*/
        .teamuserbgtop
        {
            background: url(/images/teammap/teammapbg.jpg) no-repeat;
            background-position:-830px -194px;
        }
        .teamuserbgone
        {
            background: url(/images/teammap/teammapbg.jpg) no-repeat;
            background-position: -659px -194px;
        }
        .teamuserbgleft
        {
            background: url(/images/teammap/teammapbg.jpg) no-repeat;
            background-position: -121px -194px;
        }
        .teamuserbgcenter
        {
            background: url(/images/teammap/teammapbg.jpg) no-repeat;
             background-position: -341px -194px;
        }
        .teamuserbgright
        {
            background: url(/images/teammap/teammapbg.jpg) no-repeat;
            background-position: -540px -194px;
        }
        .userbgstart
        {
            background-position: 0px -10px;
            background-repeat: no-repeat;
        }
        .userbgmiddle
        {
            background-position: 0px -10px;
            background-repeat: no-repeat;
        }
        .userbgsend
        {
            background-position: 0px -69px;
            background-repeat: no-repeat;
        }
    </style>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            团队结构图</h3>
    </div>
    <div style="margin: 20px;">
        <div class="fl">
            <asp:Repeater runat="server" ID="rpList" OnItemDataBound="rpList_ItemDataBound">
                <ItemTemplate>
                    <div class="team teamfirst">
                        <span class="teamitem" title="<%#Eval("ToolTip") %>">
                            <%#Eval("Name")%>( <%#Eval("LeaderName")%>)</span></div>
                    <asp:PlaceHolder runat="server" ID="ph"></asp:PlaceHolder>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=53" type="text/javascript"></script>
    <script type="text/javascript">
        var aryDeptLen = Array();
        var baseWidth = 153;
        $(function () {
            //设置用户
            $("div[id*='user_0']").each(function () {
                $(this).parent("div").parent("div").attr("isset", "1");
                var obj = $(this).parent("div").children(".user");
                var len = $(obj).length;
                $(this).parent("div").children(".user").each(function (i) {
                    if (i == 0 && len > 1) {//第一个 且有下一个
                        $(this).addClass("userbgstart");
                    }
                    else if (i == len - 1) {//最后一个
                        $(this).addClass("userbgsend");
                    }
                    else {//中间
                        $(this).addClass("userbgmiddle");
                    }
                });
            });
            //--------设置样式
            //--设置最后一级 用户
            $("div.userbgsend").each(function (i) {
                $($(this).parent().find(".user").get(0)).addClass("teamuserbg");
            });
            //设置用户的上一级 小组长
            $("div[id*='user_0']").each(function () {
                var objDiv = $(this).parent().parent();
                if ($(objDiv).is("div")) {
                    var ChildLen = $(objDiv).children(".fl").length;
                    var cname = "";
                    $(objDiv).children(".fl").each(function (i) {
                        if ($(this).find(".teamfirst").length === 1) {
                            $(this).find(".teamfirst").removeClass("teamfirst");
                            cname = "teamuserbgtop";
                        }
                        else if (i === 0 && ChildLen === 1) {//有且只有一个
                            cname = "teamuserbgone";
                        }
                        else if (i === 0 && ChildLen > 1) {//左边显示
                            cname = "teamuserbgleft";
                        }
                        else if (i + 1 === ChildLen) {//最后一个
                            cname = "teamuserbgright";
                        }
                        else {//中间 只有横线、无竖线
                            cname = "teamuserbgcenter";
                        }
                        $(this).addClass(cname);
                        $(this).css("width", baseWidth);
                        var p = $(this).parent();
                        if ($(p).is("div,.fl")) {
                            $(p).attr("isset", "1");
                        }
                    });
                }
            });
            $("div[isset]").each(function (i) {
                //设置宽
                var objParent = $(this).parent();
                if ($(objParent).is("div,.fl")) {
                    var aryChild = $(objParent).children(".fl");
                    var ChildLen = $(aryChild).length;
                    var cLen = $(this).children(".fl").length;
                    var maxLen = 0;
                    $(aryChild).each(function (i) {
                        if (i === 0 && ChildLen === 1) {//有且只有一个
                            cname = "teamleaderbgone";
                        }
                        else if (i === 0) {//左侧
                            cname = "teamleaderbgleft";
                        }
                        else if (i === ChildLen - 1) {//右侧
                            cname = "teamleaderbgright";
                        }
                        else {
                            cname = "teamleaderbgcenter";
                        }
                        $(this).addClass(cname);
                        if (cLen > maxLen) {
                            maxLen = cLen;
                        }
                    });
                    $(aryChild).each(function () {
                        $(this).width(baseWidth * maxLen);
                    });
                }
                $(this).removeAttr("isset");
            });
            //设置无成员的小组
            $("span.teamitem[id*='item1_0']").each(function () {
                var objParent = $(this).parent().parent().parent();
                if ($(objParent).is("div[class*='fl']")) {
                    if ($(objParent).find("span[class*='user']").length === 0) {
                        $(objParent).attr("isnomember", "1");
                    }
                }
            });
            $("div[isnomember]").each(function () {
                var aryChild = $(this).children(".fl");
                var ChildLen = $(aryChild).length;
                var cname = "";
                $(aryChild).each(function (i) {
                    if (i === 0 && ChildLen === 1) {//有且只有一个
                        cname = "teamleaderbgone";
                    }
                    else if (i === 0) {//左侧
                        cname = "teamleaderbgleft";
                    }
                    else if (i === ChildLen - 1) {//右侧
                        cname = "teamleaderbgright";
                    }
                    else {
                        cname = "teamleaderbgcenter";
                    }
                    $(this).addClass(cname);
                    var len = $(this).children(".fl").length;
                    if (len == 0) { len = 1; }
                    $(this).width(baseWidth * len);
                    $(this).removeAttr("isnomember");
                });
            });
            //设置总监的宽
            var Objzj = $(".teamfirst").parent();
            if ($(Objzj).length > 0) {
                var w = 0;
                $(Objzj).children(".fl").each(function () {
                    w = w + $(this).width();
                });
                w = w > 0 ? w : baseWidth;
                $(Objzj).width(w);
            }
            $(".teamitem,.teamuser").hoverForIE6();
        });
    </script>
</body>
</html>
