<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="Web.Personal.Feedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>反馈问题</title>
    <script type ="text/javascript" src ="../JS/jquery-1.6.4.js"></script>
    <script type ="text/javascript" src ="../JS/common.js"></script>
    <link href ="../Styles/Site.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtSubject").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入标题</span>";
                }
                else if (v.length < 6) {
                    msg = "<span class='error'>标题字符太少</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsSubject").html(msg);
            });

            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
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
        <h3>反馈问题</h3>
    </div>
    <div class="divlist">
        <table cellpadding="1" cellspacing ="1" class ="tabtxtlist">
            <tr>
                <td>标题：</td>
                <td>
                    <asp:TextBox ID ="txtSubject" runat="server" CssClass ="txt w420"></asp:TextBox>
                </td>
                <td id="TipsSubject">
                
                </td>
            </tr>
            <tr>
                <td valign="top">描述：</td>
                <td>
                    <asp:TextBox ID ="txtDetail" TextMode ="MultiLine" CssClass="area w500" Rows ="10" Columns= "40"  runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>附件：</td>
                <td>  
                    <MLB:FileUpload runat="server" ID="FileUpload1" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID ="btnSubmit" Text ="确定" OnClick ="btnSubmit_Click" CssClass ="btn" runat="server"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value ="取消" class="btn" id ="btnCancel"/>    
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>      
    </div>
    </form>
</body>
</html>
