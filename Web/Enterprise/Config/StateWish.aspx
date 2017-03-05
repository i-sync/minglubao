<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateWish.aspx.cs" Inherits="Web.Enterprise.Config.StateWish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>意向进展设置</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/core.css" rel="stylesheet" type="text/css" />
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
            pl = new PopupLayer({ title: "意向进展设置", trigger: "#btnAdd", popupBlk: "#divWishInfo", closeBtn: "#btnCancel", useOverlay: "true" });
            $("#btnAdd").click(function () {
                $("#txtName").val("");
                $("#txtPercent").val("");
                $("#divWishInfo").attr("type", "add");
                $("#divWishInfo").attr("wishid", "0");
                $("#TipsName").html("");
                $("#TipsPercent").html("");
                pl.Show();
            });
            $(".update").click(function () {
                var trObj = $(this).parents("tr");
                var wishid = $(trObj).attr("wishid");
                var data = "key=805&wishid=" + wishid + "&t=" + Math.random();
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (parseInt(msg.id) > 0) {
                        $("#txtName").val(msg.name);
                        $("#txtPercent").val(msg.percent);
                        $("#TipsName").html("");
                        $("#TipsPercent").html("");
                        $("#divWishInfo").attr("type", "update");
                        $("#divWishInfo").attr("wishid", msg.id);
                        pl.Show();
                    } else {
                        PopTip.Show(PopTip.Type.Tips, "指定行业不存在", false);
                    }
                }, "json");
            });
            $(".del").click(function () {
                var result = confirm("确认要删除吗？");
                if (!result)
                    return false;
                var trObj = $(this).parents("tr");
                var wishid = $(trObj).attr("wishid");
                var data = "key=804&wishid=" + wishid;
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "-1") {
                        PopTip.Show(PopTip.Type.Error, "该意向已被使用无法删除", false);
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
                var wishid = $("#divWishInfo").attr("wishid");
                var data = "key=801&wishid=" + wishid + "&name=" + escape(name);
                $("#TipsName").html("<span class='ing'>检测中..</span>");
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "0") {
                        msg = "<span class='succ'>该名称可以使用</span>";
                    } else {
                        msg = "<span class='error'>这个名称已经被使用，请换一个吧</span>";
                    }
                    $("#TipsName").html(msg);
                }, "text");
            }).submit(function () { $("#btnSubmit").trigger("click"); });
            $("#txtPercent").blur(function () {
                var percent = parseInt($(this).val());
                var msg = "";
                if (percent > 0 && percent < 100) {
                    msg = "<span class='succ'>输入正确</span>";
                }
                else {
                    msg = "<span class='error'>输入错误，范围：1--100之内</span>";
                }
                $("#TipsPercent").html(msg);
            }).submit(function () { $("#btnSubmit").trigger("click"); });
            $("#btnSubmit").click(function () {
                if ($(".error").length > 0) {
                    return false;
                }
                var type = $("#divWishInfo").attr("type");
                var wishid = $("#divWishInfo").attr("wishid");
                var name = $("#txtName").val();
                var percent = parseInt($("#txtPercent").val());

                var data = "";
                if (type == "add") {
                    data = "key=802&name=" + escape(name) + "&percent=" + percent;
                } else {
                    data = "key=803&wishid=" + wishid + "&name=" + escape(name) + "&percent=" + percent;
                }
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    msg = parseInt(msg);
                    if (msg > 0) {
                        PopTip.Show(PopTip.Type.Succ, "提交成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "提交失败", true);
                    }
                }, "text");
            });
            $("#btnCancel").click(function () {
                $("#divWishInfo").removeAttr("type");
                $("#divWishInfo").removeAttr("wishid");
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
            意向进展设置</h3>
    </div>
    <div class="divlist">
        <p>
            <input type="button" id="btnAdd" value="添加新状态" class="btn" /></p>
        <table cellpadding="1" cellspacing="1" class="tablist w620">
            <tr>
                <th class="num">
                    序号
                </th>
                <th>
                    名称
                </th>
                <th>
                    意向程度
                </th>
                <th class="operate">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c" wishid="<%#Eval("wishid") %>">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <%#Eval("WishName") %>
                        </td>
                        <td>
                            <%#Eval("WishPercent")%>
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
    <div style="width: 600px; border: 1px solid #ccc; display: none; background-color: White;
        height: 200px;" id="divWishInfo">
        <br />
        <table>
            <tr>
                <td align="right" style="color: Black;">
                    名称：
                </td>
                <td colspan="2">
                    <input type="text" id="txtName" class="txt w500" />
                </td>
            </tr>
            <tr style="height: 20px;">
                <td>
                    &nbsp;
                </td>
                <td id="TipsName" colspan="2">
                </td>
            </tr>
            <tr style="height: 20px;">
                <td align="right">
                    意向程度：
                </td>
                <td style="width: 140px;">
                    <input type="text" id="txtPercent" class="txt w120" />
                </td>
                <td>
                    范围：1--100之内
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td id="TipsPercent" colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <input type="button" id="btnSubmit" value="确定" class="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnCancel" value="取消" class="btn" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=5" type="text/javascript"></script>
</body>
</html>
