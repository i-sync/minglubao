<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginList.aspx.cs" Inherits="WebAdmin.User.LoginList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�����û���¼</title>
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //������ʾʱ�����������         
            $("input:radio").click(function () {
                if ($(this).val() == "2") {
                    $("#tdDate").show();
                }
                else {
                    $("#tdDate").hide();
                }
            });
            //���������� ������Ҫ��ʾ��Ч��
            $(":checked").triggerHandler("click");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    �����û���¼
                </th>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                ����
                            </td>
                            <td>
                                <asp:RadioButtonList ID ="rbList" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server">
                                    <asp:ListItem Text="����δ��¼" Value ="0"></asp:ListItem>
                                    <asp:ListItem Text ="��Ծ" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text ="����" Value ="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td id="tdDate" style="display:none;">
                                ����¼���ڣ�                            
                                <asp:TextBox ID ="txtStartDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" ></asp:TextBox>
                                <span>---</span>
                                <asp:TextBox ID="txtEndDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" ></asp:TextBox>
                            </td> 
                        </tr>
                        <tr>                            
                            <td>
                                �˺ţ�
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUserName" />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnSearch" Text="����" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="tablist" cellpadding="1" cellspacing="1">
                        <tr>
                            <th>
                                ���
                            </th>
                            <th>
                                �˺�
                            </th>
                            <th>
                                ����
                            </th>  
                            <th>
                                ע������
                            </th>
                            <th>
                                ����¼����  
                            </th>
                            <th>
                                ��¼����
                            </th>                
                            <th>
                                ��Ծ����
                            </th>
                            <th>
                                ��Ծָ��
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
                                        <%#Eval("UserName") %>
                                    </td>
                                    <td>
                                        <%#Eval("RealName") %>
                                    </td>                        
                                    <td>
                                        <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </td> 
                                    <td>
                                        <%#Eval("LastLoginDate","{0:yyyy-MM-dd HH:mm}") %>
                                    </td> 
                                    <td>
                                        <%#Eval("LoginAmount") %>
                                    </td>
                                    <td>
                                        <%#Eval("ActiveDay") %>
                                    </td>                      
                                    <td>
                                        <%#Eval("ActiveIndex") %>
                                    </td>                          
                                    <td>
                                        <a href="LoginDetail.aspx?id=<%#Eval("LoginInfoID") %>">�鿴</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div>
                        <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;"
                        AlwaysShow="true" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageSize="1"
                        PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                    </div>                    
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
