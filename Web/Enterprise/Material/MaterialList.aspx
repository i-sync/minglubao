<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialList.aspx.cs" Inherits="Web.Enterprise.Material.MaterialList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目资料列表</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
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
    <div class="nav">
        <h3>
            项目资料</h3>
    </div>
    <div class="divlist">
        <p>
            <input type="button" class="btn1" id="btnAdd" value="添加" onclick="window.location.replace('MaterialEdit.aspx?type=add');" /></p>
        <table cellpadding="1" cellspacing="1" class="tablist top10">
            <tr>
                <th class="num">
                    序号
                </th>
                <th style="width: 100px;">
                    操作
                </th>
                <th>
                    标题
                </th>
                <th class="date">
                    日期
                </th>
                <th style="width:100px;">
                    共享状态
                </th>
            </tr>
            <asp:Repeater ID="rpList" runat="server">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <a href="MaterialEdit.aspx?type=update&materialid=<%#Eval("MaterialID") %>">修改</a>                            
                            <a class="del" href="MaterialList.aspx?type=delete&materialid=<%#Eval("MaterialID") %>">
                                删除</a>
                        </td>
                        <td style="text-align: left; padding-left: 10px;">
                            [<%#Eval("ClassName") %>] <a href="<%#MLMGC.COMP.Config.GetEnterpriseMaterialUrl(EnterpriceID,Eval("Url").ToString()) %>"
                                target="_blank">
                                <%#Eval("MaterialName") %></a>
                        </td>
                        <td>
                            <%#Eval("UpdateDate","{0:yyyy-MM-dd HH:mm}") %>
                        </td>
                        <td>
                            <%# Share(Eval("WenKuFlag"),Eval("MaterialID")) %>
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
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=13" type="text/javascript"></script>
</body>
</html>
