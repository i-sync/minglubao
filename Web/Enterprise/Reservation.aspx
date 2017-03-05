<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="Web.Enterprise.Reservation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预约名录</title>
    <script type="text/javascript" src="../JS/jquery-1.6.4.js"></script>
    <script src="../JS/hover.js" type="text/javascript"></script>
    <script src="../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JS/My97DatePicker/WdatePicker.js"></script>
    <link href="../JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/msgbox.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            预约名录</h3>
    </div>
    <div class="divlist">
        <asp:TextBox ID="txtStartDate" CssClass="Wdate txt1" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',startDate:'%y-%M-%d'});"
            runat="server"></asp:TextBox>
        <span>--</span>
        <asp:TextBox ID="txtEndDate" CssClass="Wdate txt1" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
            runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="btnSearch" Text="检索" CssClass="btn1" OnClick="btnSearch_Click" runat="server" />
    </div>
    <br />
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">
                    序号
                </li>
                <li class="operate">
                    操作
                </li>
                <li class="name">
                    名录名称
                </li>
                <li class="time">
                    预约时间
                </li>
                <li class="time">
                    添加时间
                </li>
                <li class="remind">
                    提醒时间
                </li>
                <li class="type">
                    预约类型
                </li>
            </ul>
        </div>
        <i class="clear"></i>
        <div class="cilist_list">
            <asp:Repeater ID="rpList" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <div class="num">
                            <%#Eval("nid") %>
                        </div>
                        <div class="operate">
                            <a href="javascript:void(0);" class="del" rid="<%#Eval("ReservationID") %>">取消预约</a>
                        </div>
                        <div class="name">
                            <a href="ClientInfo/track.aspx?ciid=<%#Eval("ClientInfoID") %>&s=reservation">
                                <%#Eval("ClientName") %></a>
                        </div>
                        <div class="time">
                            <%#Eval("ReservationDate","{0:yyyy-MM-dd HH:mm}") %>
                        </div>
                        <div class="time">
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                        </div>
                        <div class="remind">
                            <%#Eval("AdvanceMinute") %>(分钟)
                        </div>
                        <div class="type">
                            <%#GetReType(Eval("ReType")) %>
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
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=39" type="text/javascript"></script>
    <script type="text/javascript">
        var CONFIG = {
            POST_URL:"Handler/CIHandler.ashx"
        }
        $(function () {
            $(".cilist_list .item").hoverForIE6();

            //取消预约名录
            $(".del").click(function () {
                var rid = $(this).attr("rid");
                if (confirm("确定要取消吗？")) {
                    $.ajax({
                        type: "POST",
                        url: CONFIG.POST_URL + "?act=cancelreser",
                        data: { rid: rid },
                        success: function (data) {
                            if (data == "1") {
                                PopTip.Show(PopTip.Type.Succ, "取消成功", true);
                            }
                            else {
                                PopTip.Show(PopTip.Type.Error, "取消失败", false);
                            }
                        },
                        dataType: "text"
                    });
                }
            });
        });
    </script>
</body>
</html>
