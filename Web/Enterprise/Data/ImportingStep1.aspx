<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportingStep1.aspx.cs"
    Inherits="Web.Enterprise.Data.ImportingStep1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录导入第一步</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
</head>
<body>
    <div class="nav">
        <h3>
            名录导入</h3>
    </div>
    <form id="form1" runat="server">
    <div class="divlist">
        <div class="step4 step4one">
            <div class="cur">
                1.上传文件</div>
            <div>
                2.映射字段</div>
            <div>
                3.调整数据</div>
            <div>
                4.确认导入</div>
            <i class="clear"></i>
        </div>
        <div class="comtip" style="margin: 20px 0 0 40px;">
            <span class="name">导入提示</span>
            <ul>
                <li>一次最多可导入1000条记录，超过部分将被忽略。</li>
                <li>上传文件的第一行将视为列名。</li>
                <li>需要设置名录属性时，请在Excel文件中增加三列并设置相应的属性编码。</li>
            </ul>
        </div>
        <div>
            <table>
                <tr style=" line-height:180%;">
                    <td valign="top">
                        选择文件：
                    </td>
                    <td>
                        <mlb:FileUpload runat="server" ID="FileUpload1" />
                    </td>
                </tr>
                <tr><td>&nbsp;</td><td>
                <asp:Button runat="server" ID="btnNext" Text="上传，下一步" CssClass="btn1" 
                        OnClick="btnNext_Click" />
                </td></tr>
            </table>
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=55" type="text/javascript"></script>
</body>
</html>
