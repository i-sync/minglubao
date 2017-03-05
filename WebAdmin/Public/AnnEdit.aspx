<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnEdit.aspx.cs" Inherits="WebAdmin.Public.AnnEdit" ValidateRequest="false" %>
<%@ Register Src="~/Controls/Ueditor.ascx" TagName="Editor" TagPrefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtAnnTitle").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入标题</span>"
                }
                else {
                    msg = "";
                }
                $("#TipsTitle").html(msg);
            });

//            ///提交
//            $("#btnSubmit").click(function () {
//                if ($(".error").length > 0) {
//                    return false;
//                }
//                $("#txtAnnTitle").triggerHandler("blur");
//                var txtAnnTitle = $("#txtAnnTitle").val();
//                if (txtAnnTitle.length > 64) {
//                    $("#TipsTitle").html("<span class='error'>标题输入太长，请检查......</span>");
//                    return false;
//                }
//                return true;
//            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder" width="98%"  border="0" align="center">
            <tr>
                <th class="bigTitle">
                    添加修改公告
                </th>
            </tr>
            <tr>
                <td>
                    <table cellpadding="1" cellspacing ="1" class="tablist" style="text-align:left;">
                        <tr>
                            <td style=" width:70px; text-align:right; height:30px;">标题：</td>
                            <td>
                                <asp:TextBox ID ="txtAnnTitle" CssClass="txt width600"  MaxLength="64" runat="server" />
                                <span id="TipsTitle" class="red"></span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="text-align:right;">内容：</td>
                            <td>
                                <mlb:Editor ID ="txtAnnContent" Height="100" runat="server"></mlb:Editor> 
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID ="btnSubmit" Text ="确定" CssClass="btn" OnClick ="btnSubmit_Click" runat="server"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="button" value ="取消" id ="btnCancel" class="btn" onclick ="window.location.replace('AnnList.aspx');"/>       
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>    
    </form>
</body>
</html>
