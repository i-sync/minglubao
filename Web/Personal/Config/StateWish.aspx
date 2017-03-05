<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateWish.aspx.cs" Inherits="Web.Personal.Config.StateWish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>意向进展</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/core.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="../../JS/popup_layer.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript">
        var pl;
        $(function () {
            //为表格添加滑动样式
            $.Hover(".tablist tr");

            pl = new PopupLayer({ title: "意向进展", popupBlk: "#divWishInfo", useOverlay: "true" });
            $("#btnAdd").click(function () {
                $("#txtName").val("");
                $("#txtPercent").val("");
                $("#divWishInfo").attr("type", "add");
                $("#divWishInfo").attr("wishid", "0");
                $("#divWishInfo").show();
                pl.Show();
            });
            $(".update").click(function () {
                var trObj = $(this).parents("tr");
                var wishid = $(trObj).attr("wishid");
                var url = "../Handler/PIHandler.ashx";
                var data = "key=805&wishid=" + wishid+"&t="+Math.random();
                $.get(url, data, function (msg) {
                    if (parseInt(msg.id) > 0) {
                        $("#txtName").val(msg.name);
                        $("#txtPercent").val(msg.percent);

                        $("#divWishInfo").attr("type", "update");
                        $("#divWishInfo").attr("wishid", msg.id);
                        $("#divWishInfo").show();
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
                var wishid = $(trObj).attr("wishid");
                var url = "../Handler/PIHandler.ashx";
                var data = "key=804&wishid=" + wishid;
                $.get(url, data, function (msg) {
                    if (msg == "0") {
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
                var wishid = $("#divWishInfo").attr("wishid");
                var url = "../Handler/PIHandler.ashx";
                var data = "key=801&wishid=" + wishid + "&name=" + escape(name) + "&t=" + Math.random();
                $("#TipsName").html("检测中..");
                $.get(url, data, function (msg) {
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
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    return false;
                }
                var type = $("#divWishInfo").attr("type");
                var wishid = $("#divWishInfo").attr("wishid");
                var name = $("#txtName").val();
                var percent = parseInt($("#txtPercent").val());

                var url = "../Handler/PIHandler.ashx";
                var data = "";
                if (type == "add") {
                    data = "key=802&name=" + escape(name) + "&percent=" + percent + "&t=" + Math.random();
                } else {
                    data = "key=803&wishid=" + wishid + "&name=" + escape(name) + "&percent=" + percent + "&t=" + Math.random();
                }
                $.get(url, data, function (msg) {
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
                $("#divWishInfo").removeAttr("type");
                $("#divWishInfo").removeAttr("wishid");
                $("#divWishInfo").fadeOut();
                pl.PopClose();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            意向进展</h3>
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
                            <a href="javascript:void(0);" class="update">修改</a> <a href="javascript:void(0);"
                                class="del">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="width: 600px; border: 1px solid #ccc;display: none; padding-left:10px;
        background-color: White; height:200px; " id="divWishInfo">
        <br />
        <table>
            <tr>
                <td align="right">
                    名称：
                </td>
                <td>
                    <input type="text" id="txtName" class="txt w300" />
                </td>
            </tr>
            <tr style=" height:20px;">
                <td>
                    &nbsp;
                </td>
                <td id="TipsName">
                </td>
            </tr>
            <tr style=" height:20px;">
                <td align="right">
                    意向程度：
                </td>
                <td>
                    <input type="text" id="txtPercent" class="txt w300" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td id="TipsPercent">
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
</body>
</html>
