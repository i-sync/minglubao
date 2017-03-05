<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientInfoAdd.aspx.cs" Inherits="Web.Personal.Item.ClientInfoAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>名录录入</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".list").click(function () {
                $(this).parent().siblings("td").find(".code").val($(this).val());
            });
            $(".code").blur(function () {
                var objList = $(this).parent().siblings("td").find(".list");
                var v = $.trim($(this).val());
                if (v.length > 0 && $(objList).find("option[value='" + v + "']").length == 0) {//判断输入码是否存在 =0不存在
                    $(this).addClass("error");
                    return false;
                }
                else {
                    $(objList).val(v);
                    $(this).removeClass("error");
                }
            });


            //检测手机
            $("#txtMobile").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && $.IsMobile(v)) {//判断格式是否为手机格式
                    $("#TipsMobile").html("<span class='succ'>正在检测中……</span>");
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: URLPlusRandom("/personal/handler/item.ashx"),
                        data: { key: "clientinfoexists", ciid: "0", type: "1", value: v },
                        success: function (data) {
                            if (data.flag == "1") {
                                $("#TipsMobile").html("<span class='succ'>" + data.detail + "</span>");
                                $("#txtMobile").removeClass("error");
                            }
                            else {
                                $("#TipsMobile").html("<span class='error'>" + data.detail + "</span>");
                                $("#txtMobile").addClass("error");
                            }
                        },
                        error: function (data) {
                            $("#TipsMobile").html("<span class='error'>连接服务器出错</span>");
                        },
                        dataType: "json"
                    });
                }
                else if (v.length > 0) {
                    $("#TipsMobile").html("<span class='error'>手机格式不正确</span>");
                }
                else {
                    $("#TipsMobile").html("");
                }
            });

            //检测电话
            $("#txtTel").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && $.IsTel(v)) {//判断格式是否为电话格式
                    $("#TipsTel").html("<span class='succ'>正在检测中……</span>");
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: URLPlusRandom("/personal/handler/item.ashx"),
                        data: { key: "clientinfoexists", ciid: "0", type: "2", value: v },
                        success: function (data) {
                            if (data.flag == "1") {
                                $("#TipsTel").html("<span class='succ'>" + data.detail + "</span>");
                                $("#txtTel").removeClass("error");
                            }
                            else {
                                $("#TipsTel").html("<span class='error'>" + data.detail + "</span>");
                                $("#txtTel").addClass("error");
                            }
                        },
                        error: function (data) {
                            $("#TipsTel").html("<span class='error'>连接服务器出错</span>");
                        },
                        dataType: "json"
                    });
                }
                else if (v.length > 0) {
                    $("#TipsTel").html("<span class='error'>电话格式不正确</span>");
                }
                else {
                    $("#TipsTel").html("");
                }
            });
            //检测邮箱
            $("#txtEmail").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsEmail(v)) {//判断格式是否为邮箱格式
                    $(this).addClass("error");
                } else {
                    $(this).removeClass("error");
                }
            });

            //检测传真
            $("#txtFax").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsTel(v)) {
                    $(this).addClass("error");
                }
                else {
                    $(this).removeClass("error");
                }
            });
            //检测QQ
            $("#txtQQ").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && ($.IsInt(v) || $.IsEmail(v))) {//判断格式是否为QQ
                    $(this).removeClass("error");
                } else if (v.length > 0) {
                    $(this).addClass("error");
                }
            });
            //检测MSN
            $("#txtMSN").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsEmail(v)) {//判断格式是否为邮箱格式
                    $(this).addClass("error");
                } else {
                    $(this).removeClass("error");
                }
            });

            //打开网址
            $("#aWebsite").click(function () {
                var website = $.trim($("#txtWebsite").val());
                if ($.IsNullOrEmpty(website) || $.trim(website) == "http://www.") {
                    return;
                }
                if (website.indexOf("http://") == -1) {
                    website = "http://" + website;
                }
                window.open(website);
            });

            //验证名录名称是否存在
            $("#txtName").blur(function () {
                var clientName = $.trim($(this).val());
                if ($.IsNullOrEmpty(clientName)) {
                    $("#TipCode").html("<span class='error'>请输入名录名称！</span>");
                    $(this).focus();
                }
                else {
                    $("#TipCode").html("检测中……");
                    $.ajax({
                        async: false,
                        type: "POST",
                        url: URLPlusRandom("/personal/handler/item.ashx"),
                        data: { key: "clientinfoexists", ciid: "0", type: "0", value: clientName },
                        success: function (data) {
                            if (data.flag == "1") {
                                $("#TipCode").html("<span class='succ'>" + data.detail + "</span>");
                                $("#txtName").removeClass("error");
                            }
                            else {
                                $("#TipCode").html("<span class='error'>" + data.detail + "</span>");
                                $("#txtName").addClass("error");
                            }
                        },
                        dataType: "json"
                    });
                }
            });

            ///--提交---
            $("#btnSubmit").click(function () {
                $(":text").trigger("blur")
                if ($(".error").length > 0) {
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <h3>名录录入</h3>
        </div>
        <div class="divlist">
            <table class="tabtxtlist">
                <tr>
                    <td class="name">
                        名录名称：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" CssClass="txt w500" ID="txtName" TabIndex="1"/>
                    </td>
                    <td id ="TipCode">                    
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        联系人：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtLinkman" TabIndex="5"/>
                    </td>
                    <td class="name">
                        职务：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtPosition" TabIndex="6" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        电话：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" AutoComplete="off" ID="txtTel" TabIndex="7" />
                    </td>
                    <td colspan="3">
                        <span>格式为：(010-88886666)</span>
                        <span id ="TipsTel"></span>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        手机：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" AutoComplete="off" ID="txtMobile" TabIndex="8"/>
                    </td>
                    <td colspan="3">
                        <span>格式为：134********</span>
                        <span id="TipsMobile"></span>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        邮编：
                    </td>
                    <td >
                        <asp:TextBox runat="server" CssClass="txt" ID="txtZipCode" TabIndex="3"/>
                    </td>
                    <td class="name">
                        网址：
                    </td>
                    <td >
                        <asp:TextBox runat="server" CssClass="txt" Text="http://www." ID="txtWebsite" TabIndex="4"/>
                    </td>
                    <td>
                        <a id="aWebsite" href="javascript:void(0)">打开</a>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        传真：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtFax" TabIndex="9"/>
                    </td>
                    <td class="name">
                        邮箱：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="txt" TabIndex="10" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        QQ：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtQQ" TabIndex="11"/>
                    </td>
                    <td class="name">
                        MSN：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMSN" CssClass="txt" TabIndex="12" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        地址：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" CssClass="txt w500" ID="txtAddress" TabIndex="2"/>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            <tr runat="server" id="trSource">
                <td class="name">
                    来源编号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSourceCode" TabIndex="13" CssClass="code txt" />
                </td>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList runat="server" ID="ddlSource" Width="200" CssClass="list ddl1">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr runat="server" id="trTrade">
                <td class="name">
                    行业编码：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTradeCode" TabIndex="14" CssClass="code txt" />
                </td>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList runat="server" ID="ddlTrade" Width="200" CssClass="list ddl1">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr runat="server" id="trArea">
                <td class="name">
                    地区编号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAreaCode" TabIndex="15" CssClass="code txt" />
                </td>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList runat="server" ID="ddlArea" Width="200" CssClass="list ddl1">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
                 <tr>
                    <td valign="top" class="name">
                        备注：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Rows="3" TabIndex="16" CssClass="area" Columns="40" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSubmit" Text="提交" CssClass="btn" TabIndex="17" onclick="btnSubmit_Click" />
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
