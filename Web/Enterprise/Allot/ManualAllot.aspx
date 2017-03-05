<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManualAllot.aspx.cs" Inherits="Web.Enterprise.Allot.ManualAllot" %>

<%@ Register Src="~/Enterprise/Controls/Property.ascx" TagName="Property" TagPrefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>手动分配名录</title>
    <script type="text/javascript" src="../../JS/jquery-1.6.4.js"></script>
    <script type="text/javascript" src="../../JS/common.js"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script src="../../JS/popup_layer.js" type="text/javascript"></script>
    <link type="text/css" rel="Stylesheet" href="../../Styles/Site.css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href="../../JS/My97DatePicker/skin/WdatePicker.css" />
    <link href="../../Styles/core.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var aryIds = Array();
        var URL_CONFIG = {
            ListUrl: "ManualList.aspx",
            ResultUrl: "ManualResult.aspx",
            Allot_URL: "/enterprise/handler/allot.ashx", //手工分配url
            Post_URL: "/Enterprise/Handler/Operate.ashx" //------共享提交地址
        };
        var pl;
        function showList(url) {
            url = url + "&t=" + Math.random();

            $("#divResult").load(url + "&t="+Math.random(), function () {
                //--加载显示列表
                if (aryIds.length > 0) {
                    $("#divResult :checkbox[name='cbClient']").each(function () {
                        var val = $(this).val();
                        var i = JS_cruel_search(aryIds, val);
                        if (i > -1) {
                            $(this).attr("checked", "checked");
                        }
                    });
                }
            });
        }

        ///----------显示已选择的名录----------
        function showClientInfo(url) {
            $("#divclientinfo").load(url + "#list");
        }
        //---显示选中数量
        function showAmount() {
            $("#selectAmount").text(aryIds.length);
        }
        $(function () {
            pl = new PopupLayer({ title: "已选择名录", popupBlk: "#divclientinfo", useOverlay: "true" });
            //---检索
            $("#btnSearch").click(function () {
                var name = $("#txtName").val();
                var startdate = $("#txtStartDate").val();
                var enddate = $("#txtEndDate").val();
                var data = "name=" + name + "&startdate=" + startdate + "&enddate=" + enddate + Property.GetQuery();
                showList(URL_CONFIG.ListUrl + "?" + data);
            });
            //--加载列表
            $("#btnSearch").triggerHandler("click");
            //---------------列表开始------------------------
            //--全选
            $("#divResult :checkbox[name='cbAll']").live("click", function () {
                var checked = $(this).is(":checked");
                $("#divResult :checkbox[name='cbClient']").each(function () {
                    var val = $(this).val();
                    if (checked) {
                        $(this).attr("checked", checked);
                        aryIds.push(val);
                    }
                    else {
                        $(this).removeAttr("checked");
                        aryIds.del(val);
                    }
                });
                showAmount();
            });
            //--选中/取消
            $("#divResult :checkbox[name='cbClient']").live("click", function () {
                var checked = $(this).is(":checked");
                var val = $(this).val();
                if (checked) {
                    aryIds.push(val);
                }
                else {
                    aryIds.del(val);
                }
                var objList = $("#divResult :checkbox[name='cbClient']");
                $("#divResult :checkbox[name='cbAll']").attr("checked", ($(objList).length == $(objList).filter(":checked").length));
                showAmount();
            });
            //---------重写分页
            $("#divResult .paginator a").live("click", function () {
                showList($(this).attr("href"));
                return false;
            });
            //------------------列表结束----------------------
            //共享
            $("#btnSharePool").click(function () {
                if (aryIds.length > 0 && confirm("确认要共享吗？")) {                    
                    var data = "act=share&ids=" + aryIds;
                    $.post(URL_CONFIG.Post_URL, data, function (data) {
                        if (data == "1") {
                            PopTip.Show(PopTip.Type.Succ, "共享成功", true);
                            reload();
                        }
                        else {
                            PopTip.Show(PopTip.Type.Error, "共享失败", false);
                        }

                    }, "text");
                }
            });
            //查看已选择的名录
            $(".result").click(function () {
                if (aryIds.length > 0) {
                    var data = "ids=" + aryIds.join(",");
                    showClientInfo(URL_CONFIG.ResultUrl + "?" + data);
                    $("#divclientinfo").show();
                    pl.Show();
                }
            });
            //弹出窗口已选择名录 删除选择名录
            $(".showdel").live("click", function () {
                var ciid = $(this).attr("ciid");
                aryIds.del(ciid);
                $("#divResult :checked[value='" + ciid + "']").removeAttr("checked");
                $(this).parent().parent().remove();
                $("#lblCount").text(parseInt($("#lblCount").text()) - 1);
                showAmount();

                //判断当前是否还有名录，若没有则隐藏div
                if (parseInt($("#lblCount").text()) == 0) {
                    pl.PopClose();
                    $("#divclientinfo").hide();
                }
            });
            //--------------分配对象-------------------
            $(":checkbox[name='cbObj']").click(function () {
                if ($(":checked[name='cbObj']").length > 1) {
                    $(".cbType").each(function () {
                        $(this).removeAttr("disabled");
                    });
                    $("#cbTypeSpecified").removeAttr("checked").attr("disabled", "disabled");
                    $(".cbType:eq(0)").attr("checked", true);
                }
                else {
                    $(".cbType").each(function () {
                        $(this).attr("disabled", "disabled");
                    });
                    $("#cbTypeSpecified").removeAttr("disabled").attr("checked", true);
                }
            });
            //------------分配名录提交--------------------
            $("#btnSubmit").click(function () {
                if (aryIds.length == 0) {
                    //alert("请先选择名录");
                    PopTip.Show(PopTip.Type.Tips, "请先选择名录", false);
                    return false;
                }
                var aryObj = Array();
                $(":checked[name='cbObj']").each(function () {
                    aryObj.push($(this).val());
                });
                if (aryObj.length == 0) {
                    //alert("请选择分配对象");
                    PopTip.Show(PopTip.Type.Tips, "请选择分配对象", false);
                    return false;
                }
                if ($(":checked[name='cbType']").length != 1) {
                    //alert("请选择分配方式");
                    PopTip.Show(PopTip.Type.Tips, "请选择分配方式", false);
                    return false;
                }
                var type = $(":checked[name='cbType']").val();
                var data = "key=manual&objids=" + aryObj + "&type=" + type + "&ids=" + aryIds;
                $.get(URL_CONFIG.Allot_URL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "分配成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Tips, "分配失败", false);
                    }
                }, "text");
            });

            $.Hover(".tablist .c");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            手动分配名录</h3>
    </div>
    <div class="divlist" style=" margin:10px; line-height:180%;">
        <table>
            <tr>
                <td>
                    名录名称：
                </td>
                <td>
                    <input type="text" id="txtName" class="txt1 w300" />
                </td>
                <td>
                    入库时间：
                </td>
                <td>
                    <input type="text" id="txtStartDate" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" />
                    <span>---</span>
                    <input type="text" id="txtEndDate" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <mlb:Property ID="Property1" runat="server" />
                </td>
                <td colspan="2">
                    <input type="button" id="btnSearch" value="检索" class="btn1"/>
                </td>
            </tr>
        </table>
        <!--分页结果显示 开始-->
        <div id="divResult" style="font-size:12px;">
        </div>
        <!--分页结果显示 结束-->
        <p>
            <input type="button" id="btnSharePool" value="放入共享池" class="btn1" />
            <input type="button" id="btnManualAllot" value="手动分配" class="btn1"/>
        </p>
        <p>
            共选中<span id="selectAmount">0</span>个名录.<a href="#" class="result">查看已选择的名录</a></p>
        <div id="divManual">
            <table>
                <tr>
                    <td>
                        <span>第二步选择对象：</span>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Repeater ID="rpList" runat="server">
                            <ItemTemplate>
                                <input type="checkbox" name="cbObj" id="cbObj<%#Eval("ObjID") %>" value="<%#Eval("ObjID")%>" /><label
                                    for="cbObj<%#Eval("ObjID") %>"><%#Eval("ObjName") %></label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>第三步选择分配方式：</span>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="radio" name="cbType" id="cbTypeSpecified" value="specified" checked="checked" /><label
                            for="cbTypeSpecified">指定分配</label>
                        <input type="radio" name="cbType" class="cbType" id="cbTypeAvg" value="avg" disabled="disabled" /><label
                            for="cbTypeAvg">平均分配</label>
                        <%if (SettingFlag)
                          { %><input type="radio" name="cbType" class="cbType" id="cbTypeMakeup" value="makeup" disabled="disabled" /><label
                              for="cbTypeMakeup">补差分配</label><%} %>
                        <%if (SettingFlag && TradeFlag)
                          { %><input type="radio" name="cbType" class="cbType" id="cbTypeTrade" value="trade" disabled="disabled" /><label
                              for="cbTypeTrade">按行业</label><%} %>
                        <%if (SettingFlag && AreaFlag)
                          { %><input type="radio" name="cbType" class="cbType" id="cbTypeArea" value="area" disabled="disabled" /><label
                              for="cbTypeArea">按地区</label><%} %>
                        <%if (SettingFlag && SourceFlag)
                          { %><input type="radio" name="cbType" class="cbType" id="cbTypeSource" value="source" disabled="disabled" /><label
                              for="cbTypeSource">按来源</label><%} %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="button" id="btnSubmit" value="确定" class="btn1"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!--查看已选择名录-->
    <div id="divclientinfo" style="display:none;background-color:White; width:400px; height:500px; border:1px solid #468ed0;">
        
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=32" type="text/javascript"></script>
</body>
</html>
