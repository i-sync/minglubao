<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnList.aspx.cs" Inherits="WebAdmin.Public.AnnList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".delete").click(function () {
                if (!confirm("确定要删除吗?")) {
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="tableBorder" width="98%"  border="0" align="center">
        <tr>
            <th class="bigTitle">
                公告列表
            </th>
        </tr>
        <tr>
            <td>
                <input type="button" id ="btnAdd" value="发布公告" class="button" onclick="window.location.replace('AnnEdit.aspx');"/>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="1" cellspacing ="1" class ="tablist">
                    <tr>
                        <th style="width:80px;">序号</th>
                        <th>标题</th>
                        <th style="width:120px;">添加时间</th>
                        <th style="width:100px;">操作</th>
                    </tr>
                    <asp:Repeater ID ="rpList" runat="server">
                        <ItemTemplate>
                            <tr class="c">
                                <td>
                                    <%#Eval("nid") %>
                                </td>
                                <td >
                                    <%#Eval("AnnTitle")%>
                                </td>
                                <td>
                                    <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}")%>
                                </td>
                                <td>
                                    <a href="AnnEdit.aspx?aid=<%#Eval("AnnouncementID") %>">修改</a>
                                    <a href="AnnList.aspx?type=delete&aid=<%#Eval("AnnouncementID") %>" class="delete" >删除</a>
                                </td>                        
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <MLB:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                    PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                    TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                    AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                    PageSize="1" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
                    CustomInfoTextAlign="Center" LayoutType="Table"
                    ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
