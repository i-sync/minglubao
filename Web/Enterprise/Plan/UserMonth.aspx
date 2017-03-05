<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMonth.aspx.cs" Inherits="Web.Enterprise.Plan.UserMonth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>每月完成情况</title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //为表格添加滑动样式
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
        计划完成情况</h3>
    </div>
    <div id="lookbar">
        <div class="baritem item">
            <a href="UserDaily.aspx">每日</a>
        </div>
        <div class="baritem cur">
            <a href="UserMonth.aspx"  style="font-weight: bold; color: Red;">每月</a>
        </div>
    </div>
    <div id="divTab" class="barInfoList" style="width: 90%;">
    <div class="divlist" style="margin:5px auto; width:98%;">
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th>月份</th>
                <th>录入数量/实际数量</th>
                <th>沟通数量/实际数量</th>
                <th>成交数量/实际数量</th>
                <th>成交金额/实际金额</th>
                <th>操作</th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
            <ItemTemplate>
                <tr class="c">
                    <td>
                        <%#Eval("YearMonth") %>
                    </td>
                    <td>
                        <%#GetMonthPlan(Eval("YearMonth"),Eval("NewAmount"))%>/
                        <%#Eval("RealNewAmount")%>
                    </td>
                    <td>
                        <%#GetMonthPlan(Eval("YearMonth"),Eval("ContactAmount")) %>/
                        <%#Eval("RealExchAmount")%>
                    </td>
                    <td>
                        <%#Eval("TradedAmount") %>/
                        <%#Eval("RealTradedAmount")%>
                    </td>
                    <td>
                        <%#Eval("TradedMoney","{0:f2}") %>/
                        <%#Eval("RealTradedMoney","{0:f2}")%>
                    </td>
                    <td><a href="UserMonthDetails.aspx?planid=<%#Eval("YearMonth") %>">查看</a></td>
                </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        <p style="color:Red">
        所有名录数量不包含已经删除的名录数据。
        </p>
    </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=45" type="text/javascript"></script>
</body>
</html>
