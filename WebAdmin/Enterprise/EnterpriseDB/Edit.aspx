<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebAdmin.Enterprise.EnterpriseDB.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业数据库信息</title>
    <link href="/images/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //验证信息
            $("#txtMaxNum").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入数据</span>";
                }
                else if (!$.IsInt(v)) {
                    msg = "<span class='error'>请输入正确的数据</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsMaxNum").html(msg);
            });

            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="98%" class="tableBorder">
			<tr>
				<th  colspan="3" class="bigTitle">企业数据库信息</th>
			</tr>
            <tr>
                <td class="title">
                    数据库名：
                </td>
                <td  style="width:150px;">
                    <asp:TextBox runat="server" ID="txtDBName" ReadOnly="true" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="title">
                    最大数量：
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtMaxNum" Text="100" />
                </td>
                <td id="TipsMaxNum">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnSubmit" Text="提交" OnClick="btnSubmit_Click" />
                    <input type ="button" value ="返回" onclick="window.location.replace('List.aspx');" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
