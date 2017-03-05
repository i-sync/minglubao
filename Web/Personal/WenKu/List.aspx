<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.Personal.WenKu.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的资料</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //设置列表宽度（使列头不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>我的资料</h3>
    </div>
    <div class="divlist">
        <div style="float:left;">
            <div style="vertical-align:middle;"><span>名称：</span><asp:TextBox ID="txtName" CssClass="txt w420" runat="server"></asp:TextBox></div>
            <div style="margin-left:35px;">
                <asp:RadioButtonList ID="rdType" RepeatDirection="Horizontal" RepeatLayout="Table" runat="server">                    
                </asp:RadioButtonList>
            </div>
        </div>
        <div style="float:left;">
            分类：<asp:DropDownList ID ="ddlCategory" CssClass="ddl w120" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID ="btnSearch" CssClass="btn" OnClick="btnSearch_Click" runat="server" Text ="检索" />
        </div>
        <i class="clear"></i>
    </div>
    
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">编号</li>
                <li class="name">文档名称</li>
                <li class="name">介绍</li>
                <li class="person">分类</li>
                <li class="operate">浏览次数</li>                
                <li class="operate">下载次数</li>
                <li class="time">上传时间</li>
            </ul>
        </div>
        <i class="clear"></i>
        <div class="cilist_list">
            <asp:Repeater ID="rpList" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <div class="num">
                            <%# Container.ItemIndex + pageSize * (pageIndex - 1) + 1%>
                        </div>
                        <div class="name">
                            <a href="/WenKu/Info.aspx?id=<%#Eval("WenKuID") %>" target="_blank" ><%#Eval("Caption") %></a>
                        </div>
                        <div class="name">
                            <%#Eval("Intro") %>
                        </div>
                        <div class="person">
                            <%#Eval("WenKuClassName").ToString().Equals("") ? "其它" : Eval("WenKuClassName")%>
                        </div>
                        <div class="operate">
                            <%#Eval("ReadNum") %>
                        </div>
                        <div class="operate">
                            <%#Eval("DownNum") %>
                        </div>
                        <div class="time">
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                        </div>
                    </div>
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
    </form>
</body>
</html>
