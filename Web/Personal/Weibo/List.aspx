<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.Personal.Weibo.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">
    <div id="list">
        <asp:Repeater runat="server" ID="rpList">
            <ItemTemplate>
                <dl class="feed_list" weiboid="<%#Eval("WeiboID") %>">
                    <dt class="face"><a title="wongbenson">
                        <img width="50" height="50" src="<%#MLMGC.COMP.Config.GetPersonalAvatarUrl(Eval("Avatar").ToString()) %>"
                            alt="" title="<%#Eval("RealName")%>" /></a> </dt>
                    <dd class="content">
                        <p>
                            <a href="javascript:void(0);" title="<%#Eval("RealName")%>">
                                <%#Eval("RealName")%></a> ：<em><%#Eval("Detail")%></em></p>
                        <p class="info">
                            <%if (type.Equals("personal"))
                              { %>
                                <span><a href="javascript:void(0)" class="del">删除</a></span>
                            <%} %>
                            <a title="<%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>" class="date">
                                <%# Web.Enterprise.weibo.WEIBOHelper.ShowTime(Eval("AddDate"))%></a>
                        </p> 
                    </dd>
                    <i class="clear"></i>
                </dl>
            </ItemTemplate>
        </asp:Repeater>
        <mlmgc:Paging runat="server" ID="mlmgcPaging" StyleType="weibo" />
    </div>
    </form>
</body>
</html>
