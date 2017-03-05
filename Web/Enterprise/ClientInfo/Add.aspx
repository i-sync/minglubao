<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs"
    Inherits="Web.Enterprise.ClientInfo.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录录入</title>
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/hover.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/poptip.js" type="text/javascript"></script>
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var CONFIG = {
            URL: "/enterprise/Handler/CIHandler.ashx"
        };
        function ShowTips(ObjTip,Flag,Msg) {
            var result;
            if (Flag) {
                result = "<span class='succ'>" + Msg + "</span>";
            }
            else {
                result = "<span class='error'>" + Msg + "</span>";
            }
            $(ObjTip).html(result);
        }
        $(function () {
            $(".list").click(function () {
                $(this).parent().siblings("td").find(".code").val($(this).val());
            });
            $(".code").blur(function () {
                var objList = $(this).parent().siblings("td").find(".list");
                var v = $(this).val();
                if (v.length > 0 && $(objList).find("option[value='" + v + "']").length == 0) {//判断输入码是否存在 =0不存在
                    $(this).addClass("error");
                    return false;
                }
                else {
                    $(objList).val(v);
                    $(this).removeClass("error");
                }
            });

            //判断名录名称是否存在
            $("#txtName").blur(function () {
                var name = $("#txtName").val();
                if ($.IsNullOrEmpty(name)) {
                    ShowTips("#TipsCode", false, "请输入名录名称");
                    return;
                }
                $("#TipsCode").html("<span class='succ'>正在检测中……</span>");
                $.ajax({
                    type: "GET",
                    url: URLPlusRandom(CONFIG.URL),
                    data: { act: "exists", name: name, ciid: "0" },
                    success: function (data) {
                        ShowTips("#TipsCode", data.flag == "1", data.detail);
                        if (data.flag == "1") {
                            $("#txtName").removeClass("error");
                        }
                        else {
                            $("#txtName").addClass("error");
                        }
                    },
                    dataType: "json"
                });
            });
            $("#txtName").focus(function () {
                $("#TipsCode").html("");
                $(this).removeClass("error");
            });

            //检测手机
            $("#txtMobile").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && $.IsMobile(v)) {//判断格式是否为手机格式
                    $("#TipsMobile").html("<span class='succ'>正在检测中……</span>");
                    $.ajax({
                        type: "POST",
                        url: URLPlusRandom(CONFIG.URL + "?act=existscontact"),
                        data: { ciid: "0", type: "1", value: v },
                        success: function (data) {
                            ShowTips("#TipsMobile", data.flag == "1", data.detail);
                        },
                        error:function(data)
                        {
                            ShowTips("#TipsMobile",false, data);
                        },
                        dataType: "json"
                    });
                }
                else if (v.length > 0) {
                    ShowTips("#TipsMobile", false, "手机格式不正确");
                }
                else {
                    ShowTips("#TipsMobile", true, "");
                }
            });
            //检测电话
            $("#txtTel").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && $.IsTel(v)) {
                    $("#TipsTel").html("<span class='succ'>正在检测中……</span>");
                    $.ajax({
                        type: "POST",
                        url: URLPlusRandom(CONFIG.URL + "?act=existscontact"),
                        data: { ciid: "0", type: "2", value: v },
                        success: function (data) {
                            ShowTips("#TipsTel", data.flag == "1", data.detail);
                        },
                        error: function (data) {
                            ShowTips("#TipsTel", false, data);
                        },
                        dataType: "json"
                    });
                }
                else if (v.length > 0) {
                    ShowTips("#TipsTel", false, "电话格式不正确");
                }
                else {
                    ShowTips("#TipsTel", true, "");
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

            $("form").submit(function () {
                if ($.IsNullOrEmpty($("#txtName").val())) {
                    $("#txtName").focus();
                    PopTip.Show(PopTip.Type.Tips, "请输入名录名称");
                    return false;
                }
                $(":text").triggerHandler("blur");
                if ($(".error").length > 0) {
                    PopTip.Show(PopTip.Type.Tips, "请修改错误提示");
                    return false;
                }
                return true;
            });

            $(":text").hoverForIE6();
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
                    <asp:TextBox runat="server" class="txt w500" ID="txtName" TabIndex="1" MaxLength="60"/>
                </td>
                <td id ="TipsCode">
                
                </td>
            </tr>
            <tr>
                <td class="name">
                    联系人：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLinkman" CssClass="txt" TabIndex="5" MaxLength ="30"/>
                </td>
                <td class="name">
                    职务：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPosition" TabIndex="6" CssClass="txt" MaxLength="60" />
                </td>
            </tr>
            <tr>
                <td class="name">
                    手机：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobile" CssClass="txt" TabIndex="8" MaxLength ="11"/>
                </td>
                <td colspan="3">
                    <span>格式为：134********</span>
                    <span id ="TipsMobile"></span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    电话：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTel" TabIndex="7" CssClass="txt" MaxLength ="32"/>
                </td>
                <td colspan ="3">
                    <span>格式为：(010-88886666)</span>
                    <span id="TipsTel"></span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    邮编：
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtZipCode" CssClass="txt" TabIndex="3" MaxLength="6"/>
                </td>
                <td class="name" style=" width:100px;">
                    网址：
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtWebsite" CssClass="txt" TabIndex="4" Text="http://www." MaxLength ="60" />
                </td>
                <td>                    
                    &nbsp;<a href="javascript:void(0)" id="aWebsite">打开</a>                
                </td>
            </tr>
            
            <tr>
                <td class="name">
                    传真：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFax" TabIndex="9" CssClass="txt"/>
                </td>
                <td class="name">
                    邮箱：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" TabIndex="10" CssClass="txt" MaxLength ="60" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="name">
                    QQ：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt" ID ="txtQQ" TabIndex="11" MaxLength ="60"></asp:TextBox>
                </td>
                <td class="name">
                    MSN：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt" ID ="txtMSN" TabIndex="12" MaxLength ="60"></asp:TextBox>
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
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="txt w500" TabIndex="2" MaxLength="60"/>
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
                    <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" CssClass="area" Rows="3" Columns="40" TabIndex="16" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="3">
                    <asp:Button runat="server" ID="btnSubmit" Text="提交" CssClass="btn" onclick="btnSubmit_Click" TabIndex="17" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=8" type="text/javascript"></script>
    <script src="/JS/Reservation.js" type="text/javascript"></script>
</body>
</html>
