<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Web.Enterprise.Item.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>模糊查询</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/hover.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("form").submit(function () {
                var name = $.trim($("#txtName").val());
                var status = $("#rbStatus").find(":radio[checked]").val();
                var url = "search.aspx?name=" + escape(name) + "&status=" + status;
                location = url;
                return false;
            });

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
    <div class="divlist">
        <table>
            <tr>
                <td>
                    名录名称：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" CssClass="txt1 w300" />
                </td>
                <td>
                    状态：
                </td>
                <td>
                    <asp:RadioButtonList ID="rbStatus" RepeatDirection="Horizontal" RepeatLayout ="Flow" runat="server"></asp:RadioButtonList>
                </td>
                <td>
                    <input type="submit" id="btnSearch" name="btnSearch" class="btn1" value="检索" />
                </td>
            </tr>
        </table>
    </div>

    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">序号</li>
                <li class="name">名录名称</li>
                <li class="linkman">
                    联系人
                </li>
                <li class="tel">
                    电话号码
                </li>
                <li class="mobile">
                    手机号码
                </li>
                <li class="email">
                    电子邮箱
                </li>
                <li class="time">入库时间</li>
                <li class="time">更新时间</li>
                <li class="status">状态</li>
                <li class="location">负责人</li>
            </ul>
        </div>
        <i class="clear"></i>
        <div class="cilist_list">
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <div class="item">
                        <div class="num">
                            <%#Eval("nid") %></div>
                        <div class="name">
                            <a href="info.aspx?ciid=<%#Eval("ClientInfoID") %>"  title="<%#Eval("ClientName") %>">                            
                                <%#MLMGC.COMP.PageHelper.HighlightKeyword(Eval("ClientName").ToString(),txtName.Text) %>                            
                            </a>
                        </div>

                        <div class="linkman">
                            <%#Eval("Linkman") %>
                        </div>
                        <div class="tel">
                            <%#Eval("Tel") %>
                        </div>
                        <div class="mobile">
                            <%#Eval("mobile")%>
                        </div>
                        <div class="email">
                            <%#Eval("email") %>
                        </div>

                        <div class="time">
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                        </div>
                        <div class="time">
                            <%#Eval("UpdateStatusDate", "{0:yyyy-MM-dd HH:mm}")%></div>
                        <div class="status">
                            <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.Item.EnumClientStatus>(Eval("Status").ToString())%></div>
                        <div class="location">
                            <%#Eval("RealName") %></div>
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
