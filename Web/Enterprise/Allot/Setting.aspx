<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="Web.Enterprise.Allot.Setting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录分配设置</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tabSetting ul
        {
            margin: 0 0 0 4px;
            padding: 0;
        }
        #tabSetting li
        {
            float: left;
            width: 10%;
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            名录分配设置</h3>
    </div>
    <div class="divlist">
        <table cellpadding="1" cellspacing="1" class="tablist" id="tabSetting">
            <tr>
                <th>
                    设置对象
                </th>
                <th>
                    负责范围
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr objid="<%#Eval("ObjID") %>">
                        <td class="c">
                            <%#Eval("ObjName") %>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div id="divPropertyBase" style="display: none;">
            <table cellpadding="1" cellspacing="1" class="tablist" style="width: 800px; margin: 3px auto 3px 3px;">
                <%if (TradeFlag)
                  { %>
                <tr>
                    <td class="c w50">
                        行业
                    </td>
                    <td>
                        <ul>
                            <asp:Repeater runat="server" ID="rpTradeList">
                                <ItemTemplate>
                                    <li>
                                        <input type="checkbox" name="cbTrade" value="<%#Eval("Value") %>" /><%#Eval("Text") %></li></ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </td>
                </tr>
                <%} if (AreaFlag)
                  { %>
                <tr>
                    <td class="c w50">
                        地区
                    </td>
                    <td>
                        <ul>
                            <asp:Repeater runat="server" ID="rpAreaList">
                                <ItemTemplate>
                                    <li>
                                        <input type="checkbox" name="cbArea" value="<%#Eval("Value") %>" /><%#Eval("Text")%></li></ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </td>
                </tr>
                <%} if (SourceFlag)
                  { %>
                <tr>
                    <td class="c w50">
                        来源
                    </td>
                    <td>
                        <ul>
                            <asp:Repeater runat="server" ID="rpSource">
                                <ItemTemplate>
                                    <li>
                                        <input type="checkbox" name="cbSource" value="<%#Eval("SourceID") %>" /><%#Eval("SourceName") %></li></ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </td>
                </tr>
                <%} %>
            </table>
        </div>
    </div>
    <div style="line-height: 180%; vertical-align: middle; margin: 10px auto 10px 30px;">
        <h3>
            补差分配设置</h3>
        每位销售人员待沟通名录数量（潜在客户数量+意向客户数量）上限：<asp:TextBox runat="server" ID="txtCILimit" MaxLength="4"
            CssClass="txt w60" />
        <p>
            <input type="button" id="btnSubmit" value="提交" class="btn" />
            <asp:HiddenField runat="server" ID="hdObj" />
            <asp:HiddenField runat="server" ID="hdTrade" />
            <asp:HiddenField runat="server" ID="hdArea" />
            <asp:HiddenField runat="server" ID="hdSource" />
        </p>
    </div>
    </form>
    <script type="text/javascript">
        var SETTING_CONFIG = {
            GET_URL: "/enterprise/handler/allot.ashx"
        };
        $(function () {
            //--------------初始化设置范围--------------------
            //divPropertyBase
            $("tr[objid]").each(function () {
                $("#divPropertyBase table").clone().appendTo($(this).find("td:eq(1)"));
            });
            var aryObj = new Array();
            var aryTrade = new Array();
            var aryArea = new Array();
            var arySource = new Array();
            aryObj = $("#hdObj").val().split("|");
            aryTrade = $("#hdTrade").val().split("|");
            aryArea = $("#hdArea").val().split("|");
            arySource = $("#hdSource").val().split("|");
            var objid;
            for (var i = 0; i < aryObj.length; i++) {
                objid = aryObj[i];
                var objTr = $("tr[objid='" + aryObj[i] + "']");
                var ary;
                if ($(objTr).is("tr")) {
                    //设置行业选中
                    ary = aryTrade[i].split(",");
                    for (var j = 0; j < ary.length; j++) {
                        $(objTr).find(":checkbox[name='cbTrade'][value='" + ary[j] + "']").attr("checked", true);
                    }
                    //设置地区选中
                    ary = aryArea[i].split(",");
                    for (var j = 0; j < ary.length; j++) {
                        $(objTr).find(":checkbox[name='cbArea'][value='" + ary[j] + "']").attr("checked", true);
                    }
                    //设置来源选中
                    ary = arySource[i].split(",");
                    for (var j = 0; j < ary.length; j++) {
                        $(objTr).find(":checkbox[name='cbSource'][value='" + ary[j] + "']").attr("checked", true);
                    }
                }
            }


            //------------设置选项的可选状态-------------------
            $("tr[objid] :checkbox").bind("click", function () {
                var name = $(this).attr("name");
                var checked = $(this).is(":checked");
                var val = $(this).val();
                $("#tabSetting :checkbox[name='" + name + "'][value='" + val + "']").not($(this)).each(function () {
                    if (checked) {
                        $(this).removeAttr("checked");
                        $(this).attr("disabled", "disabled");
                    } else {
                        $(this).removeAttr("disabled");
                    }
                });
            });
            $("tr[objid] :checked").each(function () {
                $(this).triggerHandler("click");
            });
            //---------------------保存配置------------------------
            $("#btnSubmit").click(function () {
                var limit = parseInt($("#txtCILimit").val());
                var aryObj = new Array(); //对象数据
                var aryTrade = new Array(); //行业
                var aryArea = new Array(); //地区
                var arySource = new Array(); //来源
                $("#tabSetting tr[objid]").each(function () {
                    aryObj.push($(this).attr("objid"));
                    var trade = new Array();
                    var area = new Array();
                    var source = new Array();
                    $(this).find(":checked").each(function () {
                        var name = $(this).attr("name");
                        if (name == "cbTrade") {
                            trade.push($(this).val());
                        }
                        else if (name == "cbArea") {
                            area.push($(this).val());
                        }
                        else if (name == "cbSource") {
                            source.push($(this).val());
                        }
                    });
                    aryTrade.push(trade);
                    aryArea.push(area);
                    arySource.push(source);
                });

                $("#hdObj").val(aryObj.join("|"));
                $("#hdTrade").val(aryTrade.join("|"));
                $("#hdArea").val(aryArea.join("|"));
                $("#hdSource").val(arySource.join("|"));

                var data = "key=setting&limit=" + limit + "&objid=" + aryObj.join("|") + "&trade=" + aryTrade.join("|") + "&area=" + aryArea.join("|") + "&source=" + arySource.join("|");

                $.get(SETTING_CONFIG.GET_URL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "提交成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "提交失败", false);
                    }
                }, "text");
            });

            //-------判断数字是否正确------------
            $("#txtCILimit").blur(function () {
                if (!$.IsInt($(this).val())) {
                    $(this).val(0);
                }
            });
        });
    </script>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=31" type="text/javascript"></script>
</body>
</html>
