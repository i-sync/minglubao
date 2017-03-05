<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LSOperate.ascx.cs" Inherits="Web.Enterprise.Controls.LSOperate" %>
<!--操作开始-->
<%if (!HideShare)
  { %>
<input type="button" runat="server" clientidmode="Static" id="btnShare" class="btnShare btn1"
    value="共享" />
&nbsp;&nbsp;
<%} if(!HideDelete){%>
<input type="button" runat="server" clientidmode="Static" id="btnDel" class="btnDel btn1"
    value="删除" />
&nbsp;&nbsp;
<%} %>
<input type="button" runat="server" clientidmode="Static" id="btnShift" class="btnShift btn1"
    value="分配" />&nbsp;&nbsp;
<%if(!HideReport){ %>
<input type="button" runat="server" clientidmode="Static" id="btnReport" class="btnShift btn1"
    value="上报" />
    &nbsp;&nbsp;
    <%} %>

<% if (!HideShare){if(!HideShareAll){ %>
    <input type="button" runat="server" clientidmode="Static" id="btnShareAll" class="btnShare btn1"
    value="全部共享" />
    &nbsp;&nbsp;
<%}} %>
<%if(!HideDelete){if(!HideDeleteAll){ %>
    <input type="button" runat="server" clientidmode="Static" id="btnDelAll" class="btnDel btn1"
    value="全部删除" />
    &nbsp;&nbsp;
<%}} %>
<!--分配 start-->
<div style="border: 1px solid #ccc; width: 380px; display: none; height:100px;
    line-height: 30px; padding: 0px 4px; background-color:White;" id="divShift" load="false">
    <table style=" margin:10px 0 10px 10px;" class="tabtxtlist">
        <tr><td class="name">分配给：</td><td><select id="ddlShiftObject" name="ddlObject" class="ddl1" style="width: 160px;">
    </select></td></tr>
    <tr><td>&nbsp;</td><td><input type="button" id="btnShiftSubmit" value="转移" class="btn1" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" id="btnShiftCancel" value="取消" class="btn1" />
    </td></tr>
    </table>
