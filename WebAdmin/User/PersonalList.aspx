<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalList.aspx.cs" Inherits="WebAdmin.User.PersonalList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�����û��б�</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <link href="../My97DatePicker/skin/WdatePicker.css" type="text/css" rel="Stylesheet" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //���á�����
            $(".status").click(function () {
                var aryStatus = new Array();
                aryStatus[0] = "����";
                aryStatus[1] = "����";
                var status = $(this).attr("status");
                status = Math.abs(status - 1);
                var trObj = $(this).parents("tr");
                var _Obj = $(this);
                var uid = $(trObj).attr("uid");
                var pid = $(trObj).attr("pid");
                $.ajax({
                    type: "POST",
                    url: "../Handler/User.ashx",
                    data: { type: "status", uid: uid, pid: pid, status: status },
                    success: function (data) {
                        if (data == "1") {
                            $(_Obj).attr("status", status);
                            $(_Obj).text(aryStatus[status]);
                            alert("�����ɹ�");
                        } else {
                            alert("����ʧ��");
                        }
                    },
                    dataType: "text"
                });
            });

            //ɾ�������û�
            $(".del").click(function () {
                if (!confirm("ȷ��Ҫɾ����"))
                    return false;
                var trObj = $(this).parents("tr");
                var uid = $(trObj).attr("uid");
                var pid = $(trObj).attr("pid");
                $.ajax({
                    type: "POST",
                    url: "../Handler/User.ashx",
                    data: { type: "delete", uid: uid, pid: pid },
                    success: function (data) {
                        if (data == "-1") {
                            alert("���û��Ѽ�����ҵ���޷�ɾ����");
                        }
                        else if (data == "1") {
                            alert("ɾ���ɹ�");
                            window.location = window.location;
                        }
                        else {
                            alert("ɾ��ʧ��" + data);
                        }
                    },
                    dataType: "text"
                });
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    �����û��б�
                </th>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                �˺ţ�
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUserName" />
                            </td>
                            <td>
                                ������
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtRealName" />
                            </td>
                            <td>
                                ��ͨ���ڣ�
                            </td>
                            <td>
                                <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtStartDate"
                                    runat="server" />
                                <span>---</span>
                                <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtEndDate"
                                    runat="server" />
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
                    <table class="tablist" cellspacing="1" border="0" cellpadding="1">
                        <tr>
                            <th>
                                ���
                            </th>
                            <th>
                                ����
                            </th>
                            <th>
                                �˺�
                            </th>
                            <th>
                                �ֻ�
                            </th>
                            <th>
                                ����
                            </th>
                            <th>
                                ��ͨ����
                            </th>
                            <th>
                                ��������
                            </th>
                            <th>
                                ��ǰ��¼��
                            </th>
                            <th>
                                ����
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <tr class="c" uid="<%#Eval("UserID") %>" pid="<%#Eval("PersonalID") %>">
                                    <td>
                                        <%#Eval("nid") %>
                                    </td>
                                    <td>
                                        <a href="PersonalDetail.aspx?uid=<%#Eval("UserID") %>&pid=<%#Eval("PersonalID") %>">
                                            <%#Eval("RealName") %></a>
                                    </td>
                                    <td>
                                        <%#Eval("UserName") %>
                                    </td>
                                    <td>
                                        <%#Eval("Mobile") %>
                                    </td>
                                    <td>
                                        <%#Eval("Email") %>
                                    </td>
                                    <td>
                                        <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </td>
                                    <td>
                                        <%#Eval("ExpiredDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </td>
                                    <td>
                                        <%#Eval("ClientNum") %>
                                    </td>
                                    <td>
                                        <a href="#" class="status" status="<%#Eval("Status")%>"><%#Eval("Status").ToString().Equals("0")?"����":"����"%></a> 
                                        <a href="javascript:void(0);" class="del">ɾ��</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;"
                        AlwaysShow="true" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageSize="1"
                        PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
