<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementList.aspx.cs" Inherits="Web.Enterprise.Announcement.AnnouncementList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告列表</title>
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
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
        <h3>公告列表</h3>
    </div>
    <div class="divlist">
        <p><input type="button" id ="btnAdd" value="发布公告" class="btn1" onclick="window.location.replace('AnnouncementEdit.aspx');"/></p>
        <div style="width:50%" class="divlist">
            <table>
                <tr>
                    <td>公告标题：</td>
                    <td>
                        <asp:Label ID ="lblTitle" Text =""  runat ="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>发布时间：</td>
                    <td>
                        <asp:Label ID ="lblAddDate" Text ="" runat ="server"></asp:Label>
                    </td>
                </tr>                
                <tr>
                    <td>公告内容：</td>
                    <td>
                        <asp:Label ID ="lblContent" Text ="" runat ="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        
        <table cellpadding="1" cellspacing ="1" class ="tablist">
            <tr>
                <th>序号</th>
                <th>标题</th>
                <th>内容</th>
                <th>添加时间</th>
            </tr>
            <asp:Repeater ID ="rpList" runat="server">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Eval("nid") %>
                        </td>
                        <td>
                            <%#Eval("AnnTitle") %>
                        </td>
                        <td>
                            <%#Eval("AnnContent") %>
                        </td>
                        <td>
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}")%>
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
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=43" type="text/javascript"></script>
</body>
</html>
