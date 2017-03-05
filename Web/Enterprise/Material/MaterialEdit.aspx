<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialEdit.aspx.cs" Inherits="Web.Enterprise.Material.MaterialEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑项目资料</title>    
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type ="text/javascript" language ="javascript" src ="../../JS/jquery-1.6.4.js"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/json.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#txtMaterialName").blur(function () {
                var msg = "";
                if ($.IsNullOrEmpty($(this).val())) {
                    msg = "<span class='error'>请输入资料名称</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsName").html(msg);
            });

            $("#txtClassName").blur(function () {
                var msg = "";
                if ($.IsNullOrEmpty($(this).val())) {
                    msg = "<span class='error'>请输入资料分类</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsClassName").html(msg);
            });

            $("#btnSubmit").click(function () {
                var txtMaterialName = $("#txtMaterialName").val();
                var txtClassName = $("#txtClassName").val();
                if (txtMaterialName.length > 64) {
                    //alert("");
                    $("#TipsName").html("<span class='error'>标题输入太长，请检查......</span>");
                    //return false;
                }
                if (txtClassName.length > 64) {
                    //alert("分类输入太长，请检查......");
                    //return false;
                    $("#TipsClassName").html("<span class='error'>标题输入太长，请检查......</span>");
                }
                if ($.IsNullOrEmpty(txtClassName)) {
                    //alert("请输入内容");
                    //return false;
                    $("#TipsClassName").html("<span class='error'>请输入资料分类</span>");
                }
                if ($.IsNullOrEmpty(txtMaterialName)) {
                    $("#TipsName").html("<span class='error'>请输入资料名称</span>");
                }

                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>项目资料编辑页</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td>标题：</td>
                <td>
                    <asp:TextBox ID ="txtMaterialName" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td id="TipsName">
                
                </td>
            </tr>
            <tr>
                <td>分类：</td>
                <td>
                    <asp:TextBox ID ="txtClassName" CssClass="txt"  runat="server"></asp:TextBox>
                </td>
                <td id="TipsClassName"></td>
            </tr>
            <tr>
                <td>附件：</td>
                <td>  
                    <MLB:FileUpload runat="server" ID="FileUpload1" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID ="btnSubmit" Text ="确定" OnClick ="btnSubmit_Click" CssClass="btn" runat="server"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value ="取消" id ="btnCancel" class="btn" onclick ="window.location.replace('MaterialList.aspx');"/>   
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
