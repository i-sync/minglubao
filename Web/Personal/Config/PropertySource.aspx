<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertySource.aspx.cs" Inherits="Web.Personal.Config.PropertySource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>来源设置</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/core.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/popup_layer.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript">
        var URL_CONFIG = {
            Post_URL: "../Handler/PIHandler.ashx"
        };
        var pl;
        $(function () {
            //为表格添加滑动样式
            $.Hover(".tablist tr");

            pl = new PopupLayer({ title: "行业设置", popupBlk: "#divSourceInfo", useOverlay: "true" });
            $("#btnAdd").click(function () {
                $("#txtName").val("");
                $("#TipsName").html("");
                $("#txtPutin").val("");
                $("#TipsPutin").html("");
                $("#txtIntro").val("");
                $("#divSourceInfo").attr("type", "add");
                $("#divSourceInfo").attr("sourceid", "0");
                $("#divSourceInfo").show();
                pl.Show();
            });
            $(".update").click(function () {
                var trObj = $(this).parents("tr");
                var sourceid = $(trObj).attr("sourceid");
                var data = "key=725&sourceid=" + sourceid + "&t=" + Math.random();
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (parseInt(msg.id) > 0) {
                        $("#txtName").val(msg.name);
                        $("#txtPutin").val(msg.putin);
                        $("#txtIntro").val(msg.intro);
                        $("#TipsName").html("");
                        $("#divSourceInfo").attr("type", "update");
                        $("#divSourceInfo").attr("sourceid", msg.id);
                        $("#divSourceInfo").show();
                        pl.Show();
                    } else {
                        alert("指定地区不存在");
                    }
                }, "json");
            });
            $(".del").click(function () {
                if (!confirm("确认要删除吗？")) {
                    return false;
                }
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

            $("#txtName").blur(function () {
                var name = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(name)) {
                    msg = "<span class='error'>请输入名称！</span>";
                    $("#TipsName").html(msg);
                    return;
                }
                var sourceid = $("#divSourceInfo").attr("sourceid");
                $("#TipsName").html("检测中...");
                $.ajax({
                    type: "GET",
                    url: URLPlusRandom(URL_CONFIG.Post_URL),
                    data: { key: 721, sourceid: sourceid, name: name },
                    success: function (data) {
                        if (data == "0") {
                            msg = "<span class='succ'>这个名称可以使用</span>";
                        }
                        else {
                            msg = "<span class='error'>这个名称已经使用，请换一个</span>";
                        }
                        $("#TipsName").html(msg);
                    },
                    dataType: "text"
                });
            });

            $("#txtPutin").blur(function () {
                var v = $(this).val();
                var msg = "";
                if (!$.IsNullOrEmpty(v)) {
                    if (!$.IsNumber(v)) {
                        msg = "<span class='error'>请输入正确的数字</span>";
                    }
                    else {
                        msg = "<span class='succ'>输入正确</span>";
                    }
                }
                $("#TipsPutin").html(msg);
            });
            $("#btnSubmit").click(function () {
                $("#txtName").triggerHandler("blur");
                $("#txtPutin").triggerHandler("blur");
                if ($(".error").length > 0) { return false; }

                var type = $("#divSourceInfo").attr("type");
                var sourceid = $("#divSourceInfo").attr("sourceid");

                var name = $("#txtName").val();
                var putin = $("#txtPutin").val();
                var intro = $("#txtIntro").val();
                var data = "";
                if (type == "add") {
                    data = "key=722&name=" + escape(name) + "&putin=" + escape(putin) + "&intro=" + escape(intro) + "&t=" + Math.random();
                } else {
                    data = "key=723&sourceid=" + sourceid + "&name=" + escape(name) + "&putin=" + escape(putin) + "&intro=" + escape(intro) + "&t=" + Math.random();
                }
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    msg = parseInt(msg);
                    if (msg > 0) {
                        if (type == "add") {
                            PopTip.Show(PopTip.Type.Succ, "提交成功", false);
                            $("#txtName").val("");
                            $("#TipsName").html("");
                            $("#txtPutin").val("");
                            $("#TipsPutin").html("");
                            $("#txtIntro").val("");
                        }
                        else {
                            PopTip.Show(PopTip.Type.Succ, "提交成功", true);
                        }
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "提交成功", false);
                    }
                }, "text");
            });
            $("#btnCancel").click(function () {
                $("#divSourceInfo").hide();
                $("#divSourceInfo").removeAttr("type");
                $("#divSourceInfo").removeAttr("sourceid");
                pl.PopClose();
                window.location = window.location;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divlist" style="width: 96%; margin: 10px;">
      
        <p>
            <input type="button" id="btnAdd" class="btn1" value="录入新的来源" /></p>
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th class="num">
                    序号
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
                <th class="operate">
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
    <div style="width: 500px; border: 1px solid #ccc; display:none; background-color:White;"
        id="divSourceInfo">
        <table style="margin: 10px;">
            <tr style=" height:40px;">
                <td style="width:80px; height:40px; text-align: right;">
                    名称：
                </td>
                <td>
                    <input type="text" id="txtName" class="txt" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsName">
                    &nbsp;
                </td>
            </tr>
            <tr style=" height:40px;">
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
                <td style="height:40px; vertical-align:bottom">
                    &nbsp;
                </td>
                <td colspan="3">
                    <input type="button" id="btnSubmit" value="确定" class="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnCancel" value="返回" class="btn"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
