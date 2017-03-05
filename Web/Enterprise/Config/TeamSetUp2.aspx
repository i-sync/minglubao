<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamSetUp2.aspx.cs" Inherits="Web.Enterprise.Config.TeamSetUp2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置团队关系</title>
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/core.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/popup_layer.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var URL_CONFIG = {
            Post_URL: "/enterprise/ephandler.ashx"
        };
        var pl;
        var team
        $(function () {
            pl = new PopupLayer({ title: "团队设置", popupBlk: "#divInfo", useOverlay: "true" });
            $(".update").click(function () {
                var pObj = $(this).parents("tr");
                var teamid = $(pObj).attr("TeamID");
                var teamname = $.trim($(pObj).find(".teamname").text());
                var pid = $(pObj).attr("pid");
                //判断修改类型：修改团队名称，修改团队上级
                var type = $(this).attr("type");
                if (type == "name") {
                    $("#trName").show();
                    $("#trLeader").hide();
                }
                else {
                    $("#trName").hide();
                    $("#trLeader").show();
                }
                $("#divInfo").attr("TeamID", teamid);
                $.get(URL_CONFIG.Post_URL + "?key=101&teamid=" + teamid, null, function (data) {
                    var str = "";
                    for (var i = 0; i < data.length; i++) {
                        str = str + "<option value='" + data[i].value + "'>" + data[i].text + "</option>";
                    }

                    $("#txtTeamName").val(teamname);
                    $("#ddlParent").html(str);
                    setTimeout(function () { $("#ddlParent").val(pid); }, 1);
                    pl.Show();
                }, "json");
            });
            $("#btnUpdate").click(function () {
                var teamid = $("#divInfo").attr("TeamID");
                var teamname = $("#txtTeamName").val();
                var pid = $("#ddlParent").val();
                var pObj = $("tr[teamid='" + teamid + "']");
                var data = "key=102&teamid=" + teamid + "&teamname=" + escape(teamname) + "&pid=" + pid + "&t=" + Math.random();
                $.get(URL_CONFIG.Post_URL, data, function (msg) {
                    if (msg == "1") {
                        //显示
                        PopTip.Show(PopTip.Type.Succ, "修改成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "修改失败", false);
                    }
                    $("#divInfo").removeAttr("TeamID");
                    $("#txtTeamName").val("");
                    $("#ddlParent").html("");
                    pl.PopClose();
                }, "text");
            });

            //预览团队结构
            $("#btnPreview").click(function () {
                location.href = "/enterprise/teammap.aspx";
            });

            $("#btnCancel").click(function () { pl.PopClose(); });
            if ($("a.noparent").length > 0) {
                $("#btnPreview").hide();
            }
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="nav">
            <h3>
                设置团队关系</h3>
        </div>
        <div class="divlist">
            <div class="tmsubase tmsus3">
                <ul>
                    <li>1.<a href="teammodelsetup.aspx">选择团队模型</a></li>
                    <li>2.<a href="teamsetup1.aspx">设置团队规模</a></li>
                    <li  class="cur">3.设置团队关系</li>
                </ul>
            </div>
            <div style="font-size: 14px;">
                <table cellpadding="1" cellspacing="1" border="0" class="tablist w500">
                    <tr>
                        <th>
                            部门名称
                        </th>
                        <th>
                            上级部门
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                            <tr class="c" teamid="<%#Eval("TeamID") %>" pid="<%#Eval("PID") %>">
                                <td>
                                    <span class="teamname">
                                        <%#Eval("TeamName") %></span> <a href="javascript:void(0)" class="update" type="name">
                                            (修改名称)</a>
                                </td>
                                <td class="pname">
                                    <%#Eval("PName").ToString().Equals("") ? (Eval("PID").ToString().Equals("0") ? "——" : "") : Eval("PName")%><%#Eval("Depth").ToString().Equals("2")?"<a href='javascript:void(0);' class='update' type=\"leader\">(指定上级)</a>":"&nbsp;" %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div style="width: 380px; height: 120px; border: 1px solid #ccc; background: white;
                display: none;" id="divInfo">
                <table class="tabtxtlist mar10">
                    <tr id="trName">
                        <td class="name" align="right">
                            团队名称：
                        </td>
                        <td>
                            <input type="text" id="txtTeamName" name="txtTeamName" class="txt" />
                        </td>
                    </tr>
                    <tr id="trLeader">
                        <td class="name" align="right">
                            上级：
                        </td>
                        <td>
                            <select id="ddlParent" name="ddlParent" style="width: 150px;" class="ddl">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input type="button" id="btnUpdate" value="确定" class="btn" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" id="btnCancel" value="取消" class="btn" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class=" w500" style=" text-align:right; margin-top:10px;">
                <input id="btnPreview" type="button" class="btn" value="查看团队结构" />
            </div>
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=1" type="text/javascript"></script>
</body>
</html>
