<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemInfo.aspx.cs" Inherits="Web.Personal.Item.ItemInfo" %>
<%@ Register Src="~/Controls/Region.ascx" TagPrefix="mlb" TagName="Region" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业项目信息</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <style type="text/css">
        .info
        {
            margin:10px 20px;
            background-color:#D5D3D4;
            width:70%
            }
        .info tr td
        {
            background-color:White;
            line-height:30px;
            padding:5px 10px;
            }
        .info .name
        {
            width:100px;
            }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#imgPhoto").click(function () {
                if ($(this).attr("src").length > 0) {
                    window.open($(this).attr("src"));
                }
            });

            //提交留言基本验证
            $("#txtUserName").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入您的姓名</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsUserName").html(msg);
            });
            $("#txtMobile").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入您的手机号</span>";
                }
                else if(!$.IsMobile(v))
                {
                    msg = "<span class='error'>请输入正确的手机号</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsMobile").html(msg);
            });
            $("#txtEmail").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入您的邮箱</span>";
                }
                else if (!$.IsEmail(v)) {
                    msg = "<span class='error'>请输入正确的邮箱</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsEmail").html(msg);
            });
            $("#txtMessage").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入您的留言内容</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsMessage").html(msg);
            });

            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
                $("#txtMessage").trigger("blur");
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
        <h3 style="display:inline;margin:auto 20px;">
            企业项目信息</h3>
        <a href="<%=Request["backurl"] %>" >返回</a>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnApply" Text="申请该项目" CssClass="btn1" OnClick="btnApply_Click" runat="server"/>
    </div>
    <div class="divlist">
        <table cellpadding="1" cellspacing="1" class="info">
            <tr>
                <td style="width:300px;">
                    项目照片
                </td>
                <td class="name">
                    项目名称：
                </td>
                <td>
                    <asp:Literal ID="ltItemName" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td rowspan ="4">
                    <asp:Image ID="imgPhoto" runat="server" style="display:block;border:1px solid #ccc" Height="150"/>
                </td>
                <td class="name" valign="top"> 
                    项目简介：
                </td>
                <td>
                    <asp:Literal ID="ltItemIntro" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="name">
                    项目口号：
                </td>
                <td>
                    <asp:Literal ID="ltSignature" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="name">
                    成立时间：
                </td>
                <td>
                    <asp:Literal ID="ltEstablished" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="name">
                    所在城市：
                </td>
                <td>
                    <mlb:Region ID="region" IsShowLabel="true" runat="server" />
                </td>
            </tr>
            <tr>  
                <td colspan="3" valign="top"> 
                    项目内容：
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height:200px; vertical-align:text-top;">
                    <asp:Literal ID="ltItemContent" runat="server"></asp:Literal>
                </td>              
            </tr>
        </table>
    </div>

    <div class="divlist" style="margin-bottom:20px;">
        <div style="margin:10px 20px;">
            <span>留言列表</span>
            <div style="width:800px;border-top:1px solid black;padding:20px auto;">
                <asp:Repeater ID="rpList" runat="server">
                    <ItemTemplate>
                        <table style="margin:5px 5px;border-bottom:1px dotted #ccc;width:700px;">
                            <tr>
                                <td width="80" rowspan="2" style="width:60px;height:60px; vertical-align:top;" >
                                    <img style="width:40px;height:40px;"  src="<%#MLMGC.COMP.Config.GetPersonalAvatarUrl(Eval("Avatar").ToString()) %>" />
                                </td>
                                <td ><%#Eval("UserName").ToString().Trim() %>&nbsp;&nbsp;(<%#Eval("AddDate") %>)</td>
                            </tr>
                            <tr>
                                <td><%#Eval("Message") %></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                PrevPageText="上一页" ShowCustomInfoSection="Left" CustomInfoTextAlign="Center"
                LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
        </div>        
    </div>
    <div class="divlist" >
        <div style="margin:10px 20px;">
            <span>留言</span>
            <table>
                <tr>
                    <td style="width:40px;">
                        姓名：
                    </td>
                    <td style="width:300px;">
                        <asp:TextBox ID="txtUserName" CssClass="txt1 w300" runat="server"></asp:TextBox>
                    </td>
                    <td id="TipsUserName">
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        手机：
                    </td>
                    <td>
                        <asp:TextBox  ID= "txtMobile" CssClass="txt1 w300"  runat="server"></asp:TextBox>
                    </td>
                    <td id="TipsMobile">
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        电话：
                    </td>
                    <td>
                        <asp:TextBox  ID= "txtTel" CssClass="txt1 w300"  runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        邮箱：
                    </td>
                    <td>
                        <asp:TextBox  ID= "txtEmail" CssClass="txt1 w300"  runat="server"></asp:TextBox>
                    </td>
                    <td id="TipsEmail">
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>            
                <tr>
                    <td>
                        地址：
                    </td>
                    <td>
                        <asp:TextBox  ID= "txtAddress" CssClass="txt1 w300"  runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        内容：
                    </td>
                    <td colspan="2">
                        <asp:TextBox  ID= "txtMessage" CssClass="txt1" Height="100" Width="500" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                    <td id="TipsMessage" style="vertical-align:top;">
                        
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan ="3">
                        <asp:Button ID="btnSubmit" Text="提交" CssClass="btn1" OnClick = "btnSubmit_Click" runat="server" />
                    </td>
                </tr>
            </table>
        </div>        
    </div>
    </form>
</body>
</html>
