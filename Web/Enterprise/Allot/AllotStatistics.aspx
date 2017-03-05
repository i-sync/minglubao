<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllotStatistics.aspx.cs"
    Inherits="Web.Enterprise.Allot.AllotStatistics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分配统计</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            分配统计</h3>
    </div>
    <div class="divlist">
        <table>
            <tr>
                <td>
                    分配时间：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="Wdate txt1" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" />
                    ——
                    <asp:TextBox runat="server" ID="txtEndDate" CssClass="Wdate txt1" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSubmit" Text="查看" CssClass="btn1" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="divlist">
        <table class="tablist" cellpadding="1" cellspacing="1" style="width: 80%">
            <tr>
                <th class="num">
                    序号
                </th>
                <th style="width: 120px">
                    日期
                </th>
                <th>
                    分配方式
                </th>
                <th>
                    分配类型
                </th>
                <th>
                    分配数量
                </th>
                <th>
                    剩余数量
                </th>
                <th>
                    分配情况
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Eval("nid") %>
                        </td>
                        <td>
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                        </td>
                        <td>
                            <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.Enterprise.EnumType>(Eval("AllotType")) %>
                        </td>
                        <td>
                            <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.Enterprise.EnumMode>(Eval("Mode"))%>
                        </td>
                        <td>
                            <%#Eval("Num")%>
                        </td>
                        <td>
                            <%#Eval("Surpluse")%>
                        </td>
                        <td>
                            <%#Eval("Detail")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=54" type="text/javascript"></script>
</body>
</html>
