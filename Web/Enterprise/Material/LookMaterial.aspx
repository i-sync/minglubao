<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookMaterial.aspx.cs" Inherits="Web.Enterprise.Material.LookMaterial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目资料列表</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
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
        <h3>项目资料</h3>
    </div>
    <div class="divlist">
        <table cellpadding="1" cellspacing ="1" class ="tablist">
            <tr>
                <th class="num">序号</th>
                <th style=" width:120px;">日期</th>
                <th>标题</th>
            </tr>
            <asp:Repeater ID ="rpList" runat="server">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Container.ItemIndex +1 %>
                        </td>
                        <td>
                            <%#Eval("UpdateDate","{0:yyyy-MM-dd}") %>
                        </td>
                        <td>
                            <a href="<%#MLMGC.COMP.Config.GetEnterpriseMaterialUrl(EnterpriceID,Eval("Url").ToString()) %>" target="_blank"><%#Eval("MaterialName") %></a>
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
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=40" type="text/javascript"></script>
</body>
</html>
