<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="Web.Personal.Item.ItemList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业项目</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);


            //点击跳转页面
            $("#btnJump").click(function () { 
                var itemid =<%=itemid %>;
                window.location.replace("applyquit.aspx?itemid="+itemid);
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <h3 style="margin:10px 20px;display:inline;">企业项目</h3>
            &nbsp;&nbsp;
            <h4 style="display:inline;">
                <asp:Label ID="lblStatus" style="color:Red" runat="server"></asp:Label>
            </h4>
            &nbsp;&nbsp;
            <asp:Button ID="btnJump" CssClass="btn1" Visible="false" Text="申请退出" runat="server" />
        </div>
        <div class="divlist" style="margin:5px 10px;padding:5px 10px;">
            <span>名称：</span>
            <asp:TextBox ID="txtName" CssClass="txt w420" runat="server"></asp:TextBox>
            <asp:Button ID ="btnSearch" CssClass="btn1" OnClick="btnSearch_Click" runat="server" Text ="检索" />
        </div>

        <div class="cilist">
            <div class="cilist_title">
                <ul>
                    <li class="num">
                        序号
                    </li>
                    <li class="name">
                        名称
                    </li>
                    <li class="name">
                        简介
                    </li>
                    <li class="name">
                        口号
                    </li>
                    <li class="time">
                        成立时间
                    </li>
                </ul>
            </div>
            <i class="clear"></i>
            <div class="cilist_list">
                 <asp:Repeater runat="server" ID="rpList">
                    <ItemTemplate>
                        <div class="item "> 
                            <div class="num">
                                <%#Eval("nid") %>
                            </div>                           
                            <div class="name">
                                <a href="ItemInfo.aspx?eid=<%#Eval("EnterpriseID") %>&iid=<%#Eval("ItemID") %>&backurl=itemlist.aspx">
                                    <%#Eval("ItemName") %>
                                </a>
                            </div>
                            <div class="name">
                                <%#Eval("ItemIntro") %>
                            </div>
                            <div class="name">
                                <%#Eval("Signature") %>
                            </div>
                            <div class="time">
                                <%#Eval("Established", "{0:yyyy-MM-dd}")%>
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
    
</body>
</html>
