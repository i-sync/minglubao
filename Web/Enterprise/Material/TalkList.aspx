<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalkList.aspx.cs" Inherits="Web.Enterprise.Material.TalkList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>销售话术</title>
    <link href="../../Styles/Site.css" rel="Stylesheet" type="text/css" />
    <link href="../../Styles/core.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript" language="javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/popup_layer.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var pl;
        $(document).ready(function () {
            pl = new PopupLayer({ title: "话术预览", popupBlk: "#divPreviewTalk", useOverlay: "true" });
            $("#btnAdd").click(function () {
                window.location.replace("TalkEdit.aspx?type=add&max=<%=max+1 %>");
            });

            //为表格添加滑动样式
            $.Hover(".tablist tr");

            //显示话术预览
            $("#btnPreview").click(function () {
                $("#divPreviewTalk").show();
                $("#divPreviewTalk").html("加载中...");
                $("#divPreviewTalk").load("../ClientInfo/Info/Talk.aspx");
                pl.Show();
            });

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
            销售话术</h3>
    </div>
    <div class="divlist">
        <p>
            <input type="button" id="btnAdd" value="添加" class="btn1" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" id="btnPreview" value="预览" class="btn1" />
        </p>
        <table cellpadding="1" cellspacing="1" class="tablist top10">
            <tr>
                <th class="num">
                    序号
                </th>
                <th style="width: 100px;">
                    操作
                </th>
                <th>
                    话术标题
                </th>
                <th class=" num">
                    排序值
                </th>
            </tr>
            <asp:Repeater ID="rpList" runat="server">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <a href="TalkEdit.aspx?type=update&talkid=<%#Eval("TalkID") %>">修改</a> <a class="del"
                                href="TalkList.aspx?actionname=delete&talkid=<%#Eval("TalkID") %>">删除</a>
                        </td>
                        <td style="text-align: left; padding-left: 10px;" title='<%#Eval("Detail") %>'>
                            <%#Eval("TalkSubject") %>
                        </td>
                        <td>
                            <%#Eval("Sort")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--话术预览-->
        <div id="divPreviewTalk" style="display: none; width: 780px; height: 400px; overflow: auto;
            background-color: White; padding: 15px">
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=9" type="text/javascript"></script>
</body>
</html>
