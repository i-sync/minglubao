<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudyMaterialEdit.aspx.cs" Inherits="Web.Enterprise.Material.StudyMaterialEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑学习资料</title>    
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type ="text/javascript" language ="javascript" src ="../../JS/jquery-1.6.4.js"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/json.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#txtStudyMaterialName").blur(function () {
                var obj = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(obj)) {
                    msg = "<span class='error'>请输入标题</span>";
                }
                $("#TipsName").html(msg);
            });
            $("#btnSubmit").click(function () {
                
                var txtStudyMaterialName = $("#txtStudyMaterialName").val();
                if (txtStudyMaterialName.length > 64) {
                    $("#TipsName").html("<span class='error'>标题输入太长，请检查......</span>");
                    //return false;
                }
                if ($.IsNullOrEmpty(txtStudyMaterialName)) {
                    $("#TipsName").html("<span class='error'>请输入标题</span>");
                    //return false;
                }
                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>学习资料编辑页</h3>
    </div>
    <div class="divlist">
        <table cellpadding="1" cellspacing ="1" class="tabtxtlist">
            <tr>
                <td>标题：</td>
                <td>
                    <asp:TextBox ID ="txtMaterialName" CssClass="txt" runat="server"></asp:TextBox>
                    <span id ="TipsName"></span>
                </td>
            </tr>           
            <tr>
                <td>附件：</td>
                <td>  
                    <MLB:FileUpload runat="server" ID="FileUpload1" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID ="btnSubmit" Text ="确定" CssClass="btn" OnClick ="btnSubmit_Click" runat="server"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value ="取消" class="btn" id ="btnCancel" onclick ="window.location.replace('StudyMaterialList.aspx');"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
