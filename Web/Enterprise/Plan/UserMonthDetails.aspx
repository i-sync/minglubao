<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMonthDetails.aspx.cs" Inherits="Web.Enterprise.Plan.UserMonthDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看每月完成情况</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
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
        查看每月完成情况</h3>
    </div>
    <div class="divlist">
        <div >
            <span style=" color:Red; font-weight:bold;"><asp:Literal ID ="ltYearMonth" runat="server"></asp:Literal></span>
            <span>完成情况</span>
        </div>
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th>
                </th>
                <th>
                    计划
                </th>
                <th>
                    完成
                </th>
                <th>
                    完成计划比例
                </th>
                <th>
                    最低指标
                </th>
                <th>
                    差值
                </th>
            </tr>
            <tr class="c">
                <td>新增数量</td>
                <td><asp:Literal runat="server" ID="ltPlanNew" Text="0" /></td>
                <td><asp:Literal runat="server" ID="ltRealNew" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltPercentNew" Text="0"/>%</td>
                <td><asp:Literal runat="server" ID="ltStandardNew" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltDifferNew" Text="0"/></td>
            </tr>
            <tr class="c">
                <td>沟通数量</td>
                <td><asp:Literal runat="server" ID="ltPlanContact" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltRealContact" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltPercentContact" Text="0"/>%</td>
                <td><asp:Literal runat="server" ID="ltStandardContact" Text="0"/></td>
                <td><asp:Literal runat="server" ID="ltDifferContact" Text="0"/></td>
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
        <div class="listcon">
            <input type="button" value="返回" class="btn1" onclick="window.location.replace('UserMonth.aspx');" />
        </div>
    </div>
    </form>
</body>
</html>
