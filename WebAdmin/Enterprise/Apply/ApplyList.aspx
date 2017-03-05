<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyList.aspx.cs" Inherits="WebAdmin.Enterprise.Apply.ApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��ҵ�����б�</title>    
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
                <th class="bigTitle">��ҵ�����б�</th>
            </tr>
            <tr>
                <td>
                    <table>
                    <tr>
                        <td>��ҵ���ƣ�</td>
                        <td>
                            <asp:TextBox  ID ="txtName" runat="server"></asp:TextBox>
                        </td>
                        <td>�������ڣ�</td>
                        <td>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtStartDate" runat="server" />
                            <span>---</span>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtEndDate" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID ="btnSearch" Text ="����" OnClick="btnSearch_Click" runat="server" />
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
                            ���
                        </th>
                        <th>
                            ��ҵ����
                        </th>
                        <th>
                            ��������
                        </th>
               
                        <th>
                            ����
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
                                    <a onclick="return confirm('ȷ��Ҫɾ����');" href="ApplyList.aspx?type=delete&applyid=<%#Eval("ApplyID") %>">ɾ��</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                    <div>
                        <mlb:aspnetpager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                            PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                            TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;"
                            AlwaysShow="true" FirstPageText="��ҳ" LastPageText="βҳ" 
                            NextPageText="��һҳ" PageSize="1" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
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
