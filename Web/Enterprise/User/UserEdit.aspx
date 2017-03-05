<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Web.Enterprise.User.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户编辑</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //--更改角色处理
            $(":checkbox[name*='cblRole']").click(function () {
                    var checked =this.checked;
                    var tdObj = $(this).parent().siblings("td");
                    if (checked == undefined || checked==false) {
                        $(tdObj).find(":radio[name*='rblTeam']").each(function () {
                            $(this).removeAttr("checked");
                            $(this).attr("disabled", "disabled");
                        });
                    } else {
                        if ($(tdObj).find(":radio[name*='rblTeam']").length == 1) {
                            $(tdObj).find(":radio[name*='rblTeam']").attr("checked", true).removeAttr("disabled");
                        } else {
                            $(tdObj).find(":radio[name*='rblTeam']").each(function () {
                                $(this).removeAttr("disabled");
                            });
                        }
                    }
                });
                //-----验证
            //------------判断用户名是否存在-------------------
            $("#txtUserName").blur(function () {
                var username = $(this).val();
                var userid =<%=userid %>;
                var msg = "";
                if ($.IsNullOrEmpty(username)) {
                    msg = "<span class='error'>请输入登录账号</span>";
                    $("#TipsUserName").html(msg);
                    return;
                }
                if (!/^\w{4,30}$/.test(username)) {
                    $("#TipsUserName").html("<span class='error'>请输入正确帐号，4-30位</span>");
                    return;
                }
                $.ajax({
                    type: "POST",
                    url: "../Handler/User.ashx",
                    data: { key: "exist", username: username ,userid:userid },
                    success: function (data) {
                        if (data == "1") {
                            msg = "<span class='error'>登录账号已存在</span>";
                        }
                        else if (data == "0") {
                            msg = "<span class='succ'>该账号可以使用</span>";
                        }
                        else {
                            msg = "<span class='error'>" + data + "</span>"
                        }
                        $("#TipsUserName").html(msg);
                    },
                    dataType: "text"
                });
            });

            $("#txtPassword").blur(function () {
//                var type =<%=type %>;
//                alert(type);
//                if(type=="add")
//                {
//                var content = $.trim($(this).val());
//                var msg = "";
//                if ($.IsNullOrEmpty(content)) {
//                    msg = "<span class='error'>请输入密码</span>";
//                }
//                else if (content.length < 4) {
//                    msg = "<span class='error'>密码至少为4位</span>";
//                }
//                else if(content.length>30)
//                {
//                    msg="<span class='error'>请输入30位以内的密码</span>";
//                }
//                else {
//                    msg = "";
//                }
//                $("#TipsPassword").html(msg);
//               }
            });

            $("#txtTrueName").blur(function () {
                var content = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(content)) {
                    msg = "<span class='error'>请输入姓名</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsTrueName").html(msg);
            });
            //------------提交表单---------
            $("form").submit(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    return false;
                }
                //--获取角色信息
                var aryRole = new Array();
                var msg = "";
                $(":checked[name*='cblRole']").each(function () {
                    var roleName = $.trim($(this).parent().text());
                    var teamObj = $(this).parent().siblings("td").find(":checked[name*='rblTeam']");
                    var rid=0;
                    
                        if ($(teamObj).length == 0) {
                            msg = "请选择[" + roleName + "]所在位置";
                            return false;
                        }
                       rid=$(teamObj).val();
                   
                    aryRole.push($(this).val() + ":" + rid);
                });
                if (msg != "") { alert(msg); return false; }
                $("#hdRoleInfo").val(aryRole.join(","));
                return true;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            用户编辑</h3>
    </div>
    <div class="tabInfo" style=" margin-top:5px;">
        <div>
            <span>当前已使用人数：</span>
            <asp:Literal ID="liNum" runat="server"></asp:Literal>
            <span>/</span>
            <asp:Literal ID="liCount" runat="server"></asp:Literal>
        </div>
        <table style="width: 100%;">
            <tr>
                <td class="w120" style="text-align: right;">
                    登录帐号：
                </td>
                <td class="w190">
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="txt" />
                </td>
                <td id="TipsUserName" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    登录密码：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" MaxLength="30" CssClass="txt" />
                </td>
                <td style="width:115px;">                
                    <span>(密码长度为4-30)</span>
                </td>
                <td id="TipsPassword">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    用户姓名：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTrueName" CssClass="txt" />
                </td>
                <td id="TipsTrueName"  colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div style="line-height: 100%; padding: 0; margin: 10px 0 0 0;">
                        <b>部门角色设置</b></div>
                        <asp:HiddenField runat="server" ID="hdRoleInfo" />
                    <table cellpadding="1" cellspacing="1" class="tablist" style="width: auto;">
                        <tr>
                            <th style="width: 120px;">
                                角色
                            </th>
                            <th>
                                所在部门
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList" OnItemDataBound="rpList_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td style="padding-left: 15px;">
                                        <input type="checkbox" name="cblRole" id="cblRole" runat="server" clientidmode="Predictable" />
                                        <label for="rpList_cblRole_<%#Container.ItemIndex %>">
                                            <%#Eval("RoleName") %></label>
                                    </td>
                                    <td style="padding: 0 5px;">
                                        <asp:RadioButtonList runat="server" ID="rblTeam" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSubmit" Text="保存" OnClick="btnSubmit_Click" CssClass="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnBack" name="btnBack" value="返回" onclick="location.href='UserList.aspx';"
                        class="btn" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
