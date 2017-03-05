<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataImport.aspx.cs" Inherits="Web.Personal.Item.DataImport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据导入</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtTotalCount").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入数量</span>";
                }
                else if (!$.IsInt(v)) {
                    msg = "<span class='error'>请输入正确的整数</span>";
                }
                else if (parseInt(v) > 2000 || parseInt(v) < 0) {
                    msg = "<span class='error'>请输入1-2000的整数</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsTC").html(msg);
            });

            //个人名录－－－＞项目名录
            $("#btnPISwitch").click(function () {
                $("#txtTotalCount").triggerHandler("blur");
                if ($(".error").length > 0) {
                    return false;
                }
            });

            ///项目名录－－－＞个人名录
            $("#btnIPSwitch").click(function () {
                $("#txtTotalCount").triggerHandler("blur");
                if ($(".error").length > 0) {
                    return false ;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>数据导入</h3>
    </div>

    <div class="divlist">
        <span>  请输入导入数量(最多2000 指的是成功导入数量)：</span>
        <asp:TextBox ID="txtTotalCount" CssClass="txt1 w120" runat="server"></asp:TextBox>
        <span id="TipsTC"></span>
    </div>
    <div class="divlist">
        <div style="float:left;margin:0px 20px 0px 0px;"><h4>个人名录——＞项目名录</h4></div>
        <div>
            <asp:CheckBox ID="cbPIExchange" Checked ="true" Text="同时导入沟通记录" runat="server" />
        </div>
        <i class="clear"></i>
        <div>
            <table  style="width:650px;">
                <tr>
                    <td>
                        <asp:RadioButtonList ID ="rbPISStatus" RepeatDirection="Horizontal" runat="server"></asp:RadioButtonList>
                    </td>
                    <td style="width:100px;">
                        <asp:Button ID="btnPISwitch" Text="导入" OnClick="btnPISwitch_Click" CssClass="btn1" runat="server" />
                    </td>
                    <td  style="width:120px;">
                        <asp:RadioButtonList ID="rbPITStatus"  RepeatDirection="Horizontal" Enabled ="false" runat="server"></asp:RadioButtonList>
                    </td>
                    
                </tr>
            </table>
        </div>
    </div>

    <div class="divlist">
        <div style="float:left;margin:0px 20px 0px 0px;"><h4>项目名录——＞个人名录</h4></div>
        <div>
            <asp:CheckBox ID="cbIPExchange" Checked="true" Text="同时导入沟通记录" runat="server" />
        </div>
        <i class="clear"></i>
        <div>
            <table  style="width:650px;">
                <tr>
                    <td>
                        <asp:RadioButtonList ID ="rbIPSStatus"  RepeatDirection="Horizontal"  runat="server"></asp:RadioButtonList>
                    </td>
                    <td style="width:100px;">
                        <asp:Button ID="btnIPSwitch" Text="导入" OnClick="btnIPSwitch_Click" CssClass="btn1" runat="server" />
                    </td>
                    <td  style="width:120px;">
                        <asp:RadioButtonList ID="rbIPTStatus"  RepeatDirection="Horizontal"  Enabled ="false" runat="server"></asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div  style="height:50px;margin:20px 20px; display:block;" >
        <div>
            <asp:Label ID ="lblResult" runat="server"></asp:Label>
        </div>
    </div>

    <div  style="margin:20px 20px;">
        <div>
            说明：选中你要导入名录状态，每次最多导入2000条名录，导入名录的顺序是按名录编号升序排列的。<br />
            导入名录总数是按成功数量计算的，重复名录(名称,电话,手机)无法导入。<br />
            提示：沟通记录不能单独导入(也就是说，如果你导数据时没有导入沟通记录，那么沟通记录就不能再导入了)
        </div>
    </div>
    </form>
</body>
</html>
