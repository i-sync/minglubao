<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Web.Personal.Search" %>

<%@ Register src="Controls/Operate.ascx" tagname="Operate" tagprefix="mlb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的名录</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/core.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../JS/popup_layer.js" type="text/javascript"></script>
    <script src="../JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //设置列表宽度（使列头不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);
            $.CheckAllOperate("#cbAll", ":checkbox[name='cbClient']");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div class="listcon">
        <div>
        名称：<asp:TextBox runat="server" ID="txtName" CssClass="txt1" />
        <asp:Button runat="server" CssClass="btn1" ID="btnSearch" Text="检索" onclick="btnSearch_Click" />
    </div>
    <mlb:Operate ID="Operate1" runat="server" selector=".cilist_list :checked[name='cbClient']" />
    </div>
    
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">
                    <input type="checkbox" name="cbAll" id="cbAll" value="-1" />
                </li>
                <li class="name">
                    名录名称
                </li>
                <li class="person">联系人</li>
                <li class="time">
                    更新时间
                </li>
                <li class="status">
                    状态
                </li>
            </ul>
        </div>
        <i class="clear"></i>
        <div class="cilist_list">
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                   <div class="item">
                        <div class="num">
                            <input type="checkbox" name="cbClient" value="<%#Eval("ClientInfoID") %>" />
                        </div>
                        <div title="备注：<%#Eval("Remark") %>" class="name">
                            <a href="ClientInfoTrack.aspx?id=<%#Eval("ClientInfoID") %>">
                                <%#MLMGC.COMP.PageHelper.HighlightKeyword(Eval("ClientName").ToString(), txtName.Text)%></a>
                        </div>
                        <div class="person"><%#Eval("linkman") %></div>
                        <div class="time">
                            <%#Eval("UpdateDate", "{0:yyyy-MM-dd HH:mm}")%>
                        </div>
                        <div class="status">
                            <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.Personal.EnumClientStatus>(Eval("Status").ToString())%>
                        </div>
                        <i class="clear"></i>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>    
    <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
    
    </form>
    <div class="exectime">
        执行时间：<asp:Label ID ="lblExecTime" runat="server"></asp:Label>秒
    </div>
</body>
</html>
