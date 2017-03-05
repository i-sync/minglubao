<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="WebAdmin.Enterprise.Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业基本信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script type ="text/javascript" src ="../js/jquery-1.6.4.js"></script>
    <script type ="text/javascript" src ="../js/common.js"></script>
    <link rel="stylesheet" href="../images/main.css" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("tr").find("td:even").addClass("title");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
        <table align="center" width="98%" class="tableBorder">
            <tr>
                <th class="bigTitle" colspan="4">
                    企业基本信息
                </th>
            </tr>
            <tr>
                <td>
                    企业名称：
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtEnterpriseNames" Enabled="false" TabIndex="1"/>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr> 
             <tr>
                <td>
                    联系人：
                </td>
                <td style="width:200px">
                    <asp:TextBox runat="server" ID="txtLinkman" Enabled="false" TabIndex="2"/>
                </td>
                <td>
                    联系人职位：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPosition" Enabled="false" TabIndex="3" />
                </td>
            </tr>          
            <tr>
                <td>
                    电话：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTel" Enabled="false" TabIndex="2"/>
                </td>
                <td>
                    E-Mail：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" Enabled="false" TabIndex="3" />
                </td>
            </tr>
            <tr>               
                <td>
                    手机：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobile" Enabled="false" TabIndex="4"/>
                </td>
                <td>
                    传真：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFax" Enabled="false" TabIndex="5"/>
                </td>
            </tr>
            
             <tr>
                <td>
                    地址：
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtAddress" Enabled="false" TabIndex="6"/>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    购买用户数量：
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtUserAmount" Enabled="false" TabIndex="7"/>
                </td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>               
                <td>
                    有效日期：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtStartDate" Enabled="false" TabIndex="4"/>
               
                    至
                
                    <asp:TextBox runat="server" ID="txtExpireDate" Enabled="false" TabIndex="5"/>
                </td>
            </tr>
            <tr>               
                <td>
                    当前用户数量：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserNum" Enabled="false" TabIndex="4"/>
                </td>
                <td>
                    当前名录数量：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtClientNum" Enabled="false" TabIndex="5"/>
                </td>
            </tr>
            <tr>
                <td>
                    系统管理员账号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserName" Enabled="false" TabIndex="8" />
                </td>   
                <td colspan="2">&nbsp;</td>            
            </tr>
            <tr>
                <td>
                    系统管理员密码：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" Enabled="false" TabIndex="9"/>
                </td> 
                <td colspan="2">&nbsp;</td>              
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3"><a href="List.aspx">返回</a></td>
            </tr>
        </table>
        
    
    </form>
</body>

</html>
