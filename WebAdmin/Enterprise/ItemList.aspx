<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="WebAdmin.Enterprise.ItemList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业用户列表</title>
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //点击删除
            $(".del").click(function () {
                if (confirm("确定要删除吗？一旦删除数据无法恢复。")) {
                    var eid = $(this).parents("tr").attr("eid");
                    $.ajax({
                        type: "GET",
                        url: "handler.ashx",
                        data: { key: "itemdelete", eid: eid },
                        success: function (data) {
                            if (data == "1") {
                                alert("操作成功");
                                reload();
                            }
                            else {
                                alert("操作失败" + data);
                            }
                        },
                        dataType: "text"
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableBorder" width="98%"  border="0" align="center">
        <tr>
            <th class="bigTitle">
                企业用户列表
            </th>
        </tr>
        <tr>
            <td>
                <span>名称：</span>
                <asp:TextBox ID="txtName" CssClass="txt" Width="500" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID ="btnSearch" CssClass="btn1" OnClick="btnSearch_Click" runat="server" Text ="检索" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="tablist" cellspacing="1" cellpadding="1">
                    <tr align="center" style="color: White; background-color: #DADAE9; font-weight: bold;">
                        <th style="width:50px">
                            序号
                        </th>
                        <th>
                            名称
                        </th>
                        <th>
                            简介
                        </th>
                        <th style="width:120px;">
                            添加日期
                        </th>
                        <th style="width:120px;">
                            修改日期
                        </th>
                        <th style="width:120px;">
                            成立日期
                        </th>
                        <th style="width:120px;">
                            状态
                        </th>
                        <th style="width:120px;">
                            开通状态
                        </th>
                        <th style="width:120px;">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                            <tr eid="<%#Eval("EnterpriseID") %>" iid="<%#Eval("ItemID") %>" class="c">
                                <td>
                                    <%#Eval("nid") %>
                                </td>
                                <td>
                                    <a href="ItemInfo.aspx?eid=<%#Eval("EnterpriseID") %>&iid=<%#Eval("ItemID") %>" > <%#Eval("ItemName") %> </a>
                                </td>
                                <td>
                                    <%#Eval("ItemIntro") %>
                                </td>
                                <td>
                                   <%#Eval("AddDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%#Eval("UpdateDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%#Eval("Established", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%#Status(Eval("Status")) %>
                                </td>
                                <td>
                                    <%#OpenFlag(Eval("OpenFlag")) %>
                                </td>
                                <td>
                                    <a href="javascript:void(0);" class="del">删除</a>
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
