<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Avatar.aspx.cs" Inherits="Web.Personal.Avatar.Avatar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改头像</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function funupload(url) {
            $("#hdUrl").val(url);
            $("#imgAvatar").css("width", 110);
            $("#imgAvatar").css("height", 110);
            $("#imgAvatar").attr("src", "/"+url+"?a="+Math.random());
        }
        $(function () {
            $("#imgAvatar").click(function () {
                if ($(this).attr("src").length > 0) {
                    window.open($(this).attr("src"));
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="nav">
            <h3>修改头像</h3>
        </div>
        <div class="divlist">
            <div>
                <h4>头像上传</h4>
            </div>   
            <table>
                <tr>
                    <td>             
                        <asp:Image ID="imgAvatar" ImageUrl="~/images/guanliyuan.jpg" runat="server" Width="110" Height="110"/>
                    </td>
                </tr>
                <tr>
                    <td>                        
                        <asp:HiddenField ID="hdUrl" runat="server" />
                        <iframe frameborder="0" src="Upload.aspx" width="320" height="30"></iframe>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID ="btnSubmit" OnClick ="btnSubmit_Click" Text = "提交" CssClass="btn1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>

        <div style="margin:10px;">
            <div>
                说明：
            </div>
            <div>
                当前上传页头像大小为：110x110<br />
                左上角头像显示大小为：  30x30<br />
                &nbsp;&nbsp;&nbsp;首页人员显示大小为：  50x50
            </div>
        </div>
    </div>
    </form>
</body>
</html>
