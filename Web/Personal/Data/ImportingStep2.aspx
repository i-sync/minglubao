<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportingStep2.aspx.cs" Inherits="Web.Personal.Data.ImportingStep2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录导入第二步</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
</head>
<body>
    <div class="nav">
        <h3>
            名录导入</h3>
    </div>
    <form id="form1" runat="server">
    <div class="divlist">
        <div class="step4 step4two">
            <div>
                <a href="ImportingStep1.aspx">1.上传文件</a></div>
            <div class="cur">
                2.映射字段</div>
            <div>
                3.调整数据</div>
            <div>
                4.确认导入</div>
            <i class="clear"></i>
        </div>
        <div class="mar10">
            <table style=" line-height:180%;">
                <tr>
                    <td class="name">
                        名录名称：
                    </td>
                    <td class="w190">
                        <asp:DropDownList runat="server" ID="ddlName" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        地址：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlAddress" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        邮编：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlZipCode" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                    <td class="name">
                        网址：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlWebiSite" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        联系人：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLinkman" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                    <td class="name">
                        职务：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPosition" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        电话：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTel" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                    <td class="name">
                        手机：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlMobile" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        传真：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlFax" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                    <td class="name">
                        邮箱：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEmail" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        QQ：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlQQ" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                    <td class="name">
                        MSN：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlMSN" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        备注：
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlRemark" CssClass="w160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnNext" Text="下一步" CssClass="btn1" 
                            onclick="btnNext_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
