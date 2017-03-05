<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComparisonTeam.aspx.cs" Inherits="Web.Enterprise.Plan.ComparisonTeam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团队对比</title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <script type="text/javascript" src="../../JS/jquery-1.6.4.js"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".Wdate").click(function () { WdatePicker(); });

            //为表格添加滑动样式
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <div class="mar10" style="line-height: 200%;">
        <form id="form1" runat="server">
       时间：<asp:TextBox runat="server" ID="txtStartDate" CssClass="Wdate txt1" />-<asp:TextBox runat="server" ID="txtEndDate" CssClass="Wdate txt1" />
        <asp:Button runat="server" ID="btnSubmit" Text="查看" CssClass="btn1" onclick="btnSubmit_Click" />
        <div class="divlist" style=" margin:10px;">
        <table cellspacing="1" cellpadding="1" class="tablist">
            <tr>
                <th>&nbsp;</th>
                <th>待分配数量</th>
                <th>录入数量</th>
                <th>意向客户</th>
                <th>失败客户</th>
                <th>报废数量</th>
                <th>成交客户</th>
                <th>成交金额</th>
                <th>业务沟通数量</th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                 <tr class="c<%#string.IsNullOrEmpty(Eval("TeamID").ToString())?" red b":"" %>">
                    <td><%#Eval("TeamName")%></td>
                    <td><%#Eval("WaitAmount")%></td>
                    <td><%#Eval("NewAmount")%></td>
                    <td><%#Eval("WishAmount")%></td>
                    <td><%#Eval("NotAmount")%></td>
                    <td><%#Eval("ScrapAmount")%></td>
                    <td><%#Eval("TradedAmount")%></td>
                    <td class="tdmoney"><%#Eval("TradedMoney","{0:F2}")%></td>
                    <td><%#Eval("ExchangeAmount")%></td>
                 </tr>
                </ItemTemplate>
            </asp:Repeater>
            </table>
            </div>
        </form>
    </div>
</body>
</html>
