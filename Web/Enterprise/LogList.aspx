<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="Web.Enterprise.LogList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日志列表</title>
    <link href="/Styles/Site.css" rel ="Stylesheet" type ="text/css" />
    <script src ="/JS/jquery-1.6.4.js" type ="text/javascript" language="javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>操作日志</h3>
    </div>
    <div class="divlist">
        <table>
            <tr>
                <td>查询对象：</td>
                <td>
                    <asp:DropDownList ID ="ddlObject" CssClass="ddl" runat="server"></asp:DropDownList>
                </td>
                <td>&nbsp;&nbsp;时间：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStartDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" CssClass="Wdate txt1" />
                    --
                    <asp:TextBox runat="server" ID="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" CssClass="Wdate txt1" />
                </td>
                <td>
                    <asp:Button ID ="btnSearch" runat="server" CssClass="btn" Text = "检索" OnClick ="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnClearPart" runat="server" CssClass="btn" Text="清空三个月之前的日志" OnClick="btnClearPart_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClearAll" runat="server" CssClass="btn" Text = "清空所有日志" OnClick="btnClearAll_Click" />                
                </td>
            </tr>
        </table>

        <table cellpadding="1" cellspacing ="1" class ="tablist top10">
            <tr>
                <th class="num">序号</th>
                <th style="width:100px;">用户</th>
                <th>操作</th>
                <th style="width:100px;">IP地址</th>
                <th style="width:120px;">操作时间</th>
            </tr>
            <asp:Repeater ID ="rpList" runat="server">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Eval("nid") %>
                        </td>
                        <td>
                            <%#Eval("TrueName") %>
                        </td>
                        <td>
                            <%#Eval("LogTitle") %>
                        </td>
                        <td>
                            <%#Eval("IP") %>
                        </td>
                        <td>
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            
        </table>
        <MLB:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
            PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
            TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
            AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
            PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
            LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=57" type="text/javascript"></script>
</body>
</html>
