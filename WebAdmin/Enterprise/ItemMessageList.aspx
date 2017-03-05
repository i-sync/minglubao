<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMessageList.aspx.cs" Inherits="WebAdmin.Enterprise.ItemMessageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //删除个人留言
            $(".del").click(function () {
                var mid = $(this).parents("tr").attr("mid");
                $.ajax({
                    type: "GET",
                    url: "handler.ashx",
                    data: { key: "deletemessage", mid: mid },
                    success: function (data) {
                        if (data == "1") {
                            reload();
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
        <table class="tableBorder" width="98%"  border="0" align="center">
            <tr>
                <th class="bigTitle">
                    个人用户留言列表
                </th>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>企业名称</td>
                            <td>
                                <asp:TextBox ID ="txtEPName" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                            <td>项目名称</td>
                            <td>
                                <asp:TextBox ID ="txtItemName" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                            <td>用户名</td>
                            <td>
                                <asp:TextBox ID ="txtUserName" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>手机号</td>
                            <td>
                                <asp:TextBox ID ="txtMobile" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                            <td>邮箱</td>
                            <td>
                                <asp:TextBox ID ="txtEmail" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID ="cbDelFlag" runat="server" Text="已删除" />
                            </td>
                            <td >
                                <asp:Button ID ="Button1" CssClass="btn1" OnClick="btnSearch_Click" runat="server" Text ="检索" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-bottom:20px;padding:20px;">
                        <div style="margin:10px 20px;">
                            <span>留言列表</span>
                            <div style="width:1000px;border-top:1px solid black;padding:20px auto;">
                                <asp:Repeater ID="rpList" runat="server">
                                    <ItemTemplate>
                                        <table style="margin:5px 5px;border-bottom:1px dotted #ccc;width:950px;">
                                            <tr mid="<%#Eval("ID") %>">
                                                <td rowspan="2" style="width:60px;height:60px; vertical-align:top;" >
                                                    <img style="width:40px;height:40px;" src="<%#MLMGC.COMP.Config.GetPersonalAvatarUrl(Eval("Avatar").ToString()) %>" />
                                                </td>
                                                <td>
                                                    <%#Eval("UserName") %>&nbsp;&nbsp;
                                                    <%#Eval("Mobile") %>&nbsp;&nbsp;
                                                    <%#Eval("Tel") %>&nbsp;&nbsp;
                                                    <%#Eval("Email") %>&nbsp;&nbsp;
                                                    <%#Eval("AddDate","{0:yyyy-MM-dd}") %>&nbsp;&nbsp;
                                                    <%#Eval("DelFlag").ToString().Equals("1")?"总监未删除":"总监已删除" %>
                                                </td>
                                                <td rowspan="2" style="width:50px; vertical-align:bottom; text-align:right;">
                                                    <a class="del" href="javascript:void(0);">删除</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><%#Eval("Message") %></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                                PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                                TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                                AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                                PrevPageText="上一页" ShowCustomInfoSection="Left" CustomInfoTextAlign="Center"
                                LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                        </div>        
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
