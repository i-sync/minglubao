<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Operate.ascx.cs" Inherits="Web.Enterprise.Controls.Operate" %>
<!--操作开始-->
<script type="text/javascript">
    var Operate_CONFIG = {
        plEmail: null,
        plSMS: null,
        Post_URL: "/Enterprise/Handler/Operate.ashx",
        Succ_URL: "", //--操作成功后跳转地址
        selector: "<%=selector%>", //---选择器
        id: "<%=_clientinfoid%>", //--编号
        Tips: "暂未开放", //--提示信息
        SendMailUrl: "/enterprise/page/sendmail.aspx", //--发送邮件地址
        SendSMSUrl: "/enterprise/page/sendsms.aspx", //--发送短信
        GetIDs: function () {//获取编号
            if (this.selector.length > 0) {//使用选择器
                var ids = new Array();
                $(this.selector).each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    //alert("请选择名录信息");
                    PopTip.Show(PopTip.Type.Error, "请选择名录信息", false);
                    return null;
                }
                return ids.join(',');
            }
            else if (this.id > 0) {//通过ID
                return this.id;
            }
            else {
                //alert("配置错误，未能完成操作！");
                PopTip.Show(PopTip.Type.Error, "配置错误，未能完成操作！", false);
                return null;
            }
        },
        plEmailClose: function () {
            this.plEmail.PopClose();
        },
        plSMSClose: function () {
            this.plSMS.PopClose();
        }
    };
    function EmailClose() {
        Operate_CONFIG.plEmailClose();
    }
    function SMSClose() {
        Operate_CONFIG.plSMSClose();
    }
    $(function () {
        jQuery.ajaxSetup({ cache: false });
        Operate_CONFIG.plEmail = new PopupLayer({ title: "发送邮件", popupBlk: "#divSendEmail", useOverlay: "true" });
        Operate_CONFIG.plSMS = new PopupLayer({ title: "发送短信", popupBlk: "#divSendSMS", useOverlay: "true" });
        //-----------共享-----------
        $(".btnShare").unbind("click").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null && confirm("确认要共享吗？")) {
                var data = "act=share&ids=" + ids;
                $.post(Operate_CONFIG.Post_URL, data, function (data) {
                    //alert(data);
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "共享成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "共享失败", false);
                    }
                }, "text");

            }
            return false;
        });
        //-----------发送电子邮件-----------
        $(".btnSendEmail").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null) {
                if ($("#divSendEmail").attr("ids") != ids) {
                    $("#ifrSendMail").attr("src", Operate_CONFIG.SendMailUrl + "?act=ids&ids=" + ids);
                    $("#ifrSendMail").bind("load", function () {
                        $("#divSendEmail").attr("ids", ids);
                    });
                }
                Operate_CONFIG.plEmail.Show();
            }
        });
        //-----------发送短信-----------
        $(".btnSendSMS").click(function () {
            PopTip.Show(PopTip.Type.Tips, Operate_CONFIG.Tips, false);
            return false;
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null) {
                if ($("#divSendSMS").attr("ids") != ids) {
                    $("#ifrSendSMS").attr("src", Operate_CONFIG.SendSMSUrl + "?act=ids&ids=" + ids);
                    $("#ifrSendSMS").bind("load", function () {
                        $("#divSendSMS").attr("ids", ids);
                    });
                }
                Operate_CONFIG.plSMS.Show();
            }
            return false;
        });

        <%if(ShowLock){ %>
        //----------------锁定名录--------------
        $(".btnLocking").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null) {
                var data = "act=lock&ids=" + ids + "&islock=1";
                $.post(Operate_CONFIG.Post_URL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "锁定成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "锁定失败", false);
                    }
                },"text");
            }
        });

        //----------------解锁名录--------------
        $(".btnUnLock").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null) {
                var data = "act=lock&ids=" + ids + "&islock=0";
                $.post(Operate_CONFIG.Post_URL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "解锁成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "解锁失败", false);
                    }
                }, "text");
            }
        });
        <%} %>
    });
</script>
<div><%if(ShowShare){ %>
<input type="button" id="btnShare" class="btnShare btn1" value="共享" />
&nbsp;&nbsp;<%} %>
<input type="button" id="btnSendEmail" class="btnSendEmail btn1" value="发送电子邮件" />
&nbsp;&nbsp;
<% if (ShowSMS)
   { %>
    &nbsp;&nbsp;
    <input type="button" id="btnSendSMS" class="btnSendSMS btn1" value="发送短信" />
<%} if (ShowLock)
   {%>
<input type = "button" id ="btnLocking" class="btnLocking btn1" value="锁定" />
&nbsp;&nbsp;
<input type = "button" id = "btnUnLock" class="btnUnLock btn1" value ="解锁" />
<%} %>
</div>
<div style="display: none;width: 680px; height:405px;background-color:White;"
    id="divSendEmail">
    <iframe src="about:blank" width="100%" height="100%" frameborder="0" id="ifrSendMail"></iframe>
</div>
<div style="display: none; border: 1px solid #468ed0; width:500px; height:200px;background-color:White;"
    id="divSendSMS">
    <iframe src="about:blank" width="100%" height="100%" frameborder="0" id="ifrSendSMS"></iframe>
</div>
<!--操作结果-->
