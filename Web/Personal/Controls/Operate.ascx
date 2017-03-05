<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Operate.ascx.cs" Inherits="Web.Personal.Controls.Operate" %>
<!--操作开始-->
<script type="text/javascript">
    var Operate_CONFIG =
    {
        plEmail: null,
        PostURL: "/personal/handler/clientinfo.ashx",
        SendMailUrl: "/Personal/Info/SendMail.aspx",
        selector: "<%=selector%>", //---选择器
        id: "<%=ClientInfoID%>", //--编号
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
        }
    };
    function EmailClose() {
        Operate_CONFIG.plEmailClose();
    }
    $(function () {
        Operate_CONFIG.plEmail = new PopupLayer({ title: "发送邮件", popupBlk: "#divSendEmail", useOverlay: "true" });

        //----个人删除项目名录-----
        $("#btnDelete").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids && confirm("确认要删除吗？")) {
                
                $.ajax({
                    type: "POST",
                    url: "/personal/handler/item.ashx",
                    data: {key:"delete",ids:ids},
                    success: function (data) {
                        if (data == "1") {
                            PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                        }
                        else {
                            PopTip.Show(PopTip.Type.Error, "删除失败", false);
                        }
                    },
                    dataType:"text"
                });
            }
        });

        //----个人共享项目名录-----
        $("#btnShare").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids && confirm("确认要共享吗？")) {
                $.ajax({
                    type: "POST",
                    url: "/personal/handler/item.ashx",
                    data: { key: "share", ids: ids },
                    success: function (data) {
                        if (data == "1") {
                            PopTip.Show(PopTip.Type.Succ, "共享成功", true);
                        }
                        else {
                            PopTip.Show(PopTip.Type.Error, "共享失败", false);
                        }
                    },
                    dataType: "text"
                });
            }
        });

        //----删除名录
        $("#btnDel").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids && confirm("确认要删除吗？")) {
                var data = "key=delete&ids=" + ids;
                $.post(Operate_CONFIG.PostURL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error, "删除失败", false);
                    }
                });
            }
        });
        //----发送邮件
        $("#btnSendEmail").click(function () {
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
    });
</script>
<table>
    <tr>
        <%if (IsShowDelete)
          {%>
          <td>
            <!--该按钮只有在个人用户加入项目后，才会显示可用，它删除的是项目名录（个人加入项目后录入的名录ItemClientInfo数据表）-->
            <input type="button" id="btnDelete" class ="btn1" value ="删除" />
          </td>

          <td>
            <input type="button" id="btnShare" class="btn1" value ="共享" />
          </td>
        <%} %>

        <%if (ShowDelete)
          { %>
        <td>
            <input type="button" id="btnDel" class="btn1" value="删除" />
        </td>
        <%} %>
        <td>
            <input type="button" id="btnSendEmail" class="btn1" value="发送电子邮件" />
        </td>
        <%if (ShowFax)
          { %>
        <td>
            <input type="button" id="btnSendFax" class="btn1" value="发送电子传真" />
        </td>
        <%} if (ShowSMS)
          { %>
        <td>
            <input type="button" id="btnSendSMS" class="btn1" value="发送短信" />
        </td>
        <%} %>
    </tr>
</table>
<div style="display: none; border: 1px solid #ccc; width: 600px; height: 410px; background-color:White;" id="divSendEmail" >
    <iframe src="about:blank" width="100%" height="100%" frameborder="0" id="ifrSendMail"></iframe>
</div>
<!--操作结束-->
