<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementEdit.aspx.cs" Inherits="Web.Enterprise.Announcement.AnnouncementEdit" ValidateRequest="false" %>
<%@ Register Src="~/Controls/Xheditor.ascx" TagPrefix ="mlb" TagName ="Editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布公告</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type ="text/javascript" language ="javascript" src ="../../JS/jquery-1.6.4.js"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#txtAnnTitle").blur(function () {
                var obj = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(obj)) {
                    msg = "<span class='error'>请输入标题</span>";
                }
                $("#TipsTitle").html(msg);
            });
            $("#btnSubmit").click(function () {
                if ($(".error").length > 0) {
                    return false;
                }
                var txtAnnTitle = $("#txtAnnTitle").val();
                var txtAnnContent = $("#txtContent").val();   //这个ID是用户控件中的id
                if (txtAnnTitle.length > 64) {
                    $("#TipsTitle").html("<span class='error'>标题输入太长，请检查......</span>");
                    return false;
                }
                if ($.IsNullOrEmpty(txtAnnTitle)) {
                    $("#TipsTitle").html("<span class='error'>请输入标题</span>");
                    return false;
                }
                return true;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>发布公告</h3>
    </div>
    <div class="divlist">
        <table cellpadding="1" cellspacing ="1" class="tabtxtlist">
            <tr>
                <td>公告标题：</td>
                <td style="width:440px;">
                    <asp:TextBox ID ="txtAnnTitle" CssClass="txt w420" MaxLength="64" runat="server" />
                </td>
                <td id ="TipsTitle"></td>
            </tr>
            <tr>
                <td valign="top">公告内容：</td>
                <td colspan="2">                    
                    <mlb:Editor ID ="txtAnnContent" Height="100" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID ="btnSubmit" Text ="确定" CssClass="btn" OnClick ="btnSubmit_Click" runat="server"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value ="取消" id ="btnCancel" class="btn" onclick ="window.location.replace('AnnouncementList.aspx');"/>       
                </td>
            </tr>
        </table>
        <div>
                 
        </div>
    </div>
    </form>
</body>
</html>
