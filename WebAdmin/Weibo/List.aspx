<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebAdmin.Weibo.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //全选 
            $.CheckAllOperate("#cbAll", ".tablist :checkbox[name='cbWeibo']");

            //点击删除
            $(".del").click(function () {
                //获取微博ID,个人ID
                var ids = $(this).parents("tr").attr("wid");
                //异步请求删除数据
                $.ajax({
                    type: "POST",
                    url: "/handler/weibo.ashx",
                    data: { key: "delete", ids: ids },
                    success: function (data) {
                        if (data == "1") {
                            alert("删除成功");
                            window.location = window.location;
                        }
                        else {
                            alert("删除失败");
                        }
                    },
                    dataType: "text"
                });
            });

            //点击删除按钮处理程序
            $("#btnDelete").click(function () {
                //获取所有选中weiboId
                var ids = new Array();
                $(".tablist :checkbox[name='cbWeibo']").filter(":checked").each(function () {
                    ids.push($(this).val());
                });

                //判断是否选中weibo
                if (ids.length == 0) {
                    alert("请选择要删除微博");
                    return false;
                }

                $.ajax({
                    type: "POST",
                    url: "/handler/weibo.ashx",
                    data: {key:"delete",ids:ids.join(',')},
                    success: function (data) {
                        if (data == "1") {
                            alert("删除成功");
                            window.location = window.location;
                        }
                        else { 
                            alert("删除失败");
                        }
                    },
                    dataType: "text"
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    个人微博管理列表
                </th>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                内容：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDetail" />
                            </td>
                            <td>
                                姓名：
                            </td>
                            <td>
                                <asp:DropDownList ID ="ddlPersonal" runat="server"></asp:DropDownList>
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
                    <table class="tablist" cellspacing="1" border="0" cellpadding="1">
                        <tr>
                            <th>
                                <input type="checkbox" id="cbAll" name="cbAll" value="-1" />
                            </th>
                            <th>
                                姓名
                            </th>
                            <th>
                                内容
                            </th>
                            <th>
                                发布日期
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <tr class="c" wid="<%#Eval("WeiboID") %>">
                                    <td>
                                        <input type="checkbox" name="cbWeibo" value="<%#Eval("WeiboID") %>" />
                                    </td>
                                    <td>                                       
                                        <%#Eval("RealName") %>
                                    </td>
                                    <td>
                                        <%#Eval("Detail") %>
                                    </td>
                                    <td>
                                        <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0);" class="del">删除</a>
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
                </td>                
            </tr>
            <tr>
                <td>
                    <input type="button" id ="btnDelete" value="删除" />
                </td>
            </tr>
        </table>
    </form>

</body>
</html>
