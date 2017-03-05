<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertySource.aspx.cs"
    Inherits="Web.Enterprise.Config.PropertySource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>来源设置</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/core.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/popup_layer.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var URL_CONFIG = {
            Post_URL: "../EPHandler.ashx"
        };
        var pl;
        $(function () {
            pl = new PopupLayer({ title: "来源设置", popupBlk: "#divSourceInfo", useOverlay: "true" });
            $("#btnAdd").click(function () {
                $("#txtCode").val("");
                $("#txtName").val("");
                $("#TipsCode").html("");
                $("#divSourceInfo").attr("type", "add");
                $("#divSourceInfo").attr("sourceid", "0");
                pl.Show();
            });
            $(".update").click(function () {
                var trObj = $(this).parents("tr");
                var sourceid = $(trObj).attr("sourceid");
                var data = "key=725&sourceid=" + sourceid + "&t=" + Math.random();
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (parseInt(msg.id) > 0) {
                        $("#txtCode").val(msg.code);
                        $("#txtName").val(msg.name);
                        $("#txtPutin").val(msg.putin);
                        $("#txtIntro").val(msg.intro);
                        $("#TipsCode").html("");
                        $("#divSourceInfo").attr("type", "update");
                        $("#divSourceInfo").attr("sourceid", msg.id);
                        pl.Show();
                    } else {
                        PopTip.Show(PopTip.Type.Tips, "地区不存在", false);
                    }
                }, "json");
            });
            $(".del").click(function () {
                var result = confirm("确认要删除吗？");
                if (!result)
                    return false;
                var trObj = $(this).parents("tr");
                var sourceid = $(trObj).attr("sourceid");
                var data = "key=724&sourceid=" + sourceid;
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "0") {
                        PopTip.Show(PopTip.Type.Error, "删除失败", false);
                    } else {
                        PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                    }
                }, "text");
            });
            $("#txtCode").blur(function () {
                var code = $.trim($(this).val());
                if (code.length == 0) {
                    $("#TipsCode").html("");
                    return false;
                }
                var sourceid = $("#divSourceInfo").attr("sourceid");
                var data = "key=721&sourceid=" + sourceid + "&code=" + escape(code);
                $("#TipsCode").html("检测中..");
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "0") {
                        msg = "<span class='succ'>这个编码可以使用</span>";
                    } else {
                        msg = "<span class='error'>这个编码已经使用，请换一个</span>";
                    }
                    $("#TipsCode").html(msg);
                }, "text");
            }).keydown(function (event) { if (eval.keyCode == 13) { $("#btnSubmit").trigger("click"); return false; } });
            $("#txtName").keydown(function (event) {
                if (event.keyCode == 13) { $("#btnSubmit").trigger("click"); return false; }
            });
            $("#txtPutin").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if (!$.IsNullOrEmpty(v)) {
                    if (!$.IsNumber(v)) {
                        msg = "<span class='error'>请输入正确的数字</span>";
                    }
                    else {
                        msg = "<span class='succ'>输入正确</span>";
                    }
                }
                else { 
                    msg="<span class='error'>请输入数字</span>"
                }
                $("#TipsPutin").html(msg);
            });
            $("#btnSubmit").click(function () {
                var type = $("#divSourceInfo").attr("type");
                var sourceid = $("#divSourceInfo").attr("sourceid");
                var code = $("#txtCode").val();
                var name = $("#txtName").val();
                var putin = $("#txtPutin").val();
                var intro = $("#txtIntro").val();
                if ($.IsNullOrEmpty(code)) {
                    $("#TipsCode").html("<span class='error'>请输入编码</span>");
                }
                else {
                    $("#TipsCode").html("<span class='succ'></span>");
                }
                if (code.length > 8) {
                    $("#TipsCode").html("<span class='error'>编码过长，请检查</span>");
                }
                if ($.IsNullOrEmpty(name)) {
                    $("#TipsName").html("<span class='error'>请输入名称</span>");
                }
                else {
                    $("#TipsName").html("<span class='succ'></span>");
                }
                if (name.length > 64) {
                    $("#TipsName").html("<span class='error'>名称过长，请检查</span>");
                }
                $("#txtPutin").triggerHandler("blur");
                if ($(".error").length > 0) { return false; }
                var data = "";
                if (type == "add") {
                    data = "key=722&code=" + escape(code) + "&name=" + escape(name) + "&putin=" + escape(putin) + "&intro=" + escape(intro);
                } else {
                    data = "key=723&sourceid=" + sourceid + "&code=" + escape(code) + "&name=" + escape(name) + "&putin=" + escape(putin) + "&intro=" + escape(intro);
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
                $("#txtCode").val("");
                $("#txtName").val("");
                $("#TipsCode").html("");
                $("#divSourceInfo").removeAttr("type");
                $("#divSourceInfo").removeAttr("sourceid");
                pl.PopClose();
            });

            //为表格添加滑动样式
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divlist" style="width: 96%; margin: 10px;">
        <p>
            <input type="button" id="btnAdd" value="录入新的来源" class="btn1" /></p>
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th class="num">
                    序号
                </th>
                <th>
                    编码
                </th>
                <th>
                    名称
                </th>
                <th>
                    投入
                </th>
                <th>
                    补充说明
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c" sourceid="<%#Eval("sourceid") %>">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <%#Eval("SourceCode") %>
                        </td>
                        <td>
                            <%#Eval("SourceName") %>
                        </td>
                        <td>
                            <%#Eval("Putin") %>
                        </td>
                        <td>
                            <%#Eval("Intro") %>
                        </td>
                        <td>
                            <a href="javascript:void(0);" class="update">修改</a> <a href="javascript:void(0);"
                                class="del">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="width: 500px; border: 1px solid #ccc; display: none; background-color: White;"
        id="divSourceInfo">
        <table style="margin: 10px;">
            <tr>
                <td style="width: 80px; height: 40px; text-align: right;">
                    编码：
                </td>
                <td>
                    <input type="text" id="txtCode" maxlength="8" class="txt" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsCode">
                </td>
            </tr>
            <tr style="height: 40px;">
                <td align="right">
                    名称：
                </td>
                <td>
                    <input type="text" id="txtName" maxlength="64" class="txt" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsName">
                    &nbsp;
                </td>
            </tr>
            <tr style="height: 40px;">
                <td align="right">
                    投入：
                </td>
                <td>
                    <input type="text" id="txtPutin" class="txt" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsPutin">
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    补充说明：
                </td>
                <td colspan="3">
                    <textarea id="txtIntro" rows="3" cols="36"></textarea>
                </td>
            </tr>
            <tr>
                <td style="height: 40px; vertical-align: bottom">
                    &nbsp;
                </td>
                <td colspan="3">
                    <input type="button" id="btnSubmit" value="确定" class="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnCancel" value="取消" class="btn" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
