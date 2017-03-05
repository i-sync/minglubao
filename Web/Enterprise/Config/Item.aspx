<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Web.Enterprise.Config.Item"  ValidateRequest="false" %>
<%@ Register Src="~/Controls/Region.ascx" TagPrefix="mlb" TagName="Region" %>
<%@ Register Src="~/Controls/Xheditor.ascx" TagPrefix="mlb" TagName="Editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业项目信息</title>    
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/Common.js" type="text/javascript"></script>
    <script src="../../JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function funupload(url) {
            $("#hdUrl").val(url);
            //$("#imgPhoto").css("width", 110);
            $("#imgPhoto").css("height", 150);
            $("#imgPhoto").attr("src", "/" + url + "?a=" + Math.random());
        }
        $(function () {
            $("#txtItemName").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入标题</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsItemName").html(msg);
            });

            $("#txtItemContent").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入内容</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsItemContent").html(msg);
            });

            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    return false;
                }
            });

            $("#imgPhoto").click(function () {
                if ($(this).attr("src").length > 0) {
                    window.open($(this).attr("src"));
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            企业项目信息</h3>
    </div>
    <div class="editlist">
        <table>
            <tr>
                <td class="name">
                    项目名称：
                </td>
                <td>
                    <asp:TextBox ID="txtItemName" CssClass="txt w500" runat="server"></asp:TextBox>
                </td>
                <td id="TipsItemName">
                </td>
            </tr>
            <tr>
                <td class="name">
                    项目简介：
                </td>
                <td>
                    <asp:TextBox ID="txtItemIntro" CssClass="txt w500" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="name">
                    项目口号：
                </td>
                <td>
                    <asp:TextBox ID="txtSignature" CssClass="txt w500" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="name" valign="top"> 
                    项目内容：
                </td>
                <td>
                    <mlb:Editor ID="txtItemContent" runat="server" />
                </td>
                <td id="TipsItemContent"  valign="top">
                </td>
            </tr>
            
            <tr>
                <td class="name" valign="top">
                    项目照片：
                </td>
                <td>
                    <asp:Image ID="imgPhoto" runat="server" style="display:block;border:1px solid #ccc" Height="150"/><br />
                    <asp:HiddenField ID="hdUrl" runat="server" />
                    <iframe frameborder="0" src="/enterprise/controls/Upload.aspx?folder=<%=MLMGC.COMP.Config.EnterpriseItemPhotoFolder %>" width="320" height="30"></iframe>
                </td>
                <td id="Td1">
                </td>
            </tr>
            <tr>
                <td class="name">
                    成立时间：
                </td>
                <td>
                    <asp:TextBox ID="txtEstablished"  CssClass="txt Wdate" onfocus="WdatePicker({dataFmt:'yyyy-MM-dd'});" runat="server"></asp:TextBox>
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td class="name">
                    所在城市：
                </td>
                <td>
                    <mlb:Region ID="region" runat="server" />
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td class="name">
                    状态：
                </td>
                <td>
                    <asp:RadioButtonList ID="rbStatus" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" CssClass="btn" Text="确定" OnClick="btnSubmit_Click" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
