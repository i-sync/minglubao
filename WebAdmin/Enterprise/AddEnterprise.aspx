<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEnterprise.aspx.cs"
    Inherits="WebAdmin.Enterprise.AddEnterprise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>������ҵ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".Wdate").focus(function () { WdatePicker(); });
            //��ҵ����֤
            $("#txtEPCode").blur(function () {
                var v = $.trim($(this).val());
                if (v.length==0) {
                    $("#codeTips").text("");
                    return;
                }
                $("#codeTips").text("��֤��");
                var data = "key=100&code=" + escape(v) + "&t=" + Math.random();
                $.get("Handler.ashx", data, function (res) {
                    if (res == "1") {//�Ѿ�����
                        $("#codeTips").text("�Ѿ�����");
                    } else {
                        $("#codeTips").text("����ʹ��");
                    }
                }, "text");
            });

            $("form").submit(function () {
                if ($.IsNullOrEmpty($("#txtEPCode").val())) { alert("��������ҵ��"); $("#txtEPCode").focus(); return false; }
                if ($.IsNullOrEmpty($("#txtEPName").val())) { alert("��������ҵ����"); $("#txtEPName").focus(); return false; }
                if ($.IsNullOrEmpty($("#txtItemName").val())) { alert("��������Ŀ����"); $("#txtItemName").focus(); return false; }
                //if ($.IsNullOrEmpty($("#txtLinkman").val())) { alert("��������ϵ��"); $("#txtLinkman").focus(); return false; }
                //if ($.IsNullOrEmpty($("#txtPosition").val())) { alert("��������ϵ��ְ��"); $("#txtPosition").focus(); return false; }
                //if ($.IsNullOrEmpty($("#txtTel").val())) { alert("������绰����"); $("#txtTel").focus(); return false; }
                //if (!$.IsTel($("#txtTel").val())) { alert("��������ȷ�ĵ绰����"); $("#txtTel").focus(); return false; }
                //if (!$.IsEmail($("#txtEmail").val())) { alert("��������ȷ������"); $("#txtEmail").focus(); return false; }
                //if (!$.IsNullOrEmpty($("#txtMobile").val()) && !$.IsMobile($("#txtMobile").val())) { alert("��������ȷ���ֻ�����"); $("#txtMobile").focus(); return false; }
                if (!$.IsInt($("#txtUserAmount").val())) { alert("��������ȷ�Ĺ����û�����"); $("#txtUserAmount").focus(); return false; }
                if (!$.IsDate($("#txtStartDate").val())) { alert("��ѡ��ʼ����"); $("#txtStartDate").focus(); return false; }
                if (!$.IsDate($("#txtEndDate").val())) { alert("��ѡ���ֹ����"); $("#txtEndDate").focus(); return false; }
                if (!$.CompareDate($("#txtStartDate").val(), $("#txtEndDate").val())) {
                    alert("��ʼ���ڲ��ܴ��ڵ��ڽ�ֹ����");
                    return false;
                }
                if ($.IsNullOrEmpty($("#txtAdminUserName").val())) { alert("���������Ա�ʺ�"); $("#txtAdminUserName").focus(); return false; }
                
                return true;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="98%" class="tableBorder">
			<tr>
				<th  colspan="4" class="bigTitle">��ҵ��Ϣ</th>
			</tr>
            <tr>                
                <asp:Literal ID="ltTips" runat="server"></asp:Literal>                
            </tr>
            <tr>
                <td class="title">
                    ��ҵ�ţ�
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEPCode" />
                </td>
                <td  colspan="2" id="codeTips"></td>
            </tr>
            <tr>
                <td class="title">
                    ��ҵ���ƣ�
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtEPName" Width="400" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    ��Ŀ���ƣ�
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtItemName"  Width="400" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    ��ϵ�ˣ�
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLinkman" />
                </td>
                <td class="title">
                    ��ϵ��ְ��
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPosition" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    �绰��
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTel" />
                </td>
                <td class="title">
                    ���䣺
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    �ֻ���
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobile" />
                </td>
                <td class="title">
                    ���棺
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFax" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    ��ַ��
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtAddress" Width="400" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    �����û�������
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserAmount" />
                </td>
                <td class="title">
                    ��Ч�ڣ�
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="Wdate" />
                    ��
                    <asp:TextBox runat="server" ID="txtEndDate" CssClass="Wdate" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    ����Ա�ʺţ�
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtAdminUserName" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    ����Ա���룺
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtAdminPassword" MaxLength="30" />
                    <span>(���볤��Ϊ4-30)</span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="3">
                    <asp:Button runat="server" ID="btnSubmit" Text="�ύ" OnClick="btnSubmit_Click" />
                    <input type ="button" value ="����" onclick="window.location.replace('List.aspx');" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
