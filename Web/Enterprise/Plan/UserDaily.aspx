<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDaily.aspx.cs" Inherits="Web.Enterprise.Plan.UserDaily" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>每日计划完成情况表</title>
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <script type="text/javascript">
        $(function () {
            $(".Wdate").click(function () { WdatePicker(); });

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
        <div class="baritem cur">
            <a href="UserDaily.aspx" style="font-weight: bold; color: Red;">每日</a>
        </div>
        <div class="baritem item">
            <a href="UserMonth.aspx">每月</a>
        </div>
    </div>
    <div id="divTab" class="barInfoList divlist" style="width: 90%;">
        <div class="mar10">
            日期：<asp:TextBox runat="server" ID="txtDate" CssClass="Wdate txt1" />
            <asp:Button runat="server" ID="btnSubmit" CssClass="btn1" Text="查看" OnClick="btnSubmit_Click" />
        </div>
        <div class="mar10">
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
                    <td>
                        新增数量
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltPlanNew" Text="0" />
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltRealNew" Text="0" />
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltPercentNew" Text="0" />%
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltStandardNew" Text="0" />
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltDifferNew" Text="0" />
                    </td>
                </tr>
                <tr class="c">
                    <td>
                        沟通数量
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltPlanExchange" Text="0" />
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltRealExchange" Text="0" />
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltPercentExchange" Text="0" />%
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltStandardExchange" Text="0" />
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltDifferExchange" Text="0" />
                    </td>
                </tr>
            </table>
            <asp:PlaceHolder runat="server" ID="phNoPlan" Visible="false">
                <div style="color: Red;">
                    对不起，未制定该月计划</div>
            </asp:PlaceHolder>
            <p style="color: Red">
                所有名录数量不包含已经删除的名录数据。
            </p>
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=45" type="text/javascript"></script>
</body>
</html>
