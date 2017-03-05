<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginDetail.aspx.cs" Inherits="WebAdmin.User.LoginDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人用户登录详情</title>
    <script type="text/javascript" src="../js/jquery-1.6.4.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="tableBorder"  width="99%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    个人用户登录详情
                </th>
            </tr> 
            <tr>
                <td>&nbsp;</td>
            </tr>           
            <tr>
                <td>
                    <table class="tablist" cellpadding="1" cellspacing="1">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                登录日期
                            </th>
                            <th>
                                登录IP
                            </th>  
                            <th>
                                浏览器
                            </th>
                            <th>
                                分辨率  
                            </th>                           
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                               <tr>                        
                                    <td>                            
                                        <%#Eval("nid") %>
                                    </td>                                    
                                    <td>
                                        <%#Eval("LoginDate","{0:yyyy-MM-dd HH:mm}") %>
                                    </td> 
                                    <td>
                                        <%#Eval("LoginIP") %>
                                    </td>
                                    <td>
                                        <%#Eval("Browser") %>
                                    </td>                      
                                    <td>
                                        <%#Eval("Resolution") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div>
                        <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                    </div>  
                    <div>
                        <input type="button" value="返回" onclick="window.location.replace('LoginList.aspx');"/>
                    </div>                  
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
