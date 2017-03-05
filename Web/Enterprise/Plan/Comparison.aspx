<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comparison.aspx.cs" Inherits="Web.Enterprise.Plan.Comparison" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>对比分析</title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                $(".red").removeClass("red");
                $(this).addClass("red");
            });

            $("#lookbar .baritem").click(function () {
                if ($(this).attr("class").indexOf("cur") > 0) {
                    return false;
                }
                var i = $("#lookbar .baritem").index(this);
                $("#lookbar .cur").removeClass("cur").addClass("item");
                $(this).removeClass("item").addClass("cur");
            });
            //默认显示第一个
            var obj = $("#lookbar .baritem").get(0);
            $(obj).triggerHandler("click");
            window.open($(obj).find("a").attr("href"), $(obj).find("a").attr("target"));
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            对比分析</h3>
    </div>
    <div id="lookbar">
        <asp:Repeater runat="server" ID="rpList">
            <ItemTemplate>
                <div class="baritem item">
                    <a href="ComparisonTeam.aspx?tmrid=<%#Eval("TeamModelRoleID") %>" target="ifrmain"><%#Eval("RoleName")%>对比</a></div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="baritem item">
            <a href="ComparisonUser.aspx" target="ifrmain">销售人员对比</a></div>
        <div class="baritem item">
            <a href="ComparisonDate.aspx" target="ifrmain">时间对比</a>
        </div>
        <%if (SourceFlag)
          { %><div class="baritem item">
              <a href="ComparisonProperty.aspx?flag=source" target="ifrmain">来源对比</a>
          </div>
        <%} %>
        <%if (AreaFlag)
          { %><div class="baritem item">
              <a href="ComparisonProperty.aspx?flag=area" target="ifrmain">地区对比</a>
          </div>
        <%} %>
        <%if (TradeFlag)
          {%><div class="baritem item">
              <a href="ComparisonProperty.aspx?flag=trade" target="ifrmain">行业对比</a>
          </div>
        <%} %>
    </div>
    <div id="divTab" class="barInfoList" style="min-width: 500px; width: 90%; height: 460px;">
        <iframe src="about:blank" id="ifrmain" name="ifrmain" frameborder="0" style="width: 100%;
            height: 100%; margin: 0;"></iframe>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=47" type="text/javascript"></script>
</body>
</html>
