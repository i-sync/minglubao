<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuTips.aspx.cs" Inherits="WebAdmin.Enterprise.Menu.MenuTips" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单提示</title>
    <link href="../../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">   
        $(document).ready(function () {

            //清空新增或修改的内容
            $("#btnCancelAddItem").click(function () {
                $(this).prev().prev().val("");
            });
            $("#btnCancelUpdateItem").click(function () {
                $(this).prev().prev().val("");
            });

            //点击修改选项
            $(".updateitem").live("click", function () {
                //获取当前选项名称 
                var name = $.trim($(this).parent().prev().text());
                //为当前行添加id，来标识该行正在修改
                var tr = $(this).parent().parent();
                tr.attr("id", "update");
                $("#txtUpdateItem").val(name);
            });

            //点击删除选项
            $(".deleteitem").live("click", function () {
                $(this).parent().parent().remove();
                $("#cbDeleteRelation").attr("checked", "true");
            });

            //点击新增选项
            $("#btnAddItem").click(function () {
                //获取录入的选项名称
                var name = $("#txtAddItem").val();
                if ($.IsNullOrEmpty(name)) {
                    alert("请输入选项名称");
                    return;
                }
                //获取tr模板
                var tr = $("#itemTemplate").clone();
                var table = $("#tItem");
                tr.appendTo(table);
                $("#tItem").find("tr:last").find("input[name='hdTipsNameS']").val(name);
                $("#tItem").find("tr:last").find("td").eq(1).text(name);
                //清空文本框
                $("#txtAddItem").val("");
            });

            //点击保存要修改的选项
            $("#btnUpdateItem").click(function () {
                //获取修改后的选项名称
                var name = $.trim($("#txtUpdateItem").val());
                if ($.IsNullOrEmpty(name)) {
                    alert("请输入选项名称");
                    return;
                }
                //获取tr模板
                var tr = $("#update");
                tr.find("input[name='hdTipsNameS']").val(name);
                tr.find("td").eq(1).text(name);
                //把该行的id属性移除
                tr.removeAttr("id");
                //清空文本框
                $("#txtUpdateItem").val("");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">   
        <table class="tableBorder" width="98%"  border="0" align="center">
            <tr>
                <th class="bigTitle">
                    菜单提示修改
                </th>
            </tr>
            <tr>
                <td>                    
                    <table class="tablist" cellspacing="1" cellpadding="1">
                        <tr>
                            <td>
                                菜单名称：
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:Literal ID="ltMenuName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                提示信息：
                            </td>
                            <td>
                                <table id="tItem" style="text-align:left;">
                                    <asp:Repeater ID="rpList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <input type="hidden" name="hdTipsIDs" value="<%#Eval("PageTipsID") %>" />
                                                    <input type="hidden" name="hdTipsNameS" value="<%#Eval("Tips") %>" />
                                                </td>
                                                <td>
                                                    <%#Eval("Tips") %>
                                                </td>
                                                <td>
                                                    <a href="javascript:void(0);" class="updateitem">修改</a> <a href="javascript:void(0);"
                                                        class="deleteitem">删除</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <div style="text-align:left;margin:10px;padding:5px;">
                                    <div>
                                        <span>新增：</span>
                                        <input type="text" class="txt" style="width:500px;" id="txtAddItem" />
                                        <input type="button" id="btnAddItem" class="btn1" value="添加" />
                                        <input type="button" id="btnCancelAddItem" class="btn1" value="取消" />
                                    </div>
                                    <div style="margin: 5px 0 0 0;">
                                        <span>修改：</span>
                                        <input type="text" class="txt" style="width:500px;" id="txtUpdateItem" />
                                        <input type="button" id="btnUpdateItem" class="btn1" value="保存" />
                                        <input type="button" id="btnCancelUpdateItem" class="btn1" value="取消" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr >
                            <td>
                                &nbsp;
                            </td>
                            <td style="text-align:left;padding:5px;">
                                <asp:Button ID="btnSubmit" CssClass="btn" Text="确定" OnClick="btnSubmit_Click" runat="server" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="button" value="取消" class="btn" id="btnCancel" onclick="window.location.replace('MenuList.aspx');" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table> 
        
    </form>

     <!--选项模板-->
    <table style="display: none">
        <tr id="itemTemplate">
            <td>
                <input type="hidden" name="hdTipsIDs" value="-1" />
                <input type="hidden" name="hdTipsNameS" value="" />
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