</div>
<!--分配 end-->
<script type="text/javascript">
    var Operate_CONFIG = {
        plShift: null,
        Post_URL: "/enterprise/handler/Operate.ashx", //------提交地址
        selector: "<%=selector%>", //---选择器
        Mode:"<%=Mode %>",//位置
        Status:"<%=Status %>",//状态
        GetIDs: function () {//获取编号
            if (this.selector.length > 0) {//使用选择器
                var ids = new Array();
                $(this.selector).filter(":checked").each(function () {
                    ids.push($(this).val());
                });
                if (ids.length == 0) {
                    PopTip.Show(PopTip.Type.Error, "请选择名录信息",false);
                    return null;
                }
                return ids.join(',');
            }
            else {
                PopTip.Show(PopTip.Type.Error, "配置错误，未能完成操作",false);
                return null;
            }
        }
    };
    $(function () {
    jQuery.ajaxSetup({ cache:false});
    $.ajaxSetup({cache:false});
    <%if(!HideShare){ %>
        //-----------共享-----------
        $("#btnShare").unbind("click").live("click", function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null&& confirm("确定要共享吗?")) {
                var data = "act=share&ids=" + ids;
                $.post(Operate_CONFIG.Post_URL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "共享成功",true);
                    }
                    else {
                        PopTip.Show(PopTip.Type.Error,data,false);
                    }

                }, "text");

            }
            return false;
        });
        <%if(!HideShareAll){ %>
        //------------------共享全部-----------------
        $("#btnShareAll").unbind("click").live("click",function(){
            if(confirm("确定要共享全部吗？"))
            {
                $.ajax({
                    type:"POST",
                    url:Operate_CONFIG.Post_URL,
                    data:{act:"shareall",mode:Operate_CONFIG.Mode,status:Operate_CONFIG.Status},
                    success:function(data){
                        if(data=="1")
                        {
                            PopTip.Show(PopTip.Type.Succ, "共享成功",true);
                        }
                        else
                        {
                            PopTip.Show(PopTip.Type.Error,data,false);
                        }
                    },
                    dataType:"text"
                });
            }
        });
        <%} %>
    <%} %>
    <%if(!HideDelete){ %>
        //-----------删除-----------
        $("#btnDel").unbind("click").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null && confirm("确定要删除所选中的名录信息吗？")) {
                var data = "act=delete&ids=" + ids;
                $.post(Operate_CONFIG.Post_URL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "删除成功",true);
                    } else {
                        PopTip.Show(PopTip.Type.Error, "删除失败",false);
                    }
                }, "text");
            }
            return false;
        });
        <%if(!HideDeleteAll){ %>
            $("#btnDelAll").unbind("click").click(function(){
                if(confirm("确定要删除全部的名录吗？"))
                {
                    $.ajax({
                        type:"POST",
                        url:Operate_CONFIG.Post_URL,
                        data:{act:"deleteall",mode:Operate_CONFIG.Mode,status:Operate_CONFIG.Status},
                        success:function(data)
                        {
                            if (data == "1") {
                                PopTip.Show(PopTip.Type.Succ, "删除成功",true);
                            } else {
                                PopTip.Show(PopTip.Type.Error, "删除失败",false);
                            }
                        },
                        dataType:"text"
                    });
                }
            });
        <%} %>
    <%} %>
        //-----------分配-----------
        Operate_CONFIG.plShift=new PopupLayer({ title: "名录分配", popupBlk: "#divShift", useOverlay: "true" });
        //---显示分配
        $("#btnShift").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null) {
                var divObj = $("#divShift");
                if ($(divObj).attr("load") == "false") {
                    $.post(Operate_CONFIG.Post_URL, "act=getobj", function (data) {
                        if (data == null) {
                            PopTip.Show(PopTip.Type.Tips, "找不到分配对象",false);
                            return false;
                        }
                        var result = "";
                        for (var i = 0; i < data.length; i++) {
                            result = result + "<option value='" + data[i].value + "'>" + data[i].text + "</option>";
                        }
                        $("#ddlShiftObject").html(result);
                        Operate_CONFIG.plShift.Show();
                    }, "json");
                } else if ($(divObj).attr("load") == "true") {
                    Operate_CONFIG.plShift.Show();
                    return false;
                }
                else {
                    PopTip.Show(PopTip.Type.Tips, "找不到分配对象",false);
                    return false;
                }
            }
            return false;
        });
        //-----分配提交
        $("#btnShiftSubmit").click(function () {
            var ids = Operate_CONFIG.GetIDs();
            if (ids != null) {
                var objid = $("#ddlShiftObject").val();
                var data = "act=shift&objid=" + objid + "&ciids=" + ids;
                $.post(Operate_CONFIG.Post_URL, data, function (data) {
                    if (data == "1") {
                        PopTip.Show(PopTip.Type.Succ, "转移成功",true);
                    } else {
                        PopTip.Show(PopTip.Type.Tips, "转移失败",false);
                    }
                });
            }
        });
        //-----分配取消
        $("#btnShiftCancel").click(function () {
            Operate_CONFIG.plShift.PopClose();
        });
        //----------------上报名录-------------------
        <% if(!HideReport){ %>
            $("#btnReport").live("click",function(){
                var ids = Operate_CONFIG.GetIDs();
                
                if (ids != null && confirm("确定要上报吗?")) {
                    var data = "act=report&ids=" + ids;
                    $.post(Operate_CONFIG.Post_URL, data, function (data) {
                        if (data == "1") {
                            PopTip.Show(PopTip.Type.Succ, "上报成功",true);
                        }
                        else {
                            alert(data);
                        }

                    }, "text");
                }
                return false;
            });
        <%} %>
    });
</script>
<!--操作结束-->
