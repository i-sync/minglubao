<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateNotTraded.aspx.cs"
    Inherits="Web.Enterprise.Config.StateNotTraded" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>失败理由设置</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/core.css" rel="Stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="../../JS/popup_layer.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var URL_CONFIG = {
            Post_URL: "../EPHandler.ashx"
        };
        var pl;
        $(function () {
            pl = new PopupLayer({ title: "失败理由设置", popupBlk: "#divNotTradedInfo", useOverlay: "true" });
            $("#btnAdd").click(function () {
                $("#txtName").val("");
                $("#txtPercent").val("");
                $("#divNotTradedInfo").attr("type", "add");
                $("#divNotTradedInfo").attr("nottradedid", "0");
                pl.Show();
            });
            $(".update").click(function () {
                var trObj = $(this).parents("tr");
                var nottradedid = $(trObj).attr("nottradedid");
                var data = "key=815&nottradedid=" + nottradedid + "&t=" + Math.random();
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (parseInt(msg.id) > 0) {
                        $("#txtName").val(msg.name);
                        $("#txtPercent").val(msg.percent);

                        $("#divNotTradedInfo").attr("type", "update");
                        $("#divNotTradedInfo").attr("nottradedid", msg.id);
                        pl.Show();
                    } else {
                        PopTip.Show(PopTip.Type.Tips, "指定理由不存在", false);
                    }
                }, "json");
            });
            $(".del").click(function () {
                var result = confirm("确认要删除吗？");
                if (!result)
                    return false;
                var trObj = $(this).parents("tr");
                var nottradedid = $(trObj).attr("nottradedid");
                var data = "key=814&nottradedid=" + nottradedid;
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "-1") {
                        PopTip.Show(PopTip.Type.Error, "该失败理由已被使用无法删除", false);
                    } else if (msg == "0") {
                        PopTip.Show(PopTip.Type.Error, "删除失败", false);
                    } else {
                        PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                    }
                }, "text");
            });
            $("#txtName").blur(function () {
                var name = $.trim($(this).val());
                if (name.length == 0) {
                    $("#TipsName").html("<span class='error'>名称不能为空，请输入名称</span>");
                    return false;
                }
                else if (name.length > 64) {
                    $("#TipsName").html("<span class='error'>名称过长，请检查</span>");
                    return false;
                }
                var nottradedid = $("#divNotTradedInfo").attr("nottradedid");
                var data = "key=811&nottradedid=" + nottradedid + "&name=" + escape(name);
                $("#TipsName").html("检测中..");
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "0") {
                        msg = "<span class='succ'>该名称可以使用</span>";
                    } else {
                        msg = "<span class='error'>这个名称已经被使用，请换一个吧</span>";
                    }
                    $("#TipsName").html(msg);
                }, "text");
            });
            $("form").submit(function () { $("#btnSubmit").trigger("click"); });
            $("#btnSubmit").click(function () {
                if ($(".error").length > 0) {
                    return false;
                }
                var type = $("#divNotTradedInfo").attr("type");
                var nottradedid = $("#divNotTradedInfo").attr("nottradedid");
                var name = $("#txtName").val();
                if (name == "")
                    return;
                var percent = parseInt($("#txtPercent").val());

                var data = "";
                if (type == "add") {
                    data = "key=812&name=" + escape(name) + "&percent=" + percent;
                } else {
                    data = "key=813&nottradedid=" + nottradedid + "&name=" + escape(name) + "&percent=" + percent;
                }
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    msg = parseInt(msg);
                    if (msg > 0) {
                        PopTip.Show(PopTip.Type.Succ, "提交成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "提交失败", false);
                    }
                }, "text");
            });
            $("#btnCancel").click(function () {
                $("#divNotTradedInfo").removeAttr("type");
                $("#divNotTradedInfo").removeAttr("nottradedid");
                pl.PopClose();
            });

            //为表格添加滑动样式
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            失败理由设置</h3>
    </div>
    <div class="divlist">
        <p>
            <input type="button" id="btnAdd" value="添加新状态" class="btn" />
        </p>
        <table cellpadding="1" cellspacing="1" class="tablist w620">
            <tr>
                <th class="num">
                    序号
                </th>
                <th>
                    失败状态名称
                </th>
                <th class="operate">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c" nottradedid="<%#Eval("nottradedid") %>">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <%#Eval("NotTradedName") %>
                        </td>
                        <td>
                            <a href="javascript:void(0);" class="update">修改</a>&nbsp;&nbsp;<a href="javascript:void(0);"
                                class="del">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="width: 650px; border: 1px solid #ccc; background-color: White; height: 150px;"
        id="divNotTradedInfo">
        <table style="margin-top: 10px; margin-left: 10px;">
            <tr>
                <td style="text-align: right">
                    状态名称：
                </td>
                <td>
                    <input type="text" id="txtName" class="txt w500" />
                </td>
            </tr>
            <tr style="height: 20px;">
                <td>
                    &nbsp;
                </td>
                <td id="TipsName">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <input type="button" id="btnSubmit" value="确定" class="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnCancel" value="取消" class="btn" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=6" type="text/javascript"></script>
</body>
</html>
