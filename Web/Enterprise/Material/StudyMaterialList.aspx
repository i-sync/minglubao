<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudyMaterialList.aspx.cs" Inherits="Web.Enterprise.Material.StudyMaterialList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学习资料列表</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //为表格添加滑动样式
            $.Hover(".tablist tr");

            //判断是否删除
            $(".del").click(function () {
                var result = confirm("确认要删除吗？");
                if (!result)
                    return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>学习资料</h3>
    </div>
    <div class="divlist">
    <!--<div class="redtip">
            <ul>
                <li>如果你想业务员水平很高，经常培训很重要。建立学习资料库，把好资料传上去，业务员随时按需索取。</li>
                <li>别忘了把好的学习资料共享给名录宝，您为人人，人人为您，你还可以得到名录宝积分积分可以下载别人共享的资料，还可以下载名录，很划算吧。</li>
            </ul>
        </div>-->
        <p><input type="button" id ="btnAdd" value="添加" class="btn1" onclick="window.location.replace('StudyMaterialEdit.aspx?type=add');"/></p>
        <table cellpadding="1" cellspacing ="1" class ="tablist top10">
            <tr>
                <th class="num">序号</th>
                <th style=" width:100px;">操作</th>
                <th>标题</th>
                <th class="date">日期</th>
                <th style="width:100px;">共享状态</th>
            </tr>
            <asp:Repeater ID ="rpList" runat="server">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>                            
                            <a href="StudyMaterialEdit.aspx?type=update&materialid=<%#Eval("MaterialID") %>" >修改</a>
                            <a class="del" href="StudyMaterialList.aspx?type=delete&materialid=<%#Eval("MaterialID") %>">删除</a>
                        </td>
                        <td style=" padding-left:5px; text-align:left;">
                            <a href="<%#MLMGC.COMP.Config.GetEnterpriseStudyUrl(EnterpriceID,Eval("Url").ToString()) %>" target="_blank"><%#Eval("MaterialName") %></a>
                        </td>
                        <td>
                            <%#Eval("UpdateDate","{0:yyyy-MM-dd HH:mm}") %>
                        </td>
                        <td>
                            <%#Share(Eval("WenKuFlag"),Eval("MaterialID")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <MLB:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
             AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                        PageSize="1" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
                        CustomInfoTextAlign="Center" LayoutType="Table"
                        ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=14" type="text/javascript"></script>
</body>
</html>
