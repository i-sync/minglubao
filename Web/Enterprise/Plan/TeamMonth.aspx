<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamMonth.aspx.cs" Inherits="Web.Enterprise.Plan.TeamMonth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>本月计划完成情况表</title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <script type="text/javascript" src="../../JS/jquery-1.6.4.js"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
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
            <a href="TeamDaily.aspx">今天</a>
        </div>
        <div class="baritem cur">
            <a href="TeamMonth.aspx" style="font-weight: bold; color: Red;">本月</a>
        </div>
        <div class="baritem item">
            <a href="TeamMonthList.aspx">历史月份</a>
        </div>
    </div>
    <div id="divTab" class="barInfoList divlist" style="width: 90%;">
        <div class="mar10">
        统计时间：<asp:Literal runat="server" ID="ltStartDate" />至
        <asp:Literal runat="server" ID="ltEndDate" />
    </div>
    <div class="divlist" style="width: 500px; margin: 5px auto auto 5px;">
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th>
                    &nbsp;
                </th>
                <th>
                    计划
                </th>
                <th>
                    实际
                </th>
                <th>
                    完成计划百分比
                </th>
                <th>
                    最低指标
                </th>
                <th>
                    差值
                </th>
            </tr>
            <tr class="c">
                <td>录入名录数量</td>
                <td><asp:Literal runat="server" ID="ltPlanNew" Text="0" /></td>
                <td><asp:Literal runat="server" ID="ltRealNew" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltPercentNew" Text="0"/>%</td>
                <td><asp:Literal runat="server" ID="ltStandardNew" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltDifferNew" Text="0"/></td>
            </tr>
            <tr class="c">
                <td>沟通名录数量</td>
                <td><asp:Literal runat="server" ID="ltPlanExchange" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltRealExchange" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltPercentExchange" Text="0"/>%</td>
                <td><asp:Literal runat="server" ID="ltStandardExchange" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltDifferExchange" Text="0"/></td>
            </tr>
            <tr class="c">
                <td>成交数量</td>
                <td><asp:Literal runat="server" ID="ltPlanTrade" Text="0" /></td>
                <td><asp:Literal runat="server" ID="ltRealTrade" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltPercentTrade" Text="0"/>%</td>
                <td><asp:Literal runat="server" ID="ltStandardTrade" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltDifferTrade" Text="0"/></td>
            </tr>
            <tr class="c">
                <td>成交金额</td>
                <td><asp:Literal runat="server" ID="ltPlanMoney" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltRealMoney" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltPercentMoney" Text="0"/>%</td>
                <td><asp:Literal runat="server" ID="ltStandardMoney" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltDifferMoney" Text="0"/></td>
            </tr>
        </table>
        <br />
        <h3>个人计划详情</h3>
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th>姓名</th>
                <th>计划录入数量</th>
                <th>计划沟通数量</th>
            </tr>
            <asp:Repeater ID = "rpList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("TrueName") %>
                        </td>
                        <td>
                            <%#Eval("NewAmount") %>
                        </td>
                        <td>
                            <%#Eval("ContactAmount") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <br />
        <div>
            备注：计划录入、沟通，是查看总监下所有业务的数据总和*当月天数,如上表<br />
                  实际数量通过统计总监下所有业务人员的数据总和<br />
        </div>
    </div>
    </form>
</body>
</html>
