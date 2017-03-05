<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Web.Enterprise.ClientInfo.Info" %>

<%@ Register Src="../Controls/Property.ascx" TagName="Property" TagPrefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录详情</title>
    <meta http-equiv="pragma" content="no-cach" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script src="../../JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../../JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var INFO_CONFIG = {
            Post_URL: "../handler/CIHandler.ashx",
            CIID:"<%=Request["ciid"] %>"
        };
        //--状态标识
        var aryStatus = [1, 0,0 ];
        function funLoadTalk(obj, i) {
            /// <summary>
            /// 加载话术
            /// </summary>
            $(obj).html("正在加载....");
            $(obj).load("info/Talk.aspx", function () {
                aryStatus[i] = 1;
            });
        }
        function funLoadQuestion(obj,i){
            /// <summary>
            /// 加载调查
            /// </summary>
            $(obj).html("正在加载....");
            $(obj).load("info/question.aspx?ciid=" + INFO_CONFIG.CIID + "&btn=hide#list", function () {
                aryStatus[i] = 1;
            });
        }
        function funLoadStatusLog(obj, i) {
            /// <summary>
            /// 加载状态跟踪内容
            /// </summary>
            $(obj).html("正在加载....");
            $(obj).load("info/StatusLog.aspx?ciid=" + INFO_CONFIG.CIID + "#loglist", function () {
                aryStatus[i] = 1;
            });
        }
        function funLoadExchange(obj, i) {
            /// <summary>
            /// 加载沟通记录
            /// </summary>
            $(obj).html("正在加载....");
            $(obj).load("info/Exchange.aspx?ciid=" + INFO_CONFIG.CIID + "#list", function () {
                aryStatus[i] = 1;
            });
        }

        $(function () {
            
            //--------------------------------我要联系------------------------------------
            $("#btnMyGet").click(function () {
                var data = "ciid=" +INFO_CONFIG.CIID;
                $.post(INFO_CONFIG.Post_URL+"?act=myget", data, function (data) {
                   var msg="";
                   if(data=="1"){
                    //msg="操作成功";
                    PopTip.Show(PopTip.Type.Succ,"操作成功",false);
                   }
                   else{
                    //msg="操作失败";
                    PopTip.Show(PopTip.Type.Error,"操作失败",false);
                   }
                }, "text");
            });
            //--------------------------------选项卡区--------------------------------------
            //选项卡切换
            $("#lookbar .baritem").click(function () {
                if($(this).attr("class").indexOf("cur")>0)
                {
                    return false;
                }
                var i = $("#lookbar .baritem").index(this);
                $("#lookbar .cur").removeClass("cur").addClass("item");
                $(this).removeClass("item").addClass("cur");
                $("#divTab").children("div").hide();
                $("#divTab").children("div").eq(i).show();
                if (aryStatus[i] == 0) {//--未加载
                    if (i == 0) {//调查
                        funLoadQuestion($("#divTab").children("div").eq(i), i);
                    }
                    else if (i == 1) { //状态跟踪
                        funLoadStatusLog($("#divTab").children("div").eq(i), i);
                    }
                    else if(i==2) {//沟通记录
                        funLoadExchange($("#divTab").children("div").eq(i),i);
                    }
                }
            });
        });
    </script>
</head>
<body>
    <div class="nav">
        <h3>
            名录详情</h3>
    </div>
    <form id="form1" runat="server">
    <div id="divInfo" class="clientInfo">
        <table cellpadding="1" cellspacing="1" class="info">
            <tr>
                <td class="name">
                    名录名称：
                </td>
                <td colspan="3">
                    <asp:Literal runat="server" ID="ltClientName" />
                </td>
                <td class="name">
                    名录状态：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltStatus" />
                </td>
            </tr>
            <tr>
                <td class="name">
                    地址：
                </td>
                <td colspan="3">
                    <asp:Literal runat="server" ID="ltAddress" />
                </td>
                <td class="name">
                    邮编：
                </td>
                <td style="width: 180px;">
                    <asp:Literal runat="server" ID="ltZipCode" />&nbsp;
                </td>
            </tr>
            <tr>
                <td class="name">
                    属性：
                </td>
                <td colspan="3">
                    <mlb:Property ID="Property1" runat="server" ShowLabelStyle="true" />
                </td>
                <td class="name">
                    网址：
                </td>
                <td>
                    <asp:HyperLink ID ="hlWebsite" Target="_blank" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="name">
                    联系人：
                </td>
                <td style="width: 180px;">
                    <asp:Literal runat="server" ID="ltLinkman" />
                </td>
                <td class="name">
                    职务：
                </td>
                <td style="width: 180px;">
                    <asp:Literal runat="server" ID="ltPosition" />
                </td>
                <td class="name">
                    邮箱：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltEmail" />
                </td>
            </tr>
            <tr>
                <td class="name">
                    电话号码：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltTel" />
                </td>
                <td class="name">
                    手机号码：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltMobile" />
                </td>
                <td class="name">
                    传真号码：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltFax" />
                </td>
            </tr>
            <tr>
                <td class="name">
                    备注：
                </td>
                <td colspan="5">
                    <asp:Literal runat="server" ID="ltRemark" />
                </td>
            </tr>
        </table>
        <input type="button" id="btnMyGet" runat="server" value="放入我的潜在客户数据库" class="btn1 top10"
            style="display: block;" />
    </div>
    <div class="updown" style="height: 5px;">
        &nbsp;</div>
    <div id="lookbar">
        <div class="baritem cur">
            调查问卷</div>
        <div class="baritem item">
            历史跟踪</div>
        
        <%if (IsShowExchange)
          { %>
        <div class="baritem item">
            沟通记录
        </div>
        <%} %>
    </div>
    <div id="divTab" class="barInfoList">
            
            <div class="barinfo" >
                <table>
                    <asp:Repeater ID="rpList" runat="server" OnItemDataBound="rpList_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("QuestionName") %>
                                </td>
                                <td>
                                    <asp:Repeater ID="rpItem" runat="server">
                                        <ItemTemplate>
                                            <input type="<%#SetType(((Container.Parent.NamingContainer as RepeaterItem).DataItem as System.Data.DataRowView)["QuestionType"])%>"
                                                name="item<%#Eval("QuestionID") %>" id="rb<%#Eval("QuestionItemID") %>" value="<%#Eval("QuestionItemID") %>"  disabled ="disabled"
                                                <%#Check(Eval("Flag")) %> /><label for="rb<%#Eval("QuestionItemID") %>"><%#Eval("QuestionItemName") %></label>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>    
            </div>
            <div class="barinfo" style="display: none;">
                状态跟踪</div>
            
            <div class="barinfo" style="display:none;">
                沟通记录
            </div>
        </div>
    </form>
</body>
</html>
