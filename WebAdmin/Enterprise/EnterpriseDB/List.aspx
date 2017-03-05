<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebAdmin.Enterprise.EnterpriseDB.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业数据库</title>
    <link href="../../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script type ="text/javascript">
        $(function () {

            //设置默认数据库
            $(".default").click(function () {
                var dbid = $(this).parents("tr").attr("dbid");
                $.ajax({
                    type: "POST",
                    url: "db.ashx",
                    data: { key: "defaultflag", dbid: dbid },
                    success: function (data) {
                        if (data == "1") {
                            reload();
                        }
                        else {
                            alert("操作失败");
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
                    企业数据库
                </th>
            </tr>
            <tr>
                <td>
                    <input id="btnAdd" type="button" style="margin:10px 20px;" onclick="window.location.replace('edit.aspx')" value ="添加" />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="tablist" cellspacing="1" cellpadding="1" style="width:500px;margin:10px 45px;">
                        <tr align="center" style="color: White; background-color: #DADAE9; font-weight: bold;">
                            <th style="width:50px">
                                序号
                            </th>
                            <th>
                                数据库名称
                            </th>
                            <th>
                                当前企业数量
                            </th>
                            <th>
                                最大数量
                            </th>
                            <th style="width:150px;">
                                操作
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <tr dbid="<%#Eval("EnterpriseDBID") %>" class="c">
                                    <td>
                                        <%#Eval("nid") %>
                                    </td>
                                    <td>
                                        <%#Eval("DBName") %>
                                    </td>
                                    <td>
                                        <%#Eval("EnterpriseNum") %>
                                    </td>
                                    <td>
                                        <%#Eval("MaxNum") %>
                                    </td>
                                    <td>                                        
                                        <%#Eval("DefaultFlag").ToString ().Equals("1")?"默认库":"<a href='javascript:void(0);' class='default'>设为默认库</a>" %>
                                        <a href="edit.aspx?dbid=<%#Eval("EnterpriseDBID") %>&type=update">修改</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div style="width:600px;">
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
