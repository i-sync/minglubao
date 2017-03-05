<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WenKuClassList.aspx.cs" Inherits="WebAdmin.WenKu.WenKuClassList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/core.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script src="../js/popup_layer.js" type="text/javascript"></script>
    <script type="text/javascript">
        var pl;
        var CONFIG={
            POST_URL:"/handler/wenku.ashx"
        };
        $(function () {
            pl = new PopupLayer({ title: "文库分类", popupBlk: "#divWenKuClass", useOverlay: "true" });

            //点击添加显示弹出层
            $("#btnAdd").click(function () {
                $("#txtName").val("");
                $("#TipsName").html("");

                $("#divWenKuClass").attr("type", "add");
                $("#divWenKuClass").attr("wid", 0);
                pl.Show();
            });

            //点击修改
            $(".update").click(function () {
                var id = $(this).parents("tr").attr("id");
                //异步请求获取该对象
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "getclass", id: id },
                    success: function (data) {
                        if (data.flag == "1") {
                            $("#txtName").val(data.name);

                            $("#divWenKuClass").attr("type", "update");
                            $("#divWenKuClass").attr("wid", data.id);
                            pl.Show();
                        }
                    },
                    dataType: "json"
                });
            });

            //点击删除
            $(".del").click(function () {
                if (!confirm("确认要删除吗？")) {
                    return false;
                }
                var id = $(this).parents("tr").attr("id");
                //异步请求删除
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "deleteclass", id: id },
                    success: function (data) {
                        if (data == "1") {
                            alert("删除成功！");
                            window.location = window.location;
                        }
                        else {
                            alert("删除失败！");
                        }
                    },
                    dataType: "text"
                });
            });

            $("#btnSubmit").click(function () {
                var name = $("#txtName").val();
                if ($.IsNullOrEmpty(name)) {
                    alert("请输入分类名称");
                    return false;
                }

                //操作类型
                var type = $("#divWenKuClass").attr("type");
                var id = $("#divWenKuClass").attr("wid");
                var data = "";
                if (type == "add") {
                    data = "key=addclass&name=" + name;
                } else {
                    data = "key=updateclass&id=" + id + "&name=" + name;
                }

                //异步请求操作
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: data,
                    success: function (data) {
                        if (data == "1") {
                            alert("提交成功");
                            window.location = window.location;
                        } else {
                            alert("提交失败");
                        }
                    },
                    dataType: "text"
                });
            });

            ///取消
            $("#btnCancel").click(function () {
                $("#divWenKuClass").removeAttr("type");
                $("#divWenKuClass").removeAttr("wid");
                pl.PopClose();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    文库分类
                </th>
            </tr>
            <tr>
                <td>
                    <input id="btnAdd" type="button" value="添加" />
                </td>
            </tr>
            <tr style="text-align:left;">
                <td>
                    <table class="tablist" cellspacing="1" border="0" cellpadding="1">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                名称
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <tr class="c" id="<%#Eval("WenKuClassID") %>">
                                    <td>
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%#Eval("WenKuClassName") %>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0);" class="update">修改</a>
                                        <a href="javascript:void(0);" class="del">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
        <div style="width: 350px; border: 1px solid #ccc; background-color: White; padding-left:10px; height:120px;" id="divWenKuClass">
            <br />
            <table >
                <tr >
                    <td style="text-align:right" >
                        分类名称：
                    </td>
                    <td>
                        <input type="text" id="txtName" class="txt w500"/>
                    </td>
                </tr>
                <tr>
                    <td >
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="btnSubmit" value="确定"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" id="btnCancel" value="取消"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
