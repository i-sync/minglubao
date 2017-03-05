<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebAdmin.Enterprise.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人用户列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <link href="../My97DatePicker/skin/WdatePicker.css" type="text/css" rel="Stylesheet" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //启用、禁用
            $(".status").click(function () {
                var aryStatus = new Array();
                aryStatus[0] = "启用";
                aryStatus[1] = "禁用";
                var status = $(this).attr("status");
                status = Math.abs(status - 1);
                var trObj = $(this).parents("tr");
                var _Obj = $(this);
                var eid = $(trObj).attr("eid");
                $.ajax({
                    type: "GET",
                    url: "Handler.ashx",
                    data: { key: "status", eid: eid, status: status },
                    success: function (data) {
                        if (data == "1") {
                            $(_Obj).attr("status", status);
                            $(_Obj).text(aryStatus[status]);
                            alert("操作成功");
                        } else {
                            alert("操作失败");
                        }
                    },
                    dataType: "text"
                });
            });

            //删除企业用户
            $(".del").click(function () {
                if (!confirm("确认要删除吗？"))
                    return false;
                var trObj = $(this).parents("tr");
                var eid = $(trObj).attr("eid");
                alert(eid);
                $.ajax({
                    type: "GET",
                    url: "Handler.ashx",
                    data: { key: "delete", eid: eid },
                    success: function (data) {
                        if (data == "1") {
                            alert("删除成功");
                            reload();
                        }
                        else {
                            alert("删除失败" + data);
                        }
                    },
                    dataType: "text"
                });
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableBorder" width="98%"  border="0"
        align="center">
        <tr>
            <th class="bigTitle">
                企业用户列表
            </th>
        </tr>
        <tr>
            <td>
                <table style="text-align: center">
                    <tr>
                        <td>
                            企业名称：
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEnterpriseNames" />
                        </td>
                        <td>
                            到期日期：
                        </td>
                        <td>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtStartDate"
                                runat="server" />
                            <span>---</span>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtEndDate"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            到期日期为<asp:TextBox runat="server" ID="txtDay" Width="30" />
                            天内，为报警企业 。
                        </td>
                        <td colspan="2">
                            <asp:Button runat="server" ID="btnSearch" Text="检索" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tablist" cellspacing="1" cellpadding="1">
                    <tr align="center" style="color: White; background-color: #DADAE9; font-weight: bold;">
                        <th>
                            序号
                        </th>
                        <th>
                            企业名称
                        </th>
                        <th>
                            企业号
                        </th>
                        <th>
                            开通日期
                        </th>
                        <th>
                            到期日期
                        </th>
                        <th style="width:80px;">
                            购买用户数量
                        </th>
                        <th style="width:80px;">
                            当前用户数量
                        </th>
                        <th style="width:80px;">
                            名录数量
                        </th>
                        <th>
                            状态
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                            <tr eid="<%#Eval("EnterpriseID") %>" class="c<%#MLMGC.COMP.Data.GetWarning(Convert.ToDateTime(Eval("ExpireDate")),day) %>">
                                <td>
                                    <%#Eval("nid") %>
                                </td>
                                <td>
                                    <%#Eval("EnterpriseNames") %>
                                </td>
                                <td>
                                    <%#Eval("EnterpriseCode") %>
                                </td>
                                <td>
                                    <%#Eval("StartDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%#Eval("ExpireDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%#Eval("UserAmount") %>
                                </td>
                                <td>
                                    <%#Eval("UserNum") %>
                                </td>
                                <td>
                                    <%#Eval("ClientNum") %>
                                </td>
                                <td>
                                    <%#Status(Eval ("ExpireDate")) %>
                                </td>
                                <td>
                                    <a href="#" class="status" status="<%#Eval("Status")%>"><%#Eval("Status").ToString().Equals("0")?"启用":"禁用"%></a> 
                                    <a href="AddEnterprise.aspx?type=update&eid=<%#Eval("EnterpriseID") %>">修改</a>
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
