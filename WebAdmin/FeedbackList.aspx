<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="WebAdmin.FeedbackList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>反馈信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script type="text/javascript" src="js/jquery-1.6.4.js"></script>
    <script type="text/javascript" src="js/common.js"></script>
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <link type="text/css" rel="Stylesheet" href="My97DatePicker/skin/WdatePicker.css" />
    <link href="images/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableBorder" width="98%" align="center"
        border="0">
        <tr>
            <th class="bigTitle">
                <b>反馈信息 </b>
            </th>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            用户类型：
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbUserType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Text="全部" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="企业用户" Value="1"></asp:ListItem>
                                <asp:ListItem Text="个人用户" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            提交时间：
                        </td>
                        <td>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtStartDate"
                                runat="server" />
                            <span>---</span>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtEndDate"
                                runat="server" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnSearch" Text="检索" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tablist" cellspacing="1" cellpadding="1">
                    <tr>
                        <th>
                            序号
                        </th>
                        <th>
                            标题
                        </th>
                        <th>
                            用户
                        </th>
                        <th>
                            日期
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                            <tr class="c">
                                <td>
                                    <%#Eval("nid") %>
                                </td>
                                <td title="<%#Eval("Detail") %>">
                                    <a href="FeedbackDetail.aspx?id=<%#Eval("FeedbackID") %>">
                                        <%#Eval("Subject") %></a>
                                </td>
                                <td>
                                    <%#Eval("UserName") %>
                                </td>
                                <td>
                                    <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div>
                    <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
