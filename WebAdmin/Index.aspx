<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebAdmin.Index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录宝管理系统</title>
    <script src="js/jquery-1.6.4.js" type="text/javascript"></script>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function initSize() {
            var width = parseInt($(window).width());
            if (width < 1004) { width = 1004; }
            $("#divPage").css("width",width);
            $("#divPage .right").css("width",width-160);
        }
        $(function () {
            var h = $(document).height() - 2;
            $("#divPage").height(h);
            $(".menu_title").click(function () {
                if ($(this).attr("class") == "menu_title") {
                    return;
                }
                if ($(this).is(".menu_show")) {
                    $(this).parent().siblings("tr").find(".sec_menu").hide();
                    $(this).removeClass("menu_show").addClass("menu_hide");
                } else {
                    $(this).parent().siblings("tr").find(".sec_menu").show();
                    $(this).removeClass("menu_hide").addClass("menu_show");
                }
            });
            initSize();
            $(window).resize(initSize);

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1010px;margin: auto;" id="divPage">
        <div class="left">
            <table width="100%" cellpadding="0" cellspacing="0" border="0" align="left">
                <tr>
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td valign="bottom">
                                    <img src="images/admin_title.gif" width="158" height="38">
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title"  background="images/title_bg_quit.gif">
                                    <span><a href="index.aspx" target="_top"><b>管理首页</b></a> | <a href="Logout.aspx"
                                        target="_parent"><b>退出</b></a></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="sec_menu" style="width: 158px">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    用户名：<font color="red"><asp:Literal runat="server" ID="ltUserName" /></font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    身&nbsp;&nbsp;份：<font color="red">超级管理员</font>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <br />

                        <!--管理员-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title menu_show">
                                    <span>管理员</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: block">
                                    <div class="sec_menu" style="width: 158">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    <a href="UpdatePassword.aspx" target="main">修改密码</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="AdminList.aspx" target="main">管理员列表</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 158px; height:10px;">
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <!--企业管理-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title menu_show">
                                    <span>企业管理</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: block">
                                    <div class="sec_menu" style="width: 158">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    <a href="Enterprise/AddEnterprise.aspx" target="main">添加企业</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="Enterprise/List.aspx" target="main">企业用户列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="Enterprise/Apply/ApplyList.aspx" target="main">企业申请列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="Enterprise/Menu/MenuList.aspx" target="main">菜单提示管理</a>
                                                </td>
                                            </tr>                                            
                                        </table>
                                    </div>
                                    <div style="width: 158px; height:10px;">
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <!--个人管理-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title menu_show">
                                    <span>个人管理</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: block">
                                    <div class="sec_menu" style="width: 158">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    <a href="User/PersonalList.aspx" target="main">个人用户列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="User/LoginList.aspx" target="main">个人登录信息列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="Weibo/List.aspx" target="main">个人微博信息列表</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 158px; height:10px;">
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <!--信息管理-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title menu_show">
                                    <span>信息管理</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: block">
                                    <div class="sec_menu" style="width: 158">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    <a href="FeedbackList.aspx" target="main">反馈信息列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="Public/AnnList.aspx" target="main">公告信息</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 158px; height:10px;">
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <!--文库管理-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title menu_show">
                                    <span>文库管理</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: block">
                                    <div class="sec_menu" style="width: 158">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    <a href="WenKu/WenKuClassList.aspx" target="main">文库分类管理</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="WenKu/CheckList.aspx?status=0" target="main">待审核列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="WenKu/CheckList.aspx?status=1" target="main">审核通过列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="WenKu/CheckList.aspx?status=2" target="main">审核未通过列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="WenKu/CheckList.aspx?status=3" target="main">下线列表</a>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div style="width: 158px; height:10px;">
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <!--项目管理-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title menu_show">
                                    <span>项目管理</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: block">
                                    <div class="sec_menu" style="width: 158">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    <a href="Enterprise/itemlist.aspx" target="main">企业项目列表</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20">
                                                    <a href="Enterprise/itemmessagelist.aspx" target="main">企业项目留言</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 158px; height:10px;">
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <!--系统管理-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title menu_show">
                                    <span>系统管理</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: block">
                                    <div class="sec_menu" style="width: 158">
                                        <table cellpadding="0" cellspacing="0" align="center" width="135">
                                            <tr>
                                                <td height="20">
                                                    <a href="enterprise/enterprisedb/list.aspx" target="main">企业数据库列表</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 158px; height:10px;">
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <!--系统信息-->
                        <table cellpadding="0" cellspacing="0" width="158" align="center">
                            <tr>
                                <td height="25" class="menu_title"  background="images/admin_left_2.gif">
                                    <span>系统信息</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="sec_menu" style="width: 158px">
                                        <table cellpadding="0" cellspacing="0" align="center" width="150">
                                            <tr>
                                                <td height="20" style=" line-height:100%; font-size:12px;">
                                                    <br />
                                                    版权所有：名录宝<br />
                                                    <br />
                                                    技术开发：名录宝<br />
                                                    <br />
                                                    版本：20111001<br />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="right">
            <iframe src="Main.aspx" frameborder="0" scrolling="auto" name="main" id="main" style="width: 100%;
                height: 100%;"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
