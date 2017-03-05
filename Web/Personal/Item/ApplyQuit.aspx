<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyQuit.aspx.cs" Inherits="Web.Personal.Item.ApplyQuit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请退出</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //验证是否输入退出项目理由
            $("#txtReason").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入退出理由</span>";
                }
                else if (v.length > 64) {
                    msg = "<span class='error'>输入的文字太多！</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsReason").html(msg);
            });

            //提交
            $("#btnSubmit").click(function () {
                $("#txtReason").triggerHandler("blur");
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
            <h3>申请退出</h3>
        </div>
        <div class="divlist">
            <table>
                <tr>
                    <td valign="top">退出理由：</td>
                    <td>
                        <asp:TextBox ID="txtReason" runat="server" MaxLength="128" TextMode="MultiLine" Columns ="45" Rows="6">
                        </asp:TextBox>
                    </td>
                    <td valign="top" id="TipsReason">
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">           
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text = "提交" CssClass="btn1" runat="server" />                             
                        <input type="button" onclick="window.location.replace('itemlist.aspx')" class="btn1" value="返回" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
