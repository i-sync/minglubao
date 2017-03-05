<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemInfo.aspx.cs" Inherits="WebAdmin.Enterprise.ItemInfo" ValidateRequest="false" %>
<%@ Register Src="~/Controls/Region.ascx" TagPrefix="mlb" TagName="Region" %>
<%@ Register Src="~/Controls/Ueditor.ascx" TagName="Editor" TagPrefix="mlb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业项目详细</title>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <link href="../My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function funupload(url) {
            $("#hdUrl").val(url);
            //$("#imgPhoto").css("width", 110);
            $("#imgPhoto").css("height", 150);
            $("#imgPhoto").attr("src", "/" + url + "?a=" + Math.random());
        }

        $(function () {
            //删除个人留言
            $(".del").click(function () {
                var mid = $(this).parents("tr").attr("mid");
                $.ajax({
                    type: "GET",
                    url: "handler.ashx",
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
    <table class="tableBorder" cellspacing="1" cellpadding="3" width="98%" align="center" border="0">
        <tr>
            <th class="bigTitle" colspan="2">
                <b>企业项目详细 </b>
            </th>
        </tr>
        <tr>
            <td class="title">
                项目开通状态：
            </td>
            <td>
                <asp:Literal ID="ltOpenFlag" runat="server"></asp:Literal>
                <asp:Button ID="btnOpenFlag" runat="server" Text="开通" Visible="false" OnClick="btnOpenFlag_Click" />
            </td>
        </tr>
        <tr>
            <td class="title">
                项目名称：
            </td>
            <td>
                <asp:TextBox ID="txtItemName" Width="500" CssClass="txt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                项目简介：
            </td>
            <td>
                <asp:TextBox ID="txtItemIntro" Width="500" CssClass="txt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title">
                项目口号：
            </td>
            <td>
                <asp:TextBox ID="txtSignature" Width="500" CssClass="txt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="title" valign="top">
                项目内容：
            </td>
            <td>
                <mlb:Editor ID="txtContent" runat="server" />
            </td>
        </tr>            
        <tr>
            <td class="title" valign="top">
                项目照片：
            </td>
            <td style="width:50%;">
                <asp:Image ID="imgPhoto" runat="server" style="display:block;border:1px solid #ccc" Height="150"/><br />
                <asp:HiddenField ID="hdUrl" runat="server" />
                <iframe frameborder="0" src="../Controls/Upload.aspx?folder=<%=MLMGC.COMP.Config.EnterpriseItemPhotoFolder %>" width="320" height="30"></iframe>
            </td>
        </tr>
        <tr>
            <td  class="title">
                成立时间：
            </td>
            <td>
                <asp:TextBox ID="txtEstablished" runat="server" CssClass="txt Wdate"  onfocus="WdatePicker({dataFmt:'yyyy-MM-dd'});" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title" >
                所在城市：
            </td>
            <td>
                <mlb:Region ID="region" runat="server" />
            </td>
            <td >
            </td>
        </tr>
        <tr>
            <td class="title" >
                状态：
            </td>
            <td>
                <asp:RadioButtonList ID="rbStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td >
                <asp:Button ID="btnSubmit" CssClass="btn1" Text="确定" OnClick="btnSubmit_Click" runat="server" />
                <input type="button" value="返回" class="btn1" onclick="window.location.replace('itemlist.aspx');" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="margin-bottom:20px;padding:20px;">
                    <div style="margin:10px 20px;">
                        <span>留言列表</span>
                        <div style="width:800px;border-top:1px solid black;padding:20px auto;">
                            <asp:Repeater ID="rpList" runat="server">
                                <ItemTemplate>
                                    <table style="margin:5px 5px;border-bottom:1px dotted #ccc;width:750px;">
                                        <tr mid="<%#Eval("ID") %>">
                                            <td rowspan="2" style="width:60px;height:60px; vertical-align:top;" >
                                                <img style="width:40px;height:40px;" src="<%#MLMGC.COMP.Config.GetPersonalAvatarUrl(Eval("Avatar").ToString()) %>" />
                                            </td>
                                            <td><%#Eval("UserName") %>&nbsp;&nbsp;(<%#Eval("AddDate") %>)</td>
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
            </td>
        </tr>

    </table>
    </form>
</body>
</html>
