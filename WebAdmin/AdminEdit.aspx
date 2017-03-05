<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="WebAdmin.AdminEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="images/main.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var CONFIG ={
            POST_URL:"/handler/user.ashx"
        }
        $(function () {
            //验证信息
            $("#txtName").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                var id = <%=id %>;
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入用户名</span>";
                }
                else {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: CONFIG.POST_URL,
                        data: { type: "adminexists", id: id, name: v },
                        success: function (data) {
                            if (data == "1") {
                                msg = "<span class='error'>用户名已存在</span>";
                            }
                            else {
                                msg = "";
                            }
                        },
                        dataType: "text"
                    });
                }
                $("#TipsName").html(msg);
            });
            //密码
            $("#txtPassword").blur(function () {
                //操作类型
                var type = "<%=type %>";
                if (type == "add") {
                    var v = $(this).val();
                    var msg = "";
                    if ($.IsNullOrEmpty(v)) {
                        msg = "<span class='error'>请输入密码</span>";
                    }
                    else if (v.length < 4) {
                        msg = "<span class='error'>密码至少为4位</span>";
                    }
                    else if (v.length > 30) {
                        msg = "<span class='error'>密码最长为30位</span>";
                    }
                    else {
                        msg = "";
                    }
                    $("#TipsPassword").html(msg);
                }
                else {
                    $("#TipsPassword").html("");
                }
            });
            //确认密码
            $("#txtConfirm").blur(function(){
                var v = $.trim($(this).val());
                var msg="";
                if(v != $.trim($("#txtPassword").val()))
                {
                    msg="<span class='error'>两次密码不一致</span>";
                }
                $("#TipsConfirm").html(msg);
            });

            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    修改管理员信息
                </th>
            </tr>
            <tr>
                <td>
                    <table >
                        <tr >
                            <td style="text-align:right" >
                                用户名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                            <td id="TipsName">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right">密&nbsp;&nbsp;码：</td>
                            <td>
                                <asp:TextBox ID= "txtPassword" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                            <td id="TipsPassword"></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">确认密码：</td>
                            <td>
                                <asp:TextBox ID= "txtConfirm" CssClass="txt" runat="server"></asp:TextBox>
                            </td>
                            <td id="TipsConfirm"></td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID ="btnSubmit" OnClick ="btnSubmit_Click" Text ="确定" runat="server" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="button" id="btnCancel" onclick="window.location.replace('adminlist.aspx');" value="取消"/>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>            
        </table>
    </div>
    </form>
</body>
</html>
