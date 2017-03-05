<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Web.Personal.WenKu.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文库 个人上传</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //改变选择项目分类
            $("#ddlCategory").change(function () {
                var v = $(this).val();
                if (v == "0") {
                    $("#txtCustom").show();
                    $("#txtCustom").val("");
                    $("#txtCustom").focus();
                }
                else {
                    $("#txtCustom").hide();
                }
                $("#txtCustom").triggerHandler("blur");
            });

            ///标题验证
            $("#txtCaption").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入标题</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsCaption").html(msg);
            });

            //分类选择验证
            $("#txtCustom").blur(function () {
                if ($(this).is(":visible")) {//判断 是否可见
                    var v = $.trim($(this).val());
                    var msg = "";
                    if ($.IsNullOrEmpty(v)) {
                        msg = "<span class='error'>请选择或输入自定义分类</span>";
                    }
                    else {
                        msg = "";
                    }
                    $("#TipsCategory").html(msg);
                }
                else {
                    $("#TipsCategory").html("");
                }
            });

            //点击提交按钮处理事件
            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    return false;
                }
            });
            $("#ddlCategory").triggerHandler("change");
        });

        ///初始化
        function InitFile(filename) {
            $("#txtCaption").val(filename.substring(0,filename.lastIndexOf(".")));
            //异步请求判断文档名称是否存在
            $.ajax({
                type: "POST",
                url: "/handler/wenku.ashx",
                data: { key: "exists", filename: filename },
                success: function (data) {
                    var msg = "";
                    if (data == "1") { //文件名称已存在
                        msg = "<span class='error'>该文档已存在！</span>";
                    }
                    else {
                        msg = "";
                    }
                    $("#TipsName").html(msg);
                },
                dataType: "text"
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>上传文档</h3>
    </div>
    <div class="divlist">
        <div style="margin:5px auto 15px auto;">
            <div style="float:left;margin:auto 10px auto 2px;">选择：</div>
            <div style="float:left;"><mlb:FileUpload ID="FileUpload1" FunName="InitFile" runat="server" /></div>
            <span style="margin:auto 10px;">注意：上传文档不能超过5M</span>
            <span id="TipsName"></span>
            <i class="clear"></i>
        </div>
        <div>
            <h4>填写文档信息</h4>
            <table class="tabtxtlist">
                <tr>
                    <td>标题：</td>
                    <td>
                        <asp:TextBox ID="txtCaption" CssClass="txt w500" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height:7px;">
                    <td>
                        &nbsp;
                    </td>
                    <td id ="TipsCaption">
                    </td>
                </tr>
                <tr>
                    <td valign="top">介绍：</td>
                    <td>
                        <asp:TextBox ID="txtIntro" TextMode="MultiLine" Columns="60" Rows="6" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>分类：</td>
                    <td>
                        <asp:DropDownList ID ="ddlCategory" CssClass="ddl1 w160" runat="server"></asp:DropDownList>&nbsp;&nbsp; 
                        <asp:TextBox ID="txtCustom" CssClass="txt1 w160"  runat="server"></asp:TextBox>                      
                    </td>
                </tr>
                <tr style="height:7px;">
                    <td>
                        &nbsp;
                    </td>
                    <td id ="TipsCategory">
                    </td>
                </tr>
                <tr style="display:none;">
                    <td>关键词：</td>
                    <td>
                        <asp:TextBox ID="txtKeyword" CssClass="txt w500" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" CssClass="btn" OnClick="btnSubmit_Click" Text="提交文档" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
