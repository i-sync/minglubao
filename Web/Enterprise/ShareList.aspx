<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareList.aspx.cs" Inherits="Web.Enterprise.ShareList" %>

<%@ Register Src="Controls/Property.ascx" TagName="Property" TagPrefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>共享池</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/hover.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>    
    <script src="/JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var Operate_CONFIG = {
            Post_URL: "handler/CIHandler.ashx", //------提交地址
            selector: ":checked[name='cbClient']", //---选择器
            GetIDs: function () {//获取编号
                if (this.selector.length > 0) {//使用选择器
                    var ids = new Array();
                    $(this.selector).filter(":checked").each(function () {
                        ids.push($(this).val());
                    });
                    if (ids.length == 0) {
                        PopTip.Show(PopTip.Type.Error, "请选择名录信息", false);
                        return null;
                    }
                    return ids.join(',');
                }
                else {
                    PopTip.Show(PopTip.Type.Error, "配置错误，未能完成操作", false);
                    return null;
                }
            }
        };

        $(function () {
            //设置列表宽度（使不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);
            $(".cilist_list .item").hoverForIE6();

            //全选
            $.CheckAllOperate("#cbAll", ".cilist_list :checkbox[name='cbClient']");

            //放入我的潜在客户
            $("#btnMyGet").click(function () {
                var data = "ciid=" + Operate_CONFIG.GetIDs();
                $.post(Operate_CONFIG.Post_URL + "?act=myget", data, function (data) {
                    var msg = "";
                    if (data == "1") {
                        //msg="操作成功";
                        PopTip.Show(PopTip.Type.Succ, "操作成功", true);
                    }
                    else {
                        //msg="操作失败";
                        PopTip.Show(PopTip.Type.Error, "操作失败", false);
                    }
                }, "text");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
        共享池</h3>
    </div>
    
    <div class="divlist">
        <table>
            <tr>
                <td>
                    名录名称：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1 w300" ID="txtName" />
                </td>
                <td>
                    <mlb:Property ID="Property1" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" CssClass="btn1" Text="检索" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div style="margin:5px 20px; padding:5px 10px;">
        <input type="button" id="btnMyGet" runat="server" value="放入我的潜在客户数据库" class="btn1 top10"
            style="display: block;" />
    </div>
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">
                    <input type="checkbox" name="cbAll" id="cbAll" value="-1" />
                </li>
                <li class="operate">
                    查看
                </li>
                <li class="name">
                    名录名称
                </li>
                <li class="time">
                    共享日期
                </li>
                <%if (TradeFlag)
                  { %><li class="property">
                      行业
                  </li>
                <%} if (AreaFlag)
                  { %><li class="property">
                      地区
                  </li>
                <%} if (SourceFlag)
                  { %>
                <li class="property">
                    来源
                </li>
                <%} %>
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
                        <div class="operate">
                            <a href="clientinfo/info.aspx?ciid=<%#Eval("ClientInfoID") %>">查看</a>
                        </div>
                        <div class="name">
                            <a href="clientinfo/info.aspx?ciid=<%#Eval("ClientInfoID") %>" title="备注：<%#Eval("Remark") %>">
                                <%#Eval("ClientName") %></a>
                        </div>
                        <div class="time">
                            <%#Eval("UpdateStatusDate", "{0:yyyy-MM-dd HH:mm}")%>
                        </div>
                        <%if (TradeFlag)
                          { %><div class="property">
                            <%#Eval("TradeName") %>
                        </div>
                        <%} if (AreaFlag)
                          { %>
                        <div class="property">
                            <%#Eval("AreaName") %>
                        </div>
                        <%} if (SourceFlag)
                          { %>
                        <div class="property">
                            <%#Eval("SourceName") %>
                        </div>
                        <%} %>
                        <i class="clear"></i>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>       
    <MLB:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />    
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=19" type="text/javascript"></script>
</body>
</html>
