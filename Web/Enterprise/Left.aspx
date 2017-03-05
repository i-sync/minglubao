<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Web.Enterprise.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/YindaoTip.js" type="text/javascript"></script>
    <script type="text/javascript">
        //var timer = null;
        $(function () {            
            $(".title").click(function () {
                var pObj = $(this).parent();
                if ($(pObj).is("div")) {
                    if ($(pObj).attr("class") == "item") {
                        $(pObj).attr("class", "curitem");
                    }
                    else {
                        $(pObj).attr("class", "item");
                    }
                }
            });
            $("a").click(function () {
                if ($(this).attr("class") == "current") {
                    return true;
                }
                $(".curent").removeClass("curent");
                $(this).addClass("curent");
            });
            //打开默认菜单
            $(".title[Expand='1']").each(function () {
                $(this).triggerHandler("click");
            });


//            //--------------关闭窗口--------------
//            $(window).bind("beforeunload", function () { return "本页面要求您确认您要离开 - 您输入的数据可能不会被保存"; });
//            $(window).bind("unload", function () {
//                clearInterval(timer);
//                timer = null;
//                $.get("Logout.aspx", function () { });
//            });
//            timer = setInterval(function () { $.post(URLPlusRandom("handler/user.ashx"), "key=active", function () { }) }, 60000);

            //<%if(ShowTip){ %>
            //引导弹出层提示信息 
            //YindaoTip.Init($("#divTip"),<%=kid %>);
           //<%} %>
        });
    </script>

    <style type="text/css">
        .tips
        {
            display: none;
            position: absolute;
            top: 100px;
            left: 10px;
            width: 638px;
            line-height: 180%;
            z-index: 1000;
        }
        .tips div a
        {
            color: Red;
        }
        .tips .content
        {
            background: url(../images/tips/bg.png);
            height: 183px;
            margin: 0;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu fl" style="border-right:1px solid #ccc; height:800px; overflow: hidden;">
                <div class="list_xiugaimima">
                    <div class="guanliyuan fl">
                        <asp:Image ID="imgAvatar" runat="server" Width="30" Height="30" />
                    </div>
                    <div class="guanliyuan_denglu fl">
                        <div class="guanliyuan_denglushang">
                            <asp:Literal runat="server" ID="ltRole" Visible="false" />
                            <asp:Literal runat="server" ID="ltTrueName" />
                        </div>
                        <div class="guanliyuan_dengluxia">
                            <a href="UpdatePassword.aspx" target="main">[修改密码]</a>&nbsp;<a href="Logout.aspx"
                                target="_parent">[注销]</a>
                        </div>
                    </div>
                </div>
                <div class="menulist">
                    <asp:Repeater runat="server" ID="rpSecondMenu" OnItemDataBound="rpSecondMenu_ItemDataBound">
                        <ItemTemplate>
                            <div class="item" pid="<%#Eval("pid") %>">
                                <div class="title" expand="<%#Eval("Expand") %>">
                                    <a  href="<%#Eval("Url") %>" target="main">
                                        <%#Eval("MenuName") %></a></div>
                                <div>
                                    <ul>
                                        <asp:Repeater ID="rpThirdMenu" runat="server">
                                            <ItemTemplate>
                                                <li><a href="<%#Eval("Url") %>" target="main">
                                                    <%#Eval("MenuName") %></a> </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    <%if (RoleID == ((int)MLMGC.DataEntity.User.EnumRole.总监))
                        { %>
                    <!--项目名录：只有是总监，并且已经开通的企业才显示此菜单-->
                    <div class="item" pid="1000">
	                    <div class="title">
	                        <a href="javascript:void(0);">项目名录</a>
	                    </div>
	                    <div>
	                        <ul>
                                <li><a href="Item/itemapply.aspx" target="main">个人申请</a></li>
                                <li><a href="Item/itemmember.aspx" target="main">成员列表</a></li>
                                <li><a href="Item/quitapply.aspx" target="main">退出申请</a></li>
                                <%if (IsOpen)
                                    { %>
		                        <li><a href="Item/Search.aspx" target="main">名录检索</a></li>
		                        <li><a href="Item/Latence.aspx" target="main">潜在名录</a></li>
		                        <li><a href="Item/Wish.aspx" target="main">意向名录</a></li>
		                        <li><a href="Item/Traded.aspx" target="main">成交名录</a></li>
		                        <li><a href="Item/NotTraded.aspx" target="main">失败名录</a></li>
		                        <li><a href="Item/Scrap.aspx" target="main">报废名录</a></li>
                                <li><a href="Item/Share.aspx" target="main">管理共享池</a></li>
		                        <li><a href="Item/Recycled.aspx" target="main">回收站</a></li>
                                <li><a href="Item/DataImport.aspx" target="main">数据导入</a></li>
                                <%} %>
	                        </ul>
	                    </div>
                    </div>
                    <%} %>
                </div>
            </div>
    </form>

    <!--弹出层提示开始-->
    <div id="divTip" class="tips">
        <img src="../images/tips/top2.png" style="width: 400px; height: 17px;" />
        <div class="content">
            <div style="text-align: right; vertical-align: middle; height: 44px;">
                <div class="fr" style="margin: 10px 14px 0 0;">
                    <img class="close" src="../images/tips/delete.png" style="width: 17px; cursor: pointer;"
                        alt="关闭" />
                </div>
                <div class="fr" style="margin: 10px 10px 0 0;">
                    <span id="spanIndex">0</span>/<span id="spanTotal">0</span>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div id="divContent" style="width: 450px; height: 110px; margin-left: 155px; color: Black;
                display: block; font-size: 14px;">
            </div>
            <div style="text-align: right; margin: 5px 30px 0 0;">
                <a class="close" href="javascript:void(0);">我知道了，开始使用</a> &nbsp;&nbsp;&nbsp;&nbsp;
                <a id="aNext" href="javascript:void(0);">下一条</a>
            </div>
        </div>
    </div>
    <!--弹出层提示结束-->
</body>
</html>
