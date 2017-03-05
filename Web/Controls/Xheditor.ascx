<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Xheditor.ascx.cs" Inherits="Web.Enterprise.Controls.Xheditor" %>
<!------------编辑器start-------------->
<asp:TextBox ID ="txtContent" ClientIDMode="Static" TextMode="MultiLine" runat="server" Width="800"></asp:TextBox>  

<link rel="stylesheet" type="text/css" href="/ueditor/themes/default/ueditor.css"/>
<script type="text/javascript" charset="utf-8" src="/ueditor/editor_config.js"></script>
<script type="text/javascript" charset="utf-8" src="/ueditor/editor_all.js"></script>
<script type="text/javascript">
    var editor_a = new baidu.editor.ui.Editor();
    editor_a.render('txtContent');
</script>
<!------------编辑器end-------------->
