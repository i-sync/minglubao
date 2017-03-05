<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyArea.aspx.cs" Inherits="Web.Personal.Config.PropertyArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地区设置</title>
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

            pl = new PopupLayer({ title: "行业设置", popupBlk: "#divAreaInfo", useOverlay: "true" });
            $("#btnAdd").click(function () {
                //$("#txtCode").val("");
                $("#txtName").val("");
                $("#TipsName").html("");
                $("#divAreaInfo").attr("type", "add");
                $("#divAreaInfo").attr("areaid", "0");
                $("#divAreaInfo").show();
                pl.Show();
            });
            $(".update").click(function () {
                var trObj = $(this).parents("tr");
                var areaid = $(trObj).attr("areaid");
                var data = "key=715&areaid=" + areaid + "&t=" + Math.random();
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (parseInt(msg.id) > 0) {
                        //$("#txtCode").val(msg.code);
                        $("#txtName").val(msg.name);
                        $("#TipsName").html("");
                        $("#divAreaInfo").attr("type", "update");
                        $("#divAreaInfo").attr("areaid", msg.id);
                        $("#divAreaInfo").show();
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
                var areaid = $(trObj).attr("areaid");
                var data = "key=714&areaid=" + areaid;
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
                var areaid = $("#divAreaInfo").attr("areaid");
                $("#TipsName").html("检测中...");
                $.ajax({
                    type: "GET",
                    url: URLPlusRandom(URL_CONFIG.Post_URL),
                    data: { key: 711, areaid: areaid, name: name },
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

            }).keydown(function (event) {
                if (event.keyCode == 13) { $("#btnSubmit").trigger("click"); return false; }
            });

            $("#btnSubmit").click(function () {
                var type = $("#divAreaInfo").attr("type");
                var areaid = $("#divAreaInfo").attr("areaid");
                //$("#txtCode").triggerHandler("blur");
                $("#txtName").triggerHandler("blur");
                if ($(".error").length > 0) { return false; }

                //var code = $("#txtCode").val();
                var name = $("#txtName").val();

                var data = "";
                if (type == "add") {
                    data = "key=712&name=" + escape(name) + "&t=" + Math.random();
                } else {
                    data = "key=713&areaid=" + areaid + "&name=" + escape(name) + "&t=" + Math.random();
                }
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    msg = parseInt(msg);
                    if (msg > 0) {
                        if (type == "add") {
                            PopTip.Show(PopTip.Type.Succ, "提交成功", false);
                            $("#txtName").val("");
                            $("#TipsName").html("");
                        }
                        else {
                            PopTip.Show(PopTip.Type.Succ, "提交成功", true);
                        }
                    }
                    else {
                        PopTip.Show(PopTip.Type.Succ, "提交失败", false);
                    }
                }, "text");
            });
            $("#btnCancel").click(function () {
                $("#divAreaInfo").hide();
                $("#txtName").val("");
                $("#TipsName").html("");
                $("#divAreaInfo").removeAttr("type");
                $("#divAreaInfo").removeAttr("areaid");
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
            <input type="button" id="btnAdd" class="btn1" value="录入新的地区" /></p>
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th class="num">
                    序号
                </th>
                <th>
                    名称
                </th>
                <th class="operate">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c" areaid="<%#Eval("areaid") %>">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <%#Eval("AreaName") %>
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
    <div style="width:500px; border: 1px solid #ccc; display: none; background-color:White;" id="divAreaInfo">
        <table style="margin: 10px;">            
            <tr>
                <td align="right">
                    名称：
                </td>
                <td>
                    <input type="text" id="txtName" class="txt" />
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
                    <input type="button" id="btnCancel" value="返回" class="btn"/>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
