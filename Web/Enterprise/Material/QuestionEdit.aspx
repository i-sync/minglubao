<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionEdit.aspx.cs" Inherits="Web.Enterprise.Material.QuestionEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>调查问卷编辑页</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/popup_layer.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/core.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    #tItem tr{ height:120%;}
    </style>
    <script type="text/javascript" language="javascript">
        var Tips = {
            succ: '输入正确'
        };
        var pl;

        //显示选项表格的序号
        function ShowIndex(sender) {
            var td = sender.find(".index");            
            for (var i = 0; i < td.length; i++) {
                $(td[i]).html((i + 1).toString()+"、");
            }
        };

        $(document).ready(function () {
            //初始化层
            pl = new PopupLayer({ title: "选项", popupBlk: "#divQuestion", useOverlay: "true" });

            //验证标题
            $("#txtQuestionName").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入标题</span>";
                }
                else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsName").html(msg);
            });
            //点击确定按钮验证数据
            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
            });

            $("#btnAdd").click(function () {
                $("#txtItemName").val("");
                //设置操作类型：添加还是修改
                $("#divQuestion").attr("type", "add");
                pl.Show();
            });

            //点击修改选项
            $(".updateitem").live("click", function () {
                //获取当前选项名称 
                var questionName = $.trim($(this).parent().prev().text());
                //为当前行添加id，来标识该行正在修改
                //先移除之前所有的tr的id
                $("#tItem").find("tr").removeAttr("id");
                var tr = $(this).parent().parent();
                tr.attr("id", "update");

                //设置操作类型为修改
                $("#divQuestion").attr("type", "update");
                $("#txtItemName").val(questionName);
                pl.Show();
            });

            //点击删除选项
            $(".deleteitem").live("click", function () {
                $(this).parent().parent().remove();
                $("#cbDeleteRelation").attr("checked", "true");

                //重新设置显示序号
                ShowIndex($("#tItem"));
            });

            //点击确定
            $("#btnS").click(function () {
                //获取录入的选项名称
                var questionName = $("#txtItemName").val();
                if ($.IsNullOrEmpty(questionName)) {
                    alert("请输入选项名称");
                    return;
                }
                //获取操作类型
                var type = $("#divQuestion").attr("type");

                //如果是添加
                if (type == "add") {
                    //获取tr模板
                    var tr = $("#itemTemplate").clone();
                    var table = $("#tItem");
                    tr.appendTo(table);
                    $("#tItem").find("tr:last").find("input[name='hdQuestionItemNameS']").val(questionName);
                    $("#tItem").find("tr:last").find("td").eq(2).text(questionName);

                    //重新设置显示序号
                    ShowIndex($("#tItem"));
                }
                else {
                    //获取tr模板
                    var tr = $("#update");
                    tr.find("input[name='hdQuestionItemNameS']").val(questionName);
                    tr.find("td").eq(2).text(questionName);
                    //把该行的id属性移除
                    tr.removeAttr("id");
                    $("#cbDeleteRelation").attr("checked", "true")
                }
                //清空文本框
                $("#txtItemName").val("");
                pl.PopClose();
            });

            //隐藏显示层
            $("#btnC").click(function () {
                pl.PopClose();
            });

            $("input:radio").click(function () {
                if ($(this).val() == "1") {
                    $("#cbDeleteRelation").attr("checked", "true");
                }
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            调查问卷编辑页</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td class="name">
                    问卷标题：
                </td>
                <td>
                    <asp:TextBox ID="txtQuestionName" CssClass="txt w420" MaxLength="64" runat="server"></asp:TextBox>
                    <span id="TipsName"></span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    答案类型：
                </td>
                <td>
                    <asp:RadioButtonList ID="rblQuestionType" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        runat="server">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="name" valign="top">
                    选项：
                </td>
                <td>
                    <table id="tItem">
                        <asp:Repeater ID="rpList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="index">
                                        <%# Container.ItemIndex+1 %>、
                                    </td>
                                    <td>
                                        <input type="hidden" name="hdQuestionItemIDs" value="<%#Eval("QuestionItemID") %>" />
                                        <input type="hidden" name="hdQuestionItemNameS" value="<%#Eval("QuestionItemName") %>" />
                                    </td>
                                    <td>
                                        <%#Eval("QuestionItemName") %>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0);" class="updateitem">修改</a> <a href="javascript:void(0);"
                                            class="deleteitem">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div>
                        <a  id="btnAdd" href="javascript:void(0);">添加</a>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSubmit" CssClass="btn" Text="保存" OnClick="btnSubmit_Click" runat="server" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value="返回" class="btn" id="btnCancel" onclick="window.location.replace('QuestionList.aspx');" />
                </td>
            </tr>
        </table>
        <%if (rpClientInfo.Items.Count > 0)
          { %>
        <div class="divlist">
            <span>与该问题相关的名录共<asp:Label ID="lblClientNum" runat="server"></asp:Label>
                条</span><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
            <asp:CheckBox ID="cbDeleteRelation" Text="删除以下关系" runat="server" />
            <table cellpadding="1" cellspacing="1" class="tablist" style=" width:300px; text-align:center;">
                <tr>
                    <th style=" width:50px;">
                        序号
                    </th>
                    <th>
                        名录名称
                    </th>
                </tr>
                <asp:Repeater ID="rpClientInfo" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("nid") %>
                            </td>
                            <td>
                                <a href="../ClientInfo/Info.aspx?ciid=<%#Eval("ClientInfoID") %>">
                                    <%#Eval("ClientName") %></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <%} %>
    </div>
    <div style="width: 650px; border: 1px solid #ccc; background-color: White; display: none;" id="divQuestion">
        <table style="margin: 10px;">
            <tr>
                <td>
                    选项：
                </td>
                <td>
                    <input type="text" id="txtItemName" class="txt w420" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <input type="button" id="btnS" value="确定" class="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnC" value="取消" class="btn" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--问题选项模板-->
    <table style="display: none">
        <tr id="itemTemplate">
            <td class="index">
                
            </td>
            <td>
                <input type="hidden" name="hdQuestionItemIDs" value="-1" />
                <input type="hidden" name="hdQuestionItemNameS" value="" />
            </td>
            <td>
            </td>
            <td>
                <a href="javascript:void(0);" class="updateitem">修改</a> <a href="javascript:void(0);"
                    class="deleteitem">删除</a>
            </td>
        </tr>
    </table>
</body>
</html>
