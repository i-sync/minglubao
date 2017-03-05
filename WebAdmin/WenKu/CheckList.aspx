<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckList.aspx.cs" Inherits="WebAdmin.WenKu.CheckList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var CONFIG = {
            POST_URL:"/handler/wenku.ashx"
        };

        ///获取所有选中的id
        function GetIDs() {
            //获取所有选中wenkuid
            var ids = new Array();
            $(".tablist :checkbox[name='cbWenKu']").filter(":checked").each(function () {
                ids.push($(this).val());
            });

            //判断是否选中
            if (ids.length == 0) {
                alert("请选择文库");
                return null;
            }
            return ids.join(',');
        }

        $(function () {
            //全选 
            $.CheckAllOperate("#cbAll", ".tablist :checkbox[name='cbWenKu']");

            //点击删除按钮，删除选中文库
            $("#btnDel").click(function () {
                var ids = GetIDs(); //获取所有选中的id
                if (ids == null)
                    return false;

                if (!confirm("确定要删除吗？")) {
                    return false;
                }
                //异步请求
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "batchdelete", ids: ids },
                    success: function (data) {
                        if (data == "1") {
                            alert("删除成功");
                            window.location = window.location;
                        } else {
                            alert("删除失败");
                        }
                    },
                    dataType: "text"
                });
            });


            ///通过按钮处理事件
            $("#btnPass").click(function () {
                var ids = GetIDs();
                if (ids == null)
                    return false;

                //异步请求修改文库状态
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "updatestatus", ids: ids, status: "1" },
                    success: function (data) {
                        if (data == "1") {
                            alert("修改成功");
                            window.location = window.location;
                        }
                        else {
                            alert("修改失败");
                        }
                    },
                    dataType: "text"
                });
            });

            ///未通过
            $("#btnNotPass").click(function () {
                var ids = GetIDs();
                if (ids == null)
                    return false;

                //异步请求修改文库状态
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "updatestatus", ids: ids, status: "2" },
                    success: function (data) {
                        if (data == "1") {
                            alert("修改成功");
                            window.location = window.location;
                        }
                        else {
                            alert("修改失败");
                        }
                    },
                    dataType: "text"
                });
            });

            //下线
            $("#btnOffLine").click(function () {
                var ids = GetIDs();
                if (ids == null)
                    return false;

                //异步请求修改文库状态
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "updatestatus", ids: ids, status: "3" },
                    success: function (data) {
                        if (data == "1") {
                            alert("操作成功");
                            window.location = window.location;
                        }
                        else {
                            alert("操作失败");
                        }
                    },
                    dataType: "text"
                });
            });

            //转换
            $("#btnConvert").click(function () {
                var ids = GetIDs();
                if (ids == null)
                    return;
                //异步请求转换文库
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "convert", ids: ids },
                    success: function (data) {
                        if (data == "1") {
                            alert("转换需要很长时间，希望你耐心等待！");
                            window.location = window.location;
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
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    文库审核
                </th>
            </tr>
            <tr>
                <td>
                    <div style="float:left;">
                        关键字：<asp:TextBox ID ="txtName" runat="server"></asp:TextBox>
                        <asp:HiddenField ID ="hfStatus" runat="server" />
                    </div>
                    <div style="float:left;">
                        <asp:Button ID="btnSearch" Text="检索"  OnClick="btnSearch_Click" runat="server" />
                    </div>
                    <i style="float:none;">
                </td>
            </tr>
            <tr style="text-align:left;">
                <td>
                    <table class="tablist" cellspacing="1" border="0" cellpadding="1">
                        <tr>
                            <th>
                                <input type="checkbox" id="cbAll" name="cbAll" value="-1" />
                            </th>
                            <th>
                                文档名称
                            </th>
                            <th>
                                介绍
                            </th>
                            <th>
                                分类
                            </th>
                            <th>
                                浏览次数
                            </th>
                            <th>
                                下载次数
                            </th>
                            <th>
                                上传者
                            </th>
                            <th>
                                上传时间
                            </th>
                            <th>
                                状态
                            </th>
                            <th>
                                转换状态
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <tr class="c" id="<%#Eval("WenKuID") %>">
                                    <td>
                                        <input type="checkbox" name="cbWenKu" value="<%#Eval("WenKuID") %>" />
                                    </td>
                                    <td>
                                        <a href="Detail.aspx?id=<%#Eval("WenKuID") %>" target="_blank" ><%#Eval("Caption") %></a>
                                    </td>
                                    <td>
                                        <%#Eval("Intro") %>
                                    </td>
                                    <td>
                                        <%#Eval("WenKuClassName").ToString().Equals("") ? "其它" : Eval("WenKuClassName")%>
                                    </td>
                                    <td>
                                        <%#Eval("ReadNum") %>
                                    </td>
                                    <td>
                                        <%#Eval("DownNum") %>
                                    </td>
                                    <td>
                                        <%#Eval("UserType").ToString().Equals("1") ? Eval("EnterpriseNames") : Eval("RealName")%>
                                    </td>
                                    <td>
                                        <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                                    </td>
                                    <td>
                                        <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.WenKu.EnumStatusFlag>(Eval("StatusFlag")) %>
                                    </td>
                                    <td>
                                        <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.WenKu.EnumSwfFlag>(Eval("swfFlag")) %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" CustomInfoTextAlign="Center"
                        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <%if (WaitAudit)
                      { %>
                    <input type="button" id="btnPass" value ="通过" />
                    <input type ="button" id ="btnNotPass" value="未通过" />
                    <%} if (OffLine)
                      { %>
                    <input type="button" id ="btnOffLine" value="下线" />
                    <%} %>
                    <input type="button" id="btnDel" value ="删除"/>
                    <input type="button" style="display:none;" id ="btnConvert" value ="转换" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
