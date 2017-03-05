<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="WebAdmin.WenKu.Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder" width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    <b>文库详细内容: </b>
                </th>
            </tr>
            <tr>
                <td>
                    <div>
                        <table>
                            <tr>
                                <td colspan ="2">
                                    标&nbsp;&nbsp;题：<asp:Label ID="lblCaption" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2">
                                    简&nbsp;&nbsp;介：<asp:Label ID="lblIntro" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    关键字：<asp:Label ID="lblKeyword" runat="server"></asp:Label>                
                                </td>
                                <td style="width:100px;">
                                    大&nbsp;&nbsp;小：<asp:Label ID="lblSize" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2">
                                    <div style="height:700px;width:700px;">
                                        <embed style="width:100%;height:100%;" align="middle" id="flashContainer" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" name="reader" src="<%=FlashUrl %>" ></embed>
                                    </div>
                                    <br />
                                </td>                
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            
        </table>
    </form>
</body>
</html>
