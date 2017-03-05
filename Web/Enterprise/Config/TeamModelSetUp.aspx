<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamModelSetUp.aspx.cs"
    Inherits="Web.Enterprise.Config.TeamModelSetUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团队设置</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <style type="text/css">
    .rolelistinfo td{ padding:8px 0; color:Black;}
    .rolelistinfo div{ height:28px; width:100px; margin:0 auto 0 auto;border:1px solid #ccc; line-height:25px;}
    .rolelistinfo .rl{ border:0; height:14px; background:url(../../images/rolebg.jpg) no-repeat; background-position:center -30px;}
    </style>
     <script type="text/javascript">
         $(function () {
             //判断当前团队模型结构
             var teammodeid = <%=teammodeid %>;
             $("#btnSubmit").click(function(){
                var v = $("input:checked").val();
                v=v.substring(v.length-1);
                if(parseInt(v)<teammodeid)
                {
                    if(!confirm("确定要从高级设置为低级吗？"))
                    {
                        return false;
                    }
                }
             });

         });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            团队设置</h3>
    </div>
    <div class="divlist w500">
        <div class="tmsubase tmsus1">
            <ul>
                <li class="cur">1.选择团队模型</li>
                <li>2.设置团队规模</li>
                <li>3.设置关系</li>
            </ul>
        </div>
        <div>
            <asp:Literal runat="server" ID="LtSelectModel" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <p style="display:inline">购买用户数量:<b style=" color:Red;"><asp:Literal runat="server" ID="ltUserAmount" Text="0" /></b>个。</p>
        </div>
        <table class="tablist rolelistinfo w500" cellpadding="1" cellspacing="1">
            <tr>
                <th>
                    二级模式(1-6人)
                </th>
                <th>
                    三级模式(7-19人)
                </th>
                <th>
                    四级模式(20及以上)
                </th>
            </tr>
            <tr class="c" valign="top" style=" height:180px;">
                <td>
                    <div>
                        总监</div>
                    <div class="rl"></div>
                    <div>
                        销售人员</div>
                </td>
                <td>
                    <div>总监</div>
                     <div class="rl"></div>
                    <div>小组长</div>
                     <div class="rl"></div>
                    <div>销售人员</div>
                </td>
                <td>
                    <div>总监</div>
                     <div class="rl"></div>
                    <div>经理</div>
                     <div class="rl"></div>
                    <div>小组长</div>
                     <div class="rl"></div>
                    <div>销售人员</div>
                </td>
            </tr>
            <tr class="c">
                <td>
                    <asp:RadioButton runat="server" ID="rbModel2" Text="二级模式" GroupName="model" />
                </td>
                <td>
                    <asp:RadioButton runat="server" ID="rbModel3" Text="三级模式" GroupName="model" />
                </td>
                <td>
                    <asp:RadioButton runat="server" ID="rbModel4" Text="四级模式" GroupName="model" />
                </td>
            </tr>
        </table>
        <div class=" mar10"><p style="color: Red; ">
            提示:选择“二级模式”将跳过“2.设置团队规模”。
        </p></div>
        <div class="mar10 w500" style=" text-align:right;">
            <asp:Button runat="server" ID="btnSubmit" Text="下一步" OnClick="btnSubmit_Click" CssClass="btn" />
        </div>        
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=1" type="text/javascript"></script>
</body>
</html>
