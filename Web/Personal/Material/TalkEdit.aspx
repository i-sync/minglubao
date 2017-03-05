<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalkEdit.aspx.cs" Inherits="Web.Personal.Material.TalkEdit" ValidateRequest="false"%>
<%@ Register Src="~/Controls/Xheditor.ascx" TagPrefix="mlb" TagName ="Editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人话术编辑</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type ="text/javascript" language ="javascript" src ="../../JS/jquery-1.6.4.js"></script>
    <script type ="text/javascript" language ="javascript" src ="../../JS/common.js"></script>
    <script type ="text/javascript" language="javascript">
        $(document).ready(function () {
            $("#btnCancel").click(function () {
                window.location.replace("TalkList.aspx");
            });

            $("#txtTalkSubject").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入标题</span>";
                }
                else if (v.length > 100) {
                    msg = "<span class='error'>标题太长</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsSubject").html(msg);

            });

            $("#txtSort").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入排序号</span>";
                }
                else if (!$.IsInt(v) || parseInt(v) < 0) {
                    msg = "<span class='error'>请输入正确的数字</span>";
                }
                else {
                    msg = "数字越小，排序越靠前，最小为0.";
                }
                $("#TipsSort").html(msg);

            });

            $("#btnSubmit").click(function () {

                $(":text").triggerHandler("blur");
//                var txtDetail = $("#txtContent").val();
//                if ($.IsNullOrEmpty(txtDetail)) {
//                    alert("请输入内容");
//                    return false;
//                }
                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
            });            
        });
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>话术编辑页</h3>
    </div>
    <div class ="divlist">
        <table>
            <tr>
                <td class="name">标题：</td>
                <td>
                    <asp:TextBox ID ="txtTalkSubject" runat="server" class="txt w500"></asp:TextBox>
                </td>
                <td id ="TipsSubject">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="name" valign="top">内容：</td>
                <td>
                    <mlb:Editor ID ="txtTalkDetail" runat="server" Height="300" Width="600"></mlb:Editor>
                </td>
            </tr>
            <tr>
                <td class="name">
                    排序值：
                </td>
                <td class=" w120" style=" vertical-align:middle; height:38px; line-height:34px;">
                    <asp:TextBox ID ="txtSort" runat="server" class="txt w120"></asp:TextBox>
                    <span id="TipsSort">数字越小，排序越靠前，最小为0.</span>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID ="btnSubmit" Text ="确定" OnClick ="btnSubmit_Click" CssClass="btn" runat="server"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value ="取消" class="btn" id ="btnCancel" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
