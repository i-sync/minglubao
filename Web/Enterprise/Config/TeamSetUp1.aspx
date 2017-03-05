<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamSetUp1.aspx.cs" Inherits="Web.Enterprise.Config.TeamSetUp1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/core.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="nav">
            <h3>
                团队规模设置</h3>
        </div>
        <div class="divlist">
            <div class="tmsubase tmsus2">
                <ul>
                    <li>1.<a href="teammodelsetup.aspx">选择团队模型</a></li>
                    <li class="cur">2.设置团队规模</li>
                    <li>3.设置关系</li>
                </ul>
            </div>
            <div>
                <p style="display: inline">
                    购买用户数量:<asp:Literal runat="server" ID="ltUserAmount" Text="0" /></p>
            </div>
            <div class="mar10 clientInfo">
                <asp:Literal runat="server" ID="LtSetting" />
            </div>
            <div class="mar10 w500" style=" text-align:right;">
                <asp:Button runat="server" ID="btnSubmit" Text="下一步" OnClick="btnSubmit_Click" CssClass="btn" />
            </div>
             <div class=" mar10 note">
            <span>注意：</span>需要删除团队时，请先清空需要删除的团队中的数据。数据包括：<b>待分配名录</b>、<b>潜在客户</b>、<b>意向客户</b>、<b>成交客户</b>、<b>失败客户</b>、<b>报废客户</b>、<b>业务人员</b>等信息。
            </div>
        </div>
    </div>
    <!--预览窗口-->
    <div id="divPreview" style="display: none; width: 700px; height: 500px; overflow: auto;
        background-color: White; padding: 0px">
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=1" type="text/javascript"></script>
</body>
</html>
