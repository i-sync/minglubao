<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMessage.aspx.cs" Inherits="Web.Enterprise.Config.ItemMessage" %>
<%@ Register Src="~/Controls/Region.ascx" TagPrefix="mlb" TagName="Region" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言信息</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
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
            //删除个人留言
            $(".del").click(function () {
                var mid = $(this).parents("tr").attr("mid");
                $.ajax({
                    type: "POST",
                    url: "/enterprise/handler/item.ashx",
                    data: { key: "deletemessage", mid: mid },
                    success: function (data) {
                        if (data == "1") {
                            reload();
                        }
                        else {
                            alert("删除失败");
                        }
                    },
                    dataType: "text"
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3 style="display:inline;margin:auto 20px;">
            留言信息</h3>
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
                        <table style="margin:5px 5px;border-bottom:1px dotted #ccc;width:750px;">
                            <tr mid="<%#Eval("ID") %>">
                                <td rowspan="2" style="width:60px;height:60px; vertical-align:top;" >
                                    <img style="width:40px;height:40px;"  src="<%#MLMGC.COMP.Config.GetPersonalAvatarUrl(Eval("Avatar").ToString()) %>" />
                                </td>
                                <td ><%#Eval("UserName") %>&nbsp;&nbsp;(<%#Eval("AddDate") %>)</td>
                                <td rowspan="2" style="width:50px; vertical-align:bottom; text-align:right;">
                                    <a class="del" href="javascript:void(0);">删除</a>
                                </td>
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
    </form>
</body>
</html>
