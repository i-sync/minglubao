<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientInfoTrack.aspx.cs" Inherits="Web.Personal.Item.ClientInfoTrack" %>
<%@ Register Src="~/Personal/Controls/Property.ascx" TagName="Property" TagPrefix="mlb" %>
<%@ Register Src="~/Personal/Controls/Operate.ascx" TagName="Operate" TagPrefix="mlb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>跟踪页</title>
    <meta http-equiv="pragma" content="no-cach" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/core.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/poptip.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="/JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="/JS/popup_layer.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body style="overflow: auto; overflow-x: hidden; overflow-y: scroll;">
    <form id="form1" runat="server">
    <div>   
        <table style="width: 100%; margin: 0; font-size: 14px;">
            <tr>
                <td align="right">
                    <mlb:Operate ID="Operate1" ShowDelete="false" runat="server"/>            
                </td>
            </tr>
        </table>             
    </div>
    <div id="divInfo" style="margin: 0 10px; width: auto;">
        <div style="height: 22px; line-height: 18px; text-indent: 20px; border-bottom: 1px solid #ccc;">
            <span style="font-size: 16px; font-weight: bold;">基本资料</span> <span style="margin-left: 15px;">
                <a href="javascript:void(0)" id="switch">编辑</a></span>
        </div>
        <div id="Info" class="clientInfo">
            <table cellpadding="1" cellspacing="1" class="info">
                <tr>
                    <td class="name">
                        名录名称：
                    </td>
                    <td colspan="5">
                        <asp:Label runat="server" ID="lblClientName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        联系人：
                    </td>
                    <td style="width: 180px;">
                        <asp:Label runat="server" ID="lblLinkman"></asp:Label>
                    </td>
                    <td class="name">
                        职务：
                    </td>
                    <td style="width: 180px;">
                        <asp:Label runat="server" ID="lblPosition"></asp:Label>
                    </td>
                    <td class="name">
                        邮箱：
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblEmail"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        电话号码：
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTel"></asp:Label>
                    </td>
                    <td class="name">
                        手机号码：
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblMobile"></asp:Label>
                    </td>
                    <td class="name">
                        传真号码：
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblFax"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        地址：
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" ID="lblAddress"></asp:Label>
                    </td>
                    <td class="name">
                        邮编：
                    </td>
                    <td style="width: 180px;">
                        <asp:Label runat="server" ID="lblZipCode"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        属性：
                    </td>
                    <td colspan="3">
                        <mlb:Property ID="Property2" runat="server" ShowLabelStyle="true" IsEnterpriseData ="true" />
                    </td>
                    <td class="name">
                        网址：
                    </td>
                    <td>
                        <asp:HyperLink ID="hlWebsite" Target="_blank" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        QQ：
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblQQ"> </asp:Label>
                    </td>
                    <td class="name">
                        MSN：
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblMSN"></asp:Label>
                    </td>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        备注：
                    </td>
                    <td colspan="5">
                        <asp:Label runat="server" ID="lblRemark"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="Edit" class="clientInfo" style="line-height: 34px; display: none">
            <table cellpadding="1" cellspacing="1">
                <tr>
                    <td class="name">
                        名录名称：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" CssClass="txt w500" ID="txtClientName" MaxLength="60" />
                    </td>
                    <td id="TipsName" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        联系人：
                    </td>
                    <td style="width: 180px;">
                        <asp:TextBox runat="server" CssClass="txt" ID="txtLinkman" MaxLength="30" />
                    </td>
                    <td class="name">
                        职务：
                    </td>
                    <td style="width: 180px;">
                        <asp:TextBox runat="server" CssClass="txt" ID="txtPosition" MaxLength="60" />
                    </td>
                    <td class="name">
                        邮箱：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtEmail" MaxLength="60" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        电话号码：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtTel" MaxLength="32" />
                    </td>
                    <td class="name">
                        手机号码：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtMobile" MaxLength="11" />
                    </td>
                    <td colspan="3" id="TipsContact">
                        
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        地址：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" CssClass="txt w500" ID="txtAddress" MaxLength="60" />
                    </td>
                    <td class="name">
                        邮编：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtZipCode" MaxLength="6" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        属性：
                    </td>
                    <td colspan="3">
                        <mlb:Property ID="Property1" runat="server" IsEnterpriseData="true" />
                    </td>
                    <td class="name">
                        网址：
                    </td>
                    <td>
                        <asp:TextBox ID="txtWebsite" CssClass="txt" runat="server" MaxLength="60" />
                    </td>
                    <td>
                        &nbsp;<a href="javascript:void(0)" id="aWebsite">打开</a>
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        QQ：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtQQ" MaxLength="60"></asp:TextBox>
                    </td>
                    <td class="name">
                        MSN：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtMSN" MaxLength="60"></asp:TextBox>
                    </td>
                    <td class="name">
                        传真号码：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt" ID="txtFax" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        备注：
                    </td>
                    <td colspan="4">
                        <asp:TextBox runat="server" ID="txtRemark" CssClass="txt" Width="600" />
                    </td>
                    <td>
                        <input type="button" runat="server" class="btn1" id="btnUpdateBase" value="修改" />
                        &nbsp;&nbsp;
                        <input type="button" runat="server" class="btn1" id="btnCancelBase" value="取消" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divStatus" class="clientInfo" style="line-height: 34px; margin-top: 1px;">
            <table>
                <tr>
                    <td valign="top" class="name">
                        名录状态：
                    </td>
                    <td colspan="5" style="vertical-align: top;">
                        <table cellpadding="1" cellspacing="1" class="tabstate">
                            <tr>
                                <td class=" w120">
                                    <input type="radio" name="rdState" value="1" id="rdState1" /><label for="rdState1">潜在客户</label>
                                </td>
                                <td class=" w120">
                                    <input type="radio" name="rdState" value="2" id="rdState2" /><label for="rdState2">意向客户</label>
                                </td>
                                <td class=" w120">
                                    <input type="radio" name="rdState" value="3" id="rdState3" /><label for="rdState3">成交客户</label>
                                </td>
                                <td class=" w120">
                                    <input type="radio" name="rdState" value="4" id="rdState4" /><label for="rdState4">失败客户</label>
                                </td>
                                <td class=" w120">
                                    <input type="radio" name="rdState" value="5" id="rdState5" /><label for="rdState5">报废客户</label>
                                </td>
                            </tr>
                            <tr id="trState1" class="hide">
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="trState2" class="hide">
                                <td class="statename">
                                    意向程度：
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlWish" CssClass="ddl1 w420" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="trState3" class="hide">
                                <td class="statename">
                                    成交金额：
                                </td>
                                <td colspan="4">
                                    <asp:TextBox runat="server" CssClass="txt1" Style="margin: 2px;" ID="txtMoney" />
                                </td>
                            </tr>
                            <tr id="trState4" class="hide">
                                <td class="statename">
                                    失败理由：
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlNotTraded" CssClass="ddl1 w420" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="trState5" class="hide">
                                <td class="statename">
                                    报废理由：
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlScrap" CssClass="ddl1 w420" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <input type="button" id="btnUpdateStatus" class="btn h38" value="修改状态" />
                        <asp:HiddenField runat="server" ID="hdStatus" />
                        <asp:HiddenField runat="server" ID="hdWish" />
                        <asp:HiddenField runat="server" ID="hdNotTraded" />
                        <asp:HiddenField runat="server" ID="hdScrap" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="updown">
        <img src="/images/up.jpg" id="imgUpDown" alt="关闭" /></div>
    <div id="lookbar">
        <div class="baritem cur">
            沟通记录</div>
        <div class="baritem item">
            历史跟踪</div>
    </div>
    <div id="divTab" class="barInfoList" style="margin-bottom: 10px;">
        <div class="barinfo">
            <table>
                <tr style="display: none;">
                    <td style="width: 70px; padding: 0; margin: 0;">
                        沟通时间：
                    </td>
                    <td>
                        <input type="text" id="txtWdate" class="Wdate txt1" style="width: 150px;" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <textarea rows="3" cols="80" id="txtInfo" style="font-size: 12px;"></textarea>
                    </td>
                    <td valign="top">
                        <input type="button" id="btnLogSend" class="btn h38" value="提交" />
                    </td>
                </tr>
            </table>
            
            <table cellpadding="1" cellspacing="1" class="tablist" style="width: 97%; margin: 10px 0 40px 10px;
                font-size: 12px; line-height: 180%;" id="tbExchangeList">
                <tr>
                    <th style="width: 40px;">
                        序号
                    </th>
                    <th>
                        沟通内容
                    </th>
                    <th style="width: 120px;">
                        通话时间
                    </th>
                    <th style="width: 120px;">
                        联系人
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpExchangeList">
                    <ItemTemplate>
                        <tr class="c">
                            <td>
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td>
                                <%#Eval("Detail") %>
                            </td>
                            <td>
                                <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <%#Eval("UserInfo") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <!--模板 start-->
            <table style="display: none;">
                <tr id="trTemplate" style="display: none;" class="c">
                    <td class="id">
                    </td>
                    <td class="detail">
                    </td>
                    <td class="date">
                    </td>
                    <td class="realname">
                    </td>
                </tr>
            </table>
            <!--模板 end-->
        </div>
        <div class="barinfo" style="display: none;">
            调查问卷</div>
        <div class="barinfo" style="display: none;">
            通话话术</div>
        <div class="barinfo" style="display: none;">
            状态跟踪</div>
    </div>
    </form>
    <script type="text/javascript">
        var CONFIG={
            CIID:"<%=Request["ciid"] %>",
            UpdateURL:"/personal/handler/item.ashx"
        };
        //--状态标识
        var aryStatus = [1, 0];              
        function funLoadStatusLog(obj, i) {
            /// <summary>
            /// 加载状态跟踪内容
            /// </summary>
            $(obj).html("正在加载....");
            $(obj).load(URLPlusRandom("StatusLog.aspx?ciid=<%=Request["ciid"] %>#loglist"), function () {
                aryStatus[i] = 1;
            });
        }

        ///控制修改状态按钮是否可用
        //status为默认状态，v为新状态
        function funStatus(v,status)
        {
            if(v==status)
            {                
                var wishid = $("#ddlWish").val();               
                var oldwishid= $("#hdWish").val(); 
                var nottradedid = $("#ddlNotTraded").val();
                var oldnottradedid = $("#hdNotTraded").val();
                var scarpid = $("#ddlScrap").val();
                var oldscarpid=$("#hdScrap").val(); 
                if(v==1||wishid==oldwishid||nottradedid==oldnottradedid||scarpid==oldscarpid) 
                {
                    $("#btnUpdateStatus").attr("disabled","disabled");
                }
                else
                {
                    $("#btnUpdateStatus").removeAttr("disabled");                    
                }                    
            }
            else
            {
                $("#btnUpdateStatus").removeAttr("disabled");
            }
        }

        $(function () {
           
            //----------------------------基本信息区--------------------------------
            //判断名录名称是否存在
            $("#txtClientName").blur(function () {
                var name = $("#txtClientName").val();
                if ($.IsNullOrEmpty(name)) {
                    //ShowTips("#TipsName", false, "");
                    $("#TipsName").html("<span class='error'>请输入名录名称</span>");
                    return;
                }
                $("#TipsName").html("<span class='succ'>正在检测中……</span>");
                $.ajax({
                    type: "POST",
                    url:  URLPlusRandom(CONFIG.UpdateURL),
                    data: { key: "clientinfoexists", ciid:CONFIG.CIID,type:"0",value:name },
                    success: function (data) {
                        if(data.flag=="1")
                        {
                            $("#TipsName").html("<span class='succ'>"+data.detail+"</span>");
                            $("#txtClientName").removeClass("error");
                        }
                        else
                        {
                            $("#TipsName").html("<span class='error'>"+data.detail+"</span>");
                            $("#txtClientName").addClass("error");
                        }
                    },
                    dataType: "json"
                });
            });
            $("#txtClientName").focus(function () {
                $("#TipsName").html("");
                $(this).removeClass("error");
            });

            //检测手机
            $("#txtMobile").blur(function () {
                var v = $.trim($(this).val());
                var obj = $(this);
                var msg = "";
                if (v.length > 0 && !$.IsMobile(v)) {//判断格式是否为手机格式
                    msg="<span class='error'>手机号格式不正确</span>";
                    $("#TipsContact").html(msg);
                    $(obj).addClass("error");
                }
                else if(v.length>0){
                    $.ajax({
                        type: "POST",
                        url: URLPlusRandom(CONFIG.UpdateURL ),
                        data: { key:"clientinfoexists",ciid: CONFIG.CIID, type: "1", value: v },
                        success: function (data) {
                            if(data.flag == "1")
                            {
                                $("#TipsContact").html("");
                                $(obj).removeClass("error");
                            }
                            else
                            {
                                msg="<span class='error'>"+data.detail+"</span>";
                                $("#TipsContact").html(msg);
                                $(obj).addClass("error");
                            }
                            
                        },
                        dataType: "json"
                    });
                }
                else
                {
                    $("#TipsContact").html("");
                    $(obj).removeClass("error");
                }
            });

            //检测电话号码
            $("#txtTel").blur(function () {
                var v = $.trim($(this).val());
                var _this = this;
                var msg = "";
                if (v.length > 0 && !$.IsTel(v)) {//判断格式是否为手机格式
                    msg="<span class='error'>电话号格式不正确</span>";
                    $("#TipsContact").html(msg);
                    $(_this).addClass("error");
                }
                else if(v.length>0){
                    $.ajax({
                        type: "POST",
                        url: URLPlusRandom(CONFIG.UpdateURL ),
                        data: { key:"clientinfoexists", ciid: CONFIG.CIID, type: "2", value: v },
                        success: function (data) {
                            if(data.flag == "1")
                            {
                                $("#TipsContact").html("");
                                $(_this).removeClass("error");
                            }
                            else
                            {
                                msg="<span class='error'>"+data.detail+"</span>";
                                $("#TipsContact").html(msg);
                                $(_this).addClass("error");
                            }                            
                        },
                        error:function(data){
                            msg="<span class='error'>"+data+"</span>";
                            $("#TipsContact").html(msg);
                            $(_this).addClass("error");
                        },
                        dataType: "json"
                    });
                }
                else
                {
                    $("#TipsContact").html("");
                    $(_this).removeClass("error");
                }
            });
            //检测邮箱
            $("#txtEmail").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsEmail(v)) {//判断格式是否为邮箱格式
                    $(this).addClass("error");
                } else {
                    $(this).removeClass("error");
                }
            });
            //检测传真
            $("#txtFax").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsTel(v)) {
                    $(this).addClass("error");
                }
                else {
                    $(this).removeClass("error");
                }
            });
            //检测QQ
            $("#txtQQ").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && ($.IsInt(v) || $.IsEmail(v))) {//判断格式是否为QQ
                    $(this).removeClass("error");
                } else if (v.length > 0) {
                    $(this).addClass("error");
                }
            });
            //检测MSN
            $("#txtMSN").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsEmail(v)) {//判断格式是否为邮箱格式
                    $(this).addClass("error");
                } else {
                    $(this).removeClass("error");
                }
            });

            //打开网址
            $("#aWebsite").click(function () {
                var website = $.trim($("#txtWebsite").val());
                if ($.IsNullOrEmpty(website) || $.trim(website) == "http://www.") {
                    return;
                }
                if (website.indexOf("http://") == -1) {
                    website = "http://" + website;
                }
                window.open(website);
            });

            ///------------------切换名录基本状态--------------------
            $("#switch").click(function(){
                if($("#Info").css("display")==="block"){
                    $("#Info").hide();
                    $("#Edit").show();
                    $(this).text("取消");
                }else{
                    $("#Info").show();
                    $("#Edit").hide();
                    $(this).text("编辑");
                }
            });
            ///-----------------------------------------------------

            //---提交基本信息区信息修改
            $("#btnUpdateBase").click(function () {  
                $(":text").trigger("blur");
                if($(".error").length>0)
                {
                    alert("请检查红色部分");
                    return;
                }                  
                var clientname = $("#txtClientName").val();
                var zipcode = $("#txtZipCode").val();
                var address = $("#txtAddress").val();
                var linkman = $("#txtLinkman").val();
                var position = $("#txtPosition").val();
                var website= $("#txtWebsite").val();
                var email = $("#txtEmail").val();
                var tel = $("#txtTel").val();
                var mobile = $("#txtMobile").val();
                var fax = $("#txtFax").val();
                var qq = $("#txtQQ").val();
                var msn = $("#txtMSN").val();
                var remark = $("#txtRemark").val();
                //---属性---
                var sourceId = Property.GetSource();
                var areaId = Property.GetArea();
                var tradeId = Property.GetTrade();
                var data = "key=updatebase&ciid=" + CONFIG.CIID + "&clientname=" + $.trim(clientname) + "&zipcode=" + $.trim(zipcode) + "&address=" + address + "&linkman=" + linkman + "&position=" + position + "&email=" + email+ "&website="+ website + "&tel=" + $.trim(tel) + "&mobile=" + $.trim(mobile) + "&fax=" + fax + "&qq=" + qq +"&msn=" + msn + "&remark=" + remark + "&sourceid=" + sourceId + "&areaid=" + areaId + "&tradeid=" + tradeId+ "&t=" + Math.random();
                
                //标识是否修改成功
                var flag =false;
                //--提交修改
                /*$.post(URLPlusRandom(CONFIG.UpdateURL+"?act=updatebase"), data, function (data) {
                    var msg = "";
                    if (data == "1") {
                        msg = "修改成功";
                        flag= true;
                        PopTip.Show(PopTip.Type.Succ,msg,false);
                    } else {
                        msg = "修改失败,结果：" + data;
                        PopTip.Show(PopTip.Type.Tips, msg,false);
                    }                    
                }, "text");*/
                $.ajax({
                    type:"POST",
                    async:false,
                    url:URLPlusRandom(CONFIG.UpdateURL),
                    data:data,
                    success:function(data){
                        var msg = "";
                        if (data == "1") {
                            msg = "修改成功";
                            flag= true;
                            PopTip.Show(PopTip.Type.Succ,msg,false);
                        } else {
                            msg = "修改失败,结果：" + data;
                            PopTip.Show(PopTip.Type.Tips, msg,false);
                        }   
                    },
                    dataType:"text"
                });

                //alert($("#lblClientName").text());
                //alert(flag);
                if(flag)
                {
                    $("#lblClientName").text(clientname);
                    $("#lblZipCode").text(zipcode);
                    $("#lblAddress").text(address);
                    $("#lblLinkman").text(linkman);
                    $("#lblPosition").text(position);
                    var site= website.indexOf("http://")>-1?website:"http://"+website
                    $("#hlWebsite").attr("href",site).text(website);
                    $("#lblEmail").text(email);
                    $("#lblTel").text(tel);
                    $("#lblMobile").text(mobile);
                    $("#lblFax").text(fax);
                    $("#lblQQ").text(qq);
                    $("#lblMSN").text(msn);
                    $("#lblRemark").text(remark);
                    //属性
                    $("#Property2_lblSource").text($("#ddlSource").find("option").filter(":selected").text());
                    $("#Property2_lblArea").text($("#Property1_ddlArea").find("option").filter(":selected").text());
                    $("#Property2_lblTrade").text($("#Property1_ddlTrade").find("option").filter(":selected").text());
                }
                //切换DIV
                $("#switch").trigger("click");
            });
            $("#btnCancelBase").click(function(){
                  $("#switch").trigger("click");
            });
            //--------------------------------状态区--------------------------------------
             //-------设置默认状态
            var status = $("#hdStatus").val();
            var v
            //单击状态
            $(":radio[name='rdState']").click(function () {
                v = $(this).val();
                $(".tabstate tr[id]").addClass("hide");
                $("#trState" + v).removeClass("hide");
                funStatus(v,status);
            });

            $("#ddlWish").change(function(){
                funStatus(v,status);
            });
            $("#ddlNotTraded").change(function(){
                funStatus(v,status);
            });
            $("#ddlScrap").change(function(){
                funStatus(v,status);
            });
           
            $($(":radio[name='rdState']").eq(status - 1)).trigger("click");
            //--修改状态
            $("#btnUpdateStatus").click(function () {
                var status = $(":checked[name='rdState']").val();
                //获取状态下的内容
                var objTr = $(".tabstate tr[id]").eq(status - 1);
                var data = "无";
                if (status < 1 || status > 5) {
                    //alert("状态错误");
                    PopTip.Show(PopTip.Type.Error, "状态错误",false);
                    return false;
                }
                data = "key=updatestatus&ciid=" + CONFIG.CIID + "&status=" + status+ "&t=" + Math.random();
                if (status == 2) {
                    var wishid = $("#ddlWish").val();
                    if (wishid == undefined || wishid == "") {
                        PopTip.Show(PopTip.Type.Tips,"请选择意向程度",false);
                        return false;
                    }
                    data = data + "&wishid=" + wishid;
                }
                else if (status == 3) {
                    var money = $.trim($("#txtMoney").val());
                    if ($.IsNullOrEmpty(money)) {
                        //alert("请输入成交金额");
                        PopTip.Show(PopTip.Type.Tips, "请输入成交金额",false);
                        return false;
                    }
                    else if (!$.IsNumber(money)) {
                        //alert("请输入正确的成交金额");
                        PopTip.Show(PopTip.Type.Tips,"请输入正确的成交金额",false);
                        return false;
                    }
                    data = data + "&money=" + money;
                }
                else if (status == 4) {
                    var notradedid = $("#ddlNotTraded").val();
                    if (notradedid == undefined || notradedid == "") {
                        //alert("请选择失败理由");
                        PopTip.Show(PopTip.Type.Tips,"请选择失败理由",false);
                        return false;
                    }
                    data = data + "&nottradedid=" + notradedid;
                }
                else if (status == 5) {
                    var scrapid = $("#ddlScrap").val();
                    if (scrapid == undefined || scrapid == "") {
                        //alert("请选择报废理由");
                        PopTip.Show(PopTip.Type.Tips,"请选择报废理由",flase);
                        return false;
                    }
                    data = data + "&scrapid=" + scrapid;
                }
                //--提交修改
                $.post(URLPlusRandom(CONFIG.UpdateURL), data, function (data) {
                    var msg = "";
                    if (data == "1") {
                        msg = "修改成功";
                        PopTip.Show(PopTip.Type.Succ, msg,true);
                    } else {
                        msg = "修改失败,结果：" + data;
                        PopTip.Show(PopTip.Type.Error,msg,false);
                    }
                    //alert(msg);
                }, "text");
            });
            //--------------------------------关闭、展开------------------------------------
            $(".updown").click(function () {
                $("#divInfo").slideToggle("slow");
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
                    if(i==1){//状态跟踪
                        funLoadStatusLog($("#divTab").children("div").eq(i), i);
                    }                   
                }
            });
            //--日期控件
            $(".Wdate").click(function () { WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' }); });
            //--提交沟通记录
            $("#btnLogSend").click(function () {
                var info = $.trim($("#txtInfo").val());
                var date = $("#txtWdate").val();
                if ($.IsNullOrEmpty(info)) {
                    PopTip.Show(PopTip.Type.Tips, "请输入沟通内容",false);
                    $("#txtInfo").focus();
                    return false;
                }
                var data = "key=addexchange&ciid=" + CONFIG.CIID + "&date=" + date + "&info=" + info+ "&t=" + Math.random();
                $.post(URLPlusRandom(CONFIG.UpdateURL), data, function (data) {
                    if (data.result == "1") {//成功
                        PopTip.Show(PopTip.Type.Succ,"提交成功",false);
                        $("#tbExchangeList tr").first().after($("#trTemplate").clone());
                        var objTr = $("#tbExchangeList").find("#trTemplate");
                        $(objTr).find(".id").text("1");
                        $(objTr).find(".detail").text(data.detail);
                        $(objTr).find(".date").text(data.date);
                        $(objTr).find(".realname").text(data.realname);
                        $(objTr).removeAttr("id");
                        $(objTr).fadeIn("slow");
                        $("#txtInfo").val("");
                        $("#tbExchangeList tr").each(function (i) {
                            $(this).find("td").first().text(i);
                        });
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "提交错误",false);
                    }
                }, "json");
            });

        });
    </script>
</body>
</html>
