<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyList.aspx.cs" Inherits="WebAdmin.Enterprise.Apply.ApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业申请列表</title>    
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script type="text/javascript" src ="../../js/jquery-1.6.4.js"></script>
    <script type ="text/javascript" src ="../../My97DatePicker/WdatePicker.js"></script>
    <link href="../../images/main.css" rel="stylesheet" type="text/css" />
    <link type ="text/css" rel ="Stylesheet" href ="../../My97DatePicker/skin/WdatePicker.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="tableBorder" width="98%"  border="0" align="center">
            <tr>
                <th class="bigTitle">企业申请列表</th>
            </tr>
            <tr>
                <td>
                    <table>
                    <tr>
                        <td>企业名称：</td>
                        <td>
                            <asp:TextBox  ID ="txtName" runat="server"></asp:TextBox>
                        </td>
                        <td>申请日期：</td>
                        <td>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtStartDate" runat="server" />
                            <span>---</span>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtEndDate" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID ="btnSearch" Text ="检索" OnClick="btnSearch_Click" runat="server" />
                        </td>
                    </tr>
                </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="tablist" cellspacing="1" cellpadding="1">
                    <tr>
                        <th>
                            序号
                        </th>
                        <th>
                            企业名称
                        </th>
                        <th>
                            申请日期
                        </th>
               
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                           <tr>
                                <td>
                                    <%#Eval("nid") %>
                                </td>                       
                                <td>
                                    <a href="ApplyDetail.aspx?applyid=<%#Eval("ApplyID") %>">
                                        <%#Eval("EnterpriseName") %></a>
                                </td>
                                <td>
                                    <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                                </td>                        
                                <td>
                                    <a onclick="return confirm('确认要删除吗？');" href="ApplyList.aspx?type=delete&applyid=<%#Eval("ApplyID") %>">删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                    <div>
                        <mlb:aspnetpager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                            PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                            TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                            AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" 
                            NextPageText="下一页" PageSize="1" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                            LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" 
                            UrlPaging="true" />
                    </div>
                </td>
            </tr>
        </table>        
    </div>
    </form>
</body>
</html>
