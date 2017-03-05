<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRole.aspx.cs" Inherits="Web.Enterprise.SelectRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择角色</title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //设置宽
            $("#divList").width($("#divList .roleInfoimg").length * 198);
            $(".roleInfoimg").click(function () {
                var teamid = $(this).attr("teamid");
                var epuid = $(this).attr("epuid");
                var kid = $(this).attr("kid");
                if (teamid != undefined && epuid != undefined) {
                    location = "selectrole.aspx?teamid=" + teamid + "&epuid=" + epuid + "&roleid=" + kid;
                }
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dbline">
    </div>
    <div style="width: 940px; height: 320px; margin: auto; text-align: center;" id="divList">
        <asp:Repeater runat="server" ID="rpList">
            <ItemTemplate>
                <div class="roleInfoimg" epuid="<%#Eval("EPUserTMRID")%>" teamid="<%#Eval("TeamID") %>" kid="<%#Eval("RoleID") %>">
                    <div class="perople">
                    </div>
                    <div class="rolename">
                        <%#Eval("RoleName") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="dbline">
    </div>
    </form>
</body>
</html>
