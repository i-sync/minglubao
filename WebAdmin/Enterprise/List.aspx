<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebAdmin.Enterprise.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�����û��б�</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <link href="../My97DatePicker/skin/WdatePicker.css" type="text/css" rel="Stylesheet" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //���á�����
            $(".status").click(function () {
                var aryStatus = new Array();
                aryStatus[0] = "����";
                aryStatus[1] = "����";
                var status = $(this).attr("status");
                status = Math.abs(status - 1);
                var trObj = $(this).parents("tr");
                var _Obj = $(this);
                var eid = $(trObj).attr("eid");
                $.ajax({
                    type: "GET",
                    url: "Handler.ashx",
                    data: { key: "status", eid: eid, status: status },
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

            //ɾ����ҵ�û�
            $(".del").click(function () {
                if (!confirm("ȷ��Ҫɾ����"))
                    return false;
                var trObj = $(this).parents("tr");
                var eid = $(trObj).attr("eid");
                alert(eid);
                $.ajax({
                    type: "GET",
                    url: "Handler.ashx",
                    data: { key: "delete", eid: eid },
                    success: function (data) {
                        if (data == "1") {
                            alert("ɾ���ɹ�");
                            reload();
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
    <table class="tableBorder" width="98%"  border="0"
        align="center">
        <tr>
            <th class="bigTitle">
                ��ҵ�û��б�
            </th>
        </tr>
        <tr>
            <td>
                <table style="text-align: center">
                    <tr>
                        <td>
                            ��ҵ���ƣ�
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEnterpriseNames" />
                        </td>
                        <td>
                            �������ڣ�
                        </td>
                        <td>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtStartDate"
                                runat="server" />
                            <span>---</span>
                            <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtEndDate"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            ��������Ϊ<asp:TextBox runat="server" ID="txtDay" Width="30" />
                            ���ڣ�Ϊ������ҵ ��
                        </td>
                        <td colspan="2">
                            <asp:Button runat="server" ID="btnSearch" Text="����" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tablist" cellspacing="1" cellpadding="1">
                    <tr align="center" style="color: White; background-color: #DADAE9; font-weight: bold;">
                        <th>
                            ���
                        </th>
                        <th>
                            ��ҵ����
                        </th>
                        <th>
                            ��ҵ��
                        </th>
                        <th>
                            ��ͨ����
                        </th>
                        <th>
                            ��������
                        </th>
                        <th style="width:80px;">
                            �����û�����
                        </th>
                        <th style="width:80px;">
                            ��ǰ�û�����
                        </th>
                        <th style="width:80px;">
                            ��¼����
                        </th>
                        <th>
                            ״̬
                        </th>
                        <th>
                            ����
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                            <tr eid="<%#Eval("EnterpriseID") %>" class="c<%#MLMGC.COMP.Data.GetWarning(Convert.ToDateTime(Eval("ExpireDate")),day) %>">
                                <td>
                                    <%#Eval("nid") %>
                                </td>
                                <td>
                                    <%#Eval("EnterpriseNames") %>
                                </td>
                                <td>
                                    <%#Eval("EnterpriseCode") %>
                                </td>
                                <td>
                                    <%#Eval("StartDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%#Eval("ExpireDate", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <%#Eval("UserAmount") %>
                                </td>
                                <td>
                                    <%#Eval("UserNum") %>
                                </td>
                                <td>
                                    <%#Eval("ClientNum") %>
                                </td>
                                <td>
                                    <%#Status(Eval ("ExpireDate")) %>
                                </td>
                                <td>
                                    <a href="#" class="status" status="<%#Eval("Status")%>"><%#Eval("Status").ToString().Equals("0")?"����":"����"%></a> 
                                    <a href="AddEnterprise.aspx?type=update&eid=<%#Eval("EnterpriseID") %>">�޸�</a>
                                    <a href="javascript:void(0);" class="del">ɾ��</a>
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
