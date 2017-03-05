<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoAllot.aspx.cs" Inherits="Web.Enterprise.Allot.AutoAllot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>自动分配</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript">
        var CONFIG = {
            URL: "/enterprise/handler/allot.ashx"
        };
        $(function () {
            //验证数据
            $("#txtAllotAmount").blur(function () {
                if (!$.IsInt($(this).val())) {
                    $(this).val(1);
                }
                /*
                var v = parseInt($(this).val());
                var max = parseInt($(this).attr("maxNum"));
                if (v > max || v < 1) {
                $(this).val(max);
                }*/
            });

            $("#txtDay").blur(function () {
                if (!$.IsInt($(this).val())) {
                    $(this).val(1);
                }
                var v = parseInt($(this).val());
                if (v > 200 || v < 1) {
                    $(this).val(200);
                }
            });
            //验证小时
            $("#txtHour").blur(function () {
                var v = $(this).val();
                if (!$.IsInt(v)) {
                    $(this).val("00");
                }
                var v = parseInt(v);
                if (v > 23 || v < 0) {
                    $(this).val("23");
                }
            });
            //验证分钟
            $("#txtMinute").blur(function () {
                var v = $(this).val();
                if (!$.IsInt(v)) {
                    $(this).val("00");
                }
                var v = parseInt($(this).val());
                if (v > 59 || v < 0) {
                    $(this).val("59");
                }
            });


            //提交配置信息验证
            $("#txtDay").click(function () {
                $("#txtAllotAmount").triggerHandler("blur");
                $("#txtDay").triggerHandler("blur");
            });

            //提交
            $("#btnSubmit").click(function () {
                var num = $("#txtAllotAmount").val();
                //判断分配数量是否大于零
                if (parseInt(num) <= 0)
                    return;
                var orderby = $(":checked[name='rdOrderby']").val();
                var type = $(":checked[name='cbType']").val();
                var data = "key=auto&num=" + num + "&orderby=" + orderby + "&type=" + type;
                $.get(CONFIG.URL, data, function (data) {
                    if (data.toString() == "succ") {
                        PopTip.Show(PopTip.Type.Succ, "分配成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "分配失败", false);
                    }
                }, "text");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            自动分配名录计划</h3>
    </div>
    <div class="divlist" style="margin: 20px 0 20px 40px; line-height: 220%; font-size: 14px;">
        <table>
            <tr>
                <td class="name">
                    状态：
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblEnabledState" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">启用</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">禁用</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="name">
                    当前待分配名录数量：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltSumAmount" Text="0" />
                </td>
            </tr>
            <tr>
                <td class="name">
                    每次分配名录数量：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAllotAmount" CssClass="txt w50" MaxLength="4" />&nbsp;&nbsp;<span>(大于0的整数)</span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    分配顺序：
                </td>
                <td>
                    <input type="radio" name="rdOrderby" value="asc" id="rdOrderbyAsc" checked="true" runat ="server" />
                    <label for="rdOrderbyAsc">
                        按名录入库顺序分配</label>
                    <input type="radio" name="rdOrderby" value="desc" id="rdOrderbyDesc" runat="server" />
                    <label for="rdOrderbyDesc">
                        优先分配新入库名录</label>
                </td>
            </tr>
            <tr>
                <td class="name">
                    分配方式：
                </td>
                <td>
                    <input type="radio" name="cbType" id="cbTypeAvg" value="2" checked="true" runat="server" /><label for="cbTypeAvg">平均分配</label>
                    <%if (SettingFlag)
                      { %><input type="radio" name="cbType" id="cbTypeMakeup" value="3"  runat="server" /><label for="cbTypeMakeup">补差分配</label><%} %>
                    <%if (SettingFlag && TradeFlag)
                      { %><input type="radio" name="cbType" id="cbTypeTrade" value="4" runat="server" /><label for="cbTypeTrade">按行业</label><%} %>
                    <%if (SettingFlag && AreaFlag)
                      { %><input type="radio" name="cbType" id="cbTypeArea" value="5" runat="server" /><label for="cbTypeArea">按地区</label><%} %>
                    <%if (SettingFlag && SourceFlag)
                      { %><input type="radio" name="cbType" id="cbTypeSource" value="6" runat="server" /><label for="cbTypeSource">按来源</label><%} %>
                </td>
            </tr>
            <tr>
                <td class="name">
                    分配间隔：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDay" CssClass="txt w50" MaxLength="2" />天。<span >(0-200之间的整数)</span> &nbsp;&nbsp;
                    <span>执行时间：</span>
                    <asp:TextBox runat="server" ID ="txtHour" MaxLength="2" CssClass="txt w50"></asp:TextBox>：
                    <asp:TextBox runat="server" ID ="txtMinute" MaxLength="2" CssClass="txt w50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    最后一次执行时间：<asp:Label runat="server" ID="lbCurExecDate" Text="----" />，
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    预计下次执行日期: <asp:Label runat="server" ID="lbNextDate" Text="----" /> 。
                </td>
            </tr>
            <tr style="height: 40px;">
                <td>
                    &nbsp;
                </td>
                <td>
                    <input type="button" id="btnSubmit" value="立即分配" class="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnSave" Text="保存设置" OnClick ="btnSave_Click" CssClass="btn" />
                </td>
            </tr>
        </table>
        <p class="red" style=" font-size:12px; line-height:180%;">
            下次执行时间计算方法：<br />
            1、未执行过后分配计划：下次执行时间=当前修改日期+分配间隔<br />
            2、执行过分配计划：下次执行时间=最后一次执行时间+分配间隔
        </p>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=33" type="text/javascript"></script>
</body>
</html>
