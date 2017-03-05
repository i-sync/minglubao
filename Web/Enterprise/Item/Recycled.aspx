<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recycled.aspx.cs" Inherits="Web.Enterprise.Item.Recycled" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>回收站</title>
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/poptip.js" type="text/javascript"></script>
    <script src="/JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <link href="/JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //获取所有选择的名录编号
        function GetIDs() {
            var sender = $(":checked[name='cbClient']");
            if (sender.length > 0) {//使用选择器
                var ids = new Array();
                $(sender).each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    //alert("请选择名录信息");
                    PopTip.Show(PopTip.Type.Error, "请选择名录信息", false);
                    return false;
                }
                $("#hdClientInfoIDs").val(ids.join(','));
                return true;
            }
            else {
                //alert("配置错误，未能完成操作！");
                PopTip.Show(PopTip.Type.Error, "请选择名录信息", false);
                return false;
            }
        }
        $(function () {
            //设置列表宽度（使不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);

            //全选
            $.CheckAllOperate("#cbAll", ".cilist_list :checkbox[name='cbClient']");


            $("#btnDelete").click(function () {
                if (GetIDs()) {
                    if (!confirm("确定要删除这些名录吗?删除后无法恢复。")) {
                        return false;
                    }
                }
                else {
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>回收站</h3>
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
                    删除日期：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtStartDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
                        CssClass="Wdate txt1" />
                    --
                    <asp:TextBox runat="server" ID="txtEndDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
                        CssClass="Wdate txt1" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" Text="检索" CssClass="btn1" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style=" margin:5px;padding:5px 15px;">
        <asp:Button ID = "btnDelete" Text="彻底删除" OnClick="btnDelete_Click" CssClass="btn1" runat="server" />
        &nbsp;&nbsp;
        <asp:Button ID = "btnDeleteAll" Text="删除所有" OnClick="btnDeleteAll_Click" CssClass="btn1" runat="server" />
    </div>
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">
                    <input type="checkbox" name="cbAll" id="cbAll" value="-1" />
                </li>
                <li class="name">名录名称 </li>
                <li class="time">录入时间</li>
                <li class="time">删除时间 </li>  
                <li class="status">状态</li>      
            </ul>
        </div>
        <i class="clear"></i>
        <!--用来存储选择的名录编号-->
        <asp:HiddenField ID ="hdClientInfoIDs" runat="server" />
        <div class="cilist_list">
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <div class="item ">
                        <div class="num">
                            <input type="checkbox" name="cbClient" value="<%#Eval("ClientInfoID") %>" />
                        </div>
                        <div class="name">              
                            <%#Eval("ClientName") %>
                        </div>
                        <div class="time">
                            <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                        </div>
                        <div class="time">
                            <%#Eval("UpdateDate", "{0:yyyy-MM-dd HH:mm}")%>
                        </div>
                        <div class="status">
                            <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.Enterprise.EnumClientStatus>(Eval("Status").ToString())%>
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
