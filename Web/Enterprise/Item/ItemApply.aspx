<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemApply.aspx.cs" Inherits="Web.Enterprise.Item.ItemApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人申请</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //修改申请状态
            $(".update").click(function () {
                var aid = $(this).parent().attr("aid");
                var status = $(this).attr("status");
                $.ajax({
                    type: "POST",
                    url: "/enterprise/handler/item.ashx",
                    data: { key: "updatestatus", aid: aid, status: status,type:"1" },
                    success: function (data) {
                        if (data == "1") {
                            reload();
                        }
                        else if (data == "-1") {
                            alert("该人员已经进入了其它项目组了");
                        }
                        else {
                            alert("操作失败");
                        }
                    },
                    dataType: "text"
                });
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
        <div class="nav">
            <h3>个人申请</h3>
        </div>
        <div class="divlist" style="margin:5px 10px;padding:5px 10px;">
            <span>申请状态：</span>
            <asp:RadioButtonList ID="rbStatus" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server">
            </asp:RadioButtonList>
            &nbsp;&nbsp;
            <span>申请时间:</span>
            <asp:TextBox ID ="txtStartDate" CssClass="Wdate txt1" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server"></asp:TextBox>
            —
            <asp:TextBox ID="txtEndDate"  CssClass="Wdate txt1" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID ="btnSearch" CssClass="btn1" OnClick="btnSearch_Click" runat="server" Text ="检索" />
        </div>

        <div class="cilist">
            <div class="cilist_title">
                <ul>
                    <li class="num">
                        序号
                    </li>
                    <li class="name">
                        姓名
                    </li>
                    <li class="status">
                        状态
                    </li>
                    <li class="time">
                        申请时间
                    </li>
                    <li class="time">
                        申核时间
                    </li>
                    <li class="operate">
                        操作
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
                                <a href="personalinfo.aspx?uid=<%#Eval("UserID") %>&pid=<%#Eval("PersonalID") %>" title="<%#Eval("RealName") %>">
                                    <%#Eval("RealName") %>                                    
                                </a>                             
                            </div>
                            <div class="status">
                                <%#Status(Eval("Status") )%>
                            </div>
                            <div class="time">
                                <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                            </div>
                            <div class="time">
                                <%#Eval("UpdateDate", "{0:yyyy-MM-dd HH:mm}")%>
                            </div>
                            <div class="operate" aid="<%#Eval("ApplyID") %>">
                                <%#Eval("Status").ToString().Equals("0") ? "<a href=\"javascript:void(0);\" class=\"update\" status =\"1\">通过</a><a href=\"javascript:void(0);\" class=\"update\" status =\"2\">未通过</a>" : Status(Eval("Status"))%>                                                        
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
