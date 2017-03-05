<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Navigator.aspx.cs" Inherits="Web.Enterprise.Navigator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            /*
            //-----------选择角色-----------
            $("#curRole").click(function () {
                $(document.body).bind("click", function () {
                    $("#roleInfo").hide();
                    $(document.body).unbind("click");
                    return false;
                });
                $("#roleInfo").show();
                return false;
            });

            //切换角色
            $("#roleInfo .item").click(function () {
                var teamid = $(this).attr("teamid");
                var epuid = $(this).attr("epuid");
                var roleid = $(this).attr("roleid");
                if (teamid != undefined && epuid != undefined && roleid != undefined) {
                    $(window).unbind("beforeunload").unbind("unload");
                    //location = "selectrole.aspx?teamid=" + teamid + "&epuid=" + epuid + "&roleid=" + roleid;
                    //window.open("selectrole.aspx?teamid=" + teamid + "&epuid=" + epuid + "&roleid=" + roleid, "_parent");
                    window.open("selectrole.aspx", "_parent");
                }
                return false;
            });
            */
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="neirongbufen fl" style="width:100%; *width:100%; overflow: hidden;" id="divMain">
                <div class="gongsimingcheng">
                    <div class="fl">
                        <span class="fuzeren">公司名称：<asp:Literal ID="epName" Text="" runat="server"></asp:Literal></span>
                        <span class="fuzeren">项目名称：<asp:Literal ID="epItemName" Text="" runat="server"></asp:Literal></span>
                        <span class="fuzeren">负责人：<asp:Literal ID="epLinkman" Text="" runat="server"></asp:Literal></span>
                        <span class="fuzeren">公司电话：<asp:Literal ID="epTel" Text="" runat="server"></asp:Literal></span>
                    </div>
                    <div class="fr" id="curRole" style="color: red;">
                        身份切换：
                        <asp:HyperLink ID="hlRole" runat="server" ForeColor="Red" Target="_parent"></asp:HyperLink>
                    </div>
                    <!--
                    <div id="roleInfo">
                        <div class="cur">
                            <span class="rolename">
                                <asp:Literal ID="ltCurRole" Text="总监" runat="server"></asp:Literal></span> <span
                                    class="rolename">
                                    <asp:Literal ID="ltCurTeam" Text="项目总监" runat="server"></asp:Literal></span>
                        </div>
                        <asp:Repeater ID="rpRole" runat="server">
                            <ItemTemplate>
                                <div class="item" epuid="<%#Eval("EPUserTMRID")%>" teamid="<%#Eval("TeamID") %>"
                                    roleid="<%#Eval("roleid") %>">
                                    <span class="rolename">
                                        <%#Eval("RoleName") %></span> <span class="rolename">
                                            <%#Eval("TeamName") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    -->
                </div>
                
            </div>
    </div>
    </form>
</body>
</html>
