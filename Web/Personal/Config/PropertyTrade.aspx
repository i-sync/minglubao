<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyTrade.aspx.cs" Inherits="Web.Personal.Config.PropertyTrade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>行业设置</title>
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

            pl = new PopupLayer({ title: "行业设置", popupBlk: "#divTradeInfo", useOverlay: "true" });
            $("#btnAdd").click(function () {
                $("#txtName").val("");
                $("#TipsName").html("");
                $("#divTradeInfo").attr("type", "add");
                $("#divTradeInfo").attr("tradeid", "0");
                $("#divTradeInfo").show();
                pl.Show();
            });
            $(".update").click(function () {
                var trObj = $(this).parents("tr");
                var tradeid = $(trObj).attr("tradeid");
                var data = "key=705&tradeid=" + tradeid + "&t=" + Math.random();
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (parseInt(msg.id) > 0) {
                        $("#txtName").val(msg.name);
                        $("#TipsName").html("");
                        $("#divTradeInfo").attr("type", "update");
                        $("#divTradeInfo").attr("tradeid", msg.id);
                        $("#divTradeInfo").show();
                        pl.Show();
                    } else {
                        alert("指定行业不存在");
                    }
                }, "json");
            });
            $(".del").click(function () {
                if (!confirm("确认要删除吗？")) {
                    return false;
                }
                var trObj = $(this).parents("tr");
                var tradeid = $(trObj).attr("tradeid");
                var data = "key=704&tradeid=" + tradeid;
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "0") {
                        //alert("删除失败");
                        PopTip.Show(PopTip.Type.Error, "删除失败", false);
                    } else {
                        //alert("删除成功");
                        //window.location = window.location;
                        PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                    }
                }, "text");
            });
            $("#txtCode").blur(function () {
                var code = $.trim($(this).val());
                if (code.length == 0) {
                    $("#TipsCode").html("<span class='error'>请输入编码</span>");
                    return false;
                }
                var tradeid = $("#divTradeInfo").attr("tradeid");
                var data = "key=701&tradeid=" + tradeid + "&code=" + escape(code) + "&t=" + Math.random();
                $("#TipsCode").html("检测中..");
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "0") {
                        msg = "<span class='succ'>这个编码可以使用</span>";
                    } else {
                        msg = "<span class='error'>这个编码已经使用，请换一个</span>";
                    }
                    $("#TipsCode").html(msg);
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
                var tradeid = $("#divTradeInfo").attr("tradeid");
                $("#TipsName").html("检测中...");
                $.ajax({
                    type: "GET",
                    url: URLPlusRandom(URL_CONFIG.Post_URL),
                    data: { key: 701, tradeid: tradeid, name: name },
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
                var type = $("#divTradeInfo").attr("type");
                var tradeid = $("#divTradeInfo").attr("tradeid");
                $("#txtName").triggerHandler("blur");
                if ($(".error").length > 0) { return false; }

                var name = $("#txtName").val();
                var data = "";
                if (type == "add") {
                    data = "key=702&name=" + escape(name) + "&t=" + Math.random();
                } else {
                    data = "key=703&tradeid="+ tradeid + "&name=" + escape(name) + "&t=" + Math.random();
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
                        PopTip.Show(PopTip.Type.Error, "提交失败", false);
                    }
                }, "text");
            });
            $("#btnCancel").click(function () {
                $("#txtName").val("");
                $("#TipsName").html("");
                $("#divTradeInfo").removeAttr("type");
                $("#divTradeInfo").removeAttr("tradeid");
                $("#divTradeInfo").fadeOut();
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
            <input type="button" id="btnAdd" class="btn1" value="录入新的行业" /></p>
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
                    <tr  class="c" tradeid="<%#Eval("tradeid") %>">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <%#Eval("TradeName") %>
                        </td>
                        <td>
                            <a href="javascript:void(0);" class="update">修改</a> <a href="javascript:void(0);" class="del">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="width: 500px; border: 1px solid #ccc; display: none; background-color:White;" id="divTradeInfo">
        <table style=" margin:10px;">
            <tr>
                <td style=" width:60px; text-align:right;">
                    名称：
                </td>
                <td>
                    <input type="text" id="txtName" class="txt"/>
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
