<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComparisonDate.aspx.cs"
    Inherits="Web.Enterprise.Plan.ComparisonDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>时间对比</title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <script type="text/javascript" src="../../JS/jquery-1.6.4.js"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //--------设置默认对比方式
            var flag = $.GetQueryString("flag");
            if (flag == "month") {
                $("#cbTypeMonth").attr("checked", true);
            }
            else {
                $("#cbTypeDay").attr("checked", true);
            }
            //----点击对比方式-----
            $(":radio[name='cbType']").change(function () {
                location.href = "ComparisonDate.aspx?flag=" + $(this).val();
            });
            //----点击对应月份-----------
            $(":checkbox").click(function () {
                $(".tablist tr").eq($(this).val()).toggle();
            });
            $(":checkbox").each(function () {
                $(this).attr("checked", true);
            });

            //为表格添加滑动样式
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <div class="mar10" style=" line-height:200%;">
        <form id="form1" runat="server">
        <div>
            对比方式：
            <input type="radio" name="cbType" id="cbTypeDay" value="day" /><label for="cbTypeDay">按本月天对比</label>
            <input type="radio" name="cbType" id="cbTypeMonth" value="month" /><label for="cbTypeMonth">按月对比(最近六个月的数据)</label>
        </div>
        <div>
            <asp:Repeater runat="server" ID="rpListDate">
                <ItemTemplate>
                    <div style=" float:left; display:inline-block; width:100px;"><input type="checkbox" id="cbDate<%#Container.ItemIndex+1 %>" name="cbDate" value="<%#Container.ItemIndex+1 %>" /><label
                        for="cbDate<%#Container.ItemIndex+1 %>"><%#Eval("DateCode","{0:yyy-MM-dd}")%></label></div>
                </ItemTemplate>
            </asp:Repeater>
            <i class="clear"></i>
        </div>
        <div class="divlist" style="width: 98%; margin: auto;">
            <table cellpadding="1" cellspacing="1" class="tablist">
                <tr>
                    <th>
                        日期
                    </th>
                    <th>
                        录入数量
                    </th>
                    <th>
                        意向客户
                    </th>
                    <th>
                        失败客户
                    </th>
                    <th>
                        报废数量
                    </th>
                    <th>
                        成交客户
                    </th>
                    <th>
                        成交金额
                    </th>
                    <th>
                        沟通数量
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpList">
                    <ItemTemplate>
                        <tr class="c">
                            <td>
                                <%#Eval("DateCode", "{0:yyy-MM-dd}")%>
                            </td>
                            <td>
                                <%#Eval("NewAmount")%>
                            </td>
                            <td>
                                <%#Eval("WishAmount")%>
                            </td>
                            <td>
                                <%#Eval("NotAmount")%>
                            </td>
                            <td>
                                <%#Eval("ScrapAmount")%>
                            </td>
                            <td>
                                <%#Eval("TradedAmount")%>
                            </td>
                            <td class="tdmoney">
                                <%#Eval("TradedMoney","{0:F2}")%>
                            </td>
                            <td>
                                <%#Eval("ExchangeAmount")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        </form>
    </div>
</body>
</html>
