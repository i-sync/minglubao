<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="Web.Enterprise.Material.QuestionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>调查问卷</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //为表格添加滑动样式
            $.Hover(".tablist tr");

            //判断是否删除
            $(".del").click(function () {
                var result = confirm("确认要删除吗？");
                if (!result)
                    return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="nav">
            <h3>
                调查问卷</h3>
        </div>
        <div class="divlist">
            <!--<div class="redtip">
                <ul>
                    <li>总监常常要求业务员掌握客户情况，但您需要掌握的客户情况是什么呢？请设置问卷内容，并要求业务员按此问卷向客户提问。</li>
                    <li>记住，会提问，才是主动业务的法宝，总监先生，对么？</li>
                </ul>
            </div>-->
            <input type="button" id="btnAdd" value="添加" class="btn1" onclick="window.location.replace('QuestionEdit.aspx?type=add');" />
            <div style="margin: 4px;">
                <span>标题：</span>
                <asp:TextBox ID="txtQuestionName" CssClass="txt1" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" Text="检索" CssClass="btn1" OnClick="btnSearch_Click" runat="server" />
            </div>
            <table cellpadding="1" cellspacing="1" class="tablist">
                <tr>
                    <th class="num">
                        序号
                    </th>
                    <th>
                        标题
                    </th>
                    <th>
                        类型
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rpList" runat="server">
                    <ItemTemplate>
                        <tr class="c">
                            <td>
                                <%#Eval("nid") %>
                            </td>
                            <td>
                                <%#Eval("QuestionName") %>
                            </td>
                            <td>
                                <%# GetQuestionType(Eval("QuestionType"))%>
                            </td>
                            <td>
                                <a href="QuestionEdit.aspx?type=update&questionid=<%#Eval("QuestionID") %>">修改</a>
                                <a class="del" href="QuestionList.aspx?type=delete&questionid=<%#Eval("QuestionID") %>">
                                    删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=15" type="text/javascript"></script>
</body>
</html>
